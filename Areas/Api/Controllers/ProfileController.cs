using System.Linq;
using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using ChipsetShop.MVC.Models.Json;
using ChipsetShop.MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChipsetShop.MVC.Models;
using ChipsetShop.MVC.Helpers;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ChipsetShop.MVC.Api.Controllers
{
    [ApiController]
    [Area("api")]
    [Route("[area]/[controller]")]
    [Authorize(Roles = "user")]
    public class ProfileController : Controller
    {
        private readonly DataContext dataContext;
        private readonly ILogger<CatalogController> logger;
        public ProfileController(DataContext data, ILogger<CatalogController> logger)
        {
            dataContext = data;
            this.logger = logger;
        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> DeleteComment([FromForm]int id)
        {
            var comment = await dataContext.Comments.FindAsync(id);

            if(comment is null)
                return BadRequest();

            var user_id = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if(comment.User_Id != user_id)
                return Forbid();

            dataContext.Comments.Remove(comment);
            await dataContext.SaveChangesAsync();

            return Ok();
        }

        [Route("[action]")]
        [HttpGet()]
        public IActionResult Comments(string product, int page)
        {
            var user_id = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            dataContext.Products.Include(x => x.Category).Load();
            List<CommentModel> allComments = dataContext.Comments.Include(x => x.Product).Include(x => x.User).ToList();

            if (!string.IsNullOrEmpty(product))
                allComments = allComments.Where(x => x.Product.MetaName == product).ToList();

            int commentsCount = allComments.Count;

            allComments = allComments.Where(x => x.User_Id == user_id).ToList();

            List<CommentModel> pageComments = allComments.Skip(10 * (page - 1)).Take(10).ToList();


            JAdminCommentsModel json_comments = new JAdminCommentsModel()
            {
                Comments = pageComments.Select(x => new JAdminCommentModel()
                {
                    Id = x.Id,
                    Text = x.Text,
                    Title = x.Title,
                    Dignity = x.Dignity,
                    Limitations = x.Limitations,
                    Date = x.Date.ToString(@"dd\.MM\.yyyy в hh\:mm"),
                    Rate = x.Rate,
                    User = new JUserModel()
                    {
                        Email = x.User.Email,
                        Login = x.User.UserName
                    },
                    Product = new JAdminCommentModel.JAdminProductModel()
                    {
                        Key = x.Product.MetaName,
                        Url = "/catalog/" + x.Product.Category.MetaName + "/" + x.Product.MetaName
                    }
                }),
                CommentsCount = commentsCount,
                CurrentPage = page,
                TotalPages = (int)MathF.Ceiling(commentsCount / 10.0f),
            };

            return Json(json_comments);
        }
    }
}