using Microsoft.AspNetCore.Identity;

namespace ChipsetShop.MVC.Models
{
    public class UserModel : IdentityUser
    {
        public UserModel()
        {
            
        }

        public UserModel(string userName) : base(userName)
        {
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int ZIPCode { get; set; }
        public string Telephone { get; set; }
    }
}