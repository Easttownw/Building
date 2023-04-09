using BuildingADLRepositoryLib.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingADLRepositoryLib.Services.ServicesTbUser
{
    public class ServicesTbUser : IServicesTbUser
    {

        private readonly TechnicalSupportContext _context;
        public ServicesTbUser(TechnicalSupportContext context)
        {
            _context = context;
        }

        public IEnumerable DeleeTbUser(int id)
        {
            try
            {
                TbUser tbUser = _context.TbUsers.Find(id);
                if (tbUser is not null)
                {
                    _context.Remove<TbUser>(tbUser);
                    _context.SaveChanges();
                    return ("1");
                }
                return ("0");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<TbUser> GetAll()
        {
            List<TbUser> TbUser;
            try
            {
                TbUser = _context.Set<TbUser>().ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return TbUser;
        }

        public TbUser GetALLbyId(int id)
        {
            TbUser tbUser;
            try
            {
                tbUser = _context.Find<TbUser>(id);
            }
            catch (Exception)
            {

                throw;
            }
            return tbUser;
        }

        public IEnumerable PostTbUser(TbUserLis tbUserLis)
        {
            try
            {
                TbUser tbUser = new TbUser();
                tbUser.UserID = tbUserLis.UserID;
                tbUser.UserName = tbUserLis.UserName;
                tbUser.CustomerID = tbUserLis.CustomerID;
                tbUser.Password = tbUserLis.Password;
                tbUser.Is_active = tbUserLis.Is_active;
                _context.Add<TbUser>(tbUser);
                _context.SaveChanges();
                var TbUseritem = (from a in _context.TbUsers
                                  where a.UserID == tbUser.UserID
                                  select a)
                                  .ToList();
                return TbUseritem;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable updateTbUser(TbUserLis tbUserLis)
        {
            try
            {
                TbUser tbUser = _context.TbUsers.Find(tbUserLis.UserID);
                if (tbUser is not null)
                {
                    tbUser.UserID = tbUserLis.UserID;
                    tbUser.UserName = tbUserLis.UserName;
                    tbUser.CustomerID = tbUserLis.CustomerID;
                    tbUser.Password = tbUserLis.Password;
                    tbUser.Is_active = tbUserLis.Is_active;
                    _context.Update<TbUser>(tbUser);
                }
                
                _context.SaveChanges();
                var TbUseritem = (from a in _context.TbUsers
                                  where a.UserID == tbUser.UserID
                                  select a)
                                  .ToList();
                return TbUseritem;

            }
            catch (Exception)
            {

                throw;
            }
        }
        public class TbUserLis
        {
            public int UserID { get; set; }

            public int CustomerID { get; set; }

            public string UserName { get; set; } = null!;

            public string Password { get; set; } = null!;

            public bool Is_active { get; set; }


        }
    }
}
