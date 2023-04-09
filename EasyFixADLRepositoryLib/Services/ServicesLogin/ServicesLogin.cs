using BuildingADLRepositoryLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bc = BCrypt.Net.BCrypt;
namespace BuildingADLRepositoryLib.Services.ServicesLogin
{
    public class ServicesLogin : IServicesLogin
    {

        private readonly TechnicalSupportContext _context;
        public ServicesLogin(TechnicalSupportContext context)
        {
            _context = context;
        }
        public class User
        {
            public string UserName { get; set; }
            public bool Is_active { get; set; }
            public string Password { get; set; }
        }
        public string LoginUser(User users)
        {
            var UserLogin = _context.TbUsers.Where(a => a.UserName.Contains(users.UserName) && a.Is_active == true&& a.Password ==users.Password)
                 //Select FullUserName IS_allow UserID UserName
                 .Select(w => new { w.CustomerID, w.UserID, w.UserName }).FirstOrDefault();
            //var Password = Bc.HashPassword(users.Password);
            if (UserLogin != null)
            {
                return ("You Are logged in " + UserLogin);
            }
            else
            {
                return ("UserName or Password is incorrect");
            }

        }
    }
}
