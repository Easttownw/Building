using BuildingADLRepositoryLib.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BuildingADLRepositoryLib.Services.ServicesTbUser.ServicesTbUser;

namespace BuildingADLRepositoryLib.Services.ServicesTbUser
{
    public interface IServicesTbUser
    {
        public TbUser GetALLbyId(int id);
        public List<TbUser> GetAll();
        public IEnumerable PostTbUser(TbUserLis tbUserLis);
        public IEnumerable updateTbUser(TbUserLis tbUserLis);

        public IEnumerable DeleeTbUser(int id);

    }
}
