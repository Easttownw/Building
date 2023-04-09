using BuildingADLRepositoryLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BuildingADLRepositoryLib.Services.ServicesLogin.ServicesLogin;

namespace BuildingADLRepositoryLib.Services.ServicesLogin
{
    public interface IServicesLogin
    {
        public string LoginUser(User users);
    }
}
