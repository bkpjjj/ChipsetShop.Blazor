using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ChipsetShop.MVC.Models;
using Microsoft.AspNetCore.Identity;

namespace ChipsetShop.MVC.Services
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(ProductModel product, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Product_Id == product.Id)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Product_Id = product.Id,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;

                if(line.Quantity <= 0)
                {
                    RemoveLine(product);
                }
            }
        }

        public void RemoveLine(ProductModel product)
        {
            lineCollection.RemoveAll(l => l.Product_Id == product.Id);
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class CartLine
    {
        public int Product_Id { get; set; }
        public int Quantity { get; set; }
    }
}