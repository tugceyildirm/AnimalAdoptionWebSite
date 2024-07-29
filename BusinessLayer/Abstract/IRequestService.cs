using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRequestService
    {
        void RequestAdd(Request request);
        void RequestUpdate(Request request);
        void RequestDelete(Request request);
        Request GetByID(int id);
        List<Request> GetAll();
    }
}
