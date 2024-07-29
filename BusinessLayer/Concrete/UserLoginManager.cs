using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class UserLoginManager : IUserLoginService
    {
        ICustomerDal _customerDal;

        public UserLoginManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public Customer GetUser(string username, string password)
        {
           return _customerDal.Get(x => x.UserEmail == username && x.UserPassword == password);
        }
    }
}
