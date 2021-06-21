using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ChipsetShop.MVC.Models;
using ChipsetShop.MVC.Services;
using ChipsetShop.MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChipsetShop.MVC.Controllers
{
    [Controller]
    [Authorize(Roles = "admin")]
    [Route("[controller]")]
    public class AdministrationController : Controller
    {
        private DataContext dataContext;
        private IWebHostEnvironment appEnvironment;

        public AdministrationController(DataContext dataContext, IWebHostEnvironment appEnvironment)
        {
            this.dataContext = dataContext;
            this.appEnvironment = appEnvironment;
        }

        [Route("[action]")]
        public IActionResult Products()
        {
            return View();
        }
        [Route("[action]")]
        public IActionResult AddProduct()
        {
            return View(dataContext.Categories.ToList());
        }
        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDataViewModel model)
        {
            if(dataContext.Products.FirstOrDefault(x => x.MetaName == model.MetaName) is not null)
                ModelState.AddModelError("", "Товар с таким ключем уже существует!");

            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                ProductModel product = new ProductModel();
                product.Name = model.Name;
                product.MetaName = model.MetaName;
                product.Discount = model.Discount;
                product.IsNew = model.IsNew;
                product.InStock = model.InStock;
                product.Prise = model.Prise;
                product.Category = dataContext.Categories.Where(x => x.MetaName == model.Category).First();
                product.Tags = (model.Tags ?? "").Split(",").Select(x => new TagModel() { Name = x.Trim() }).ToList();
                product.Attributes = new List<AttributeModel>();

                foreach (var attr in model.Attributes)
                {
                    AttributeScemeModel scheme = dataContext.AttributeScemes.Where(x => x.Name == attr.Name).FirstOrDefault() ?? new AttributeScemeModel() { Name = attr.Name, IsGeneral = attr.IsGeneral };

                    AttributeModel attributeModel = new AttributeModel() { AttributeSceme = scheme, Value = attr.Value };

                    product.Attributes.Add(attributeModel);
                }

                product.Pictures = new List<ImageStorageModel>();
                foreach (var image in model.Images)
                {
                    var path = "/img/" + image.FileName;

                    using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await image.CopyToAsync(fileStream);
                    }

                    product.Pictures.Add(new ImageStorageModel() { ImageSource = path, });
                }

                dataContext.Products.Add(product);
                await dataContext.SaveChangesAsync();
            }
            else
            {
                foreach (var v in ModelState.Values)
                {
                    foreach (var error in v.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                return BadRequest(errors);
            }

            return Ok();
        }

        [Route("[action]")]
        public IActionResult GetProduct(int id)
        {
            dataContext.Attributes.Include(x => x.AttributeSceme).Load();
            dataContext.Products.Include(x => x.Category).Include(x => x.Attributes).Include(x => x.Tags).Load();
            ProductModel product = dataContext.Products.Find(id);
            ProductDataViewModel vm = new ProductDataViewModel();

            vm.Name = product.Name;
            vm.MetaName = product.MetaName;
            vm.Discount = product.Discount;
            vm.IsNew = product.IsNew;
            vm.InStock = product.InStock;
            vm.Tags = string.Join(", ", product.Tags.Select(x => x.Name));
            vm.Category = product.Category.MetaName;
            vm.Prise = product.Prise;
            vm.Attributes = product.Attributes.Select(x => new AttributeDataViewModel() { Name = x.AttributeSceme.Name, IsGeneral = x.AttributeSceme.IsGeneral, Value = x.Value });

            return Json(vm);
        }

        [Route("[action]/{id}")]
        public IActionResult EditProduct(int id)
        {
            ViewData["product_id"] = id;
            return View(dataContext.Categories.ToList());
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> EditProduct(int id, ProductDataViewModel model)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                ProductModel product = await dataContext.Products.FindAsync(id);
                product.Name = model.Name;
                product.MetaName = model.MetaName;
                product.Discount = model.Discount;
                product.IsNew = model.IsNew;
                product.InStock = model.InStock;
                product.Prise = model.Prise;
                product.Category = dataContext.Categories.Where(x => x.MetaName == model.Category).First();
                dataContext.Attributes.Include(x => x.AttributeSceme).Load();
                dataContext.Products.Include(x => x.Tags).Include(x => x.Attributes).Load();

                var newTags = new List<TagModel>();

                foreach (var tag in (model.Tags ?? "").Split(","))
                {
                    var value = tag.Trim();

                    TagModel tagModel = product.Tags.Where(x => x.Name == value).FirstOrDefault() ?? new TagModel();

                    tagModel.Name = value;
                    newTags.Add(tagModel);
                }

                product.Tags = newTags;

                var newAttrib = new List<AttributeModel>();

                if (model.Attributes is not null)
                    foreach (var attr in model.Attributes)
                    {
                        AttributeScemeModel scheme = dataContext.AttributeScemes.Where(x => x.Name == attr.Name).FirstOrDefault() ?? new AttributeScemeModel() { Name = attr.Name, IsGeneral = attr.IsGeneral };

                        AttributeModel attributeModel = product.Attributes.Where(x => x.Value == attr.Value).FirstOrDefault() ?? new AttributeModel();

                        scheme.IsGeneral = attr.IsGeneral;
                        attributeModel.AttributeSceme = scheme;
                        attributeModel.Value = attr.Value;
                        

                        newAttrib.Add(attributeModel);
                    }

                product.Attributes = newAttrib;

                await dataContext.SaveChangesAsync();
            }
            else
            {
                foreach (var v in ModelState.Values)
                {
                    foreach (var error in v.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                return BadRequest(errors);
            }

            return Ok();
        }
        [Route("[action]")]
        public IActionResult Comments()
        {
            return View();
        }
        [Route("[action]")]
        public IActionResult Categories()
        {
            return View();
        }

        [Route("[action]")]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddCategory(CategoryViewModel model)
        {
            List<string> errors = new List<string>();
            if (ModelState.IsValid)
            {
                CategoryModel category = new CategoryModel();
                category.Name = model.Name;
                category.MetaName = model.MetaName;

                var path = "/img/" + model.Image.FileName;

                using (var fileStream = new FileStream(appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await model.Image.CopyToAsync(fileStream);
                }

                category.IconUrl = path;


                dataContext.Categories.Add(category);
                await dataContext.SaveChangesAsync();
            }
            else
            {
                foreach (var v in ModelState.Values)
                {
                    foreach (var error in v.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }

                return BadRequest(errors);
            }

            return Ok();
        }
    }
}