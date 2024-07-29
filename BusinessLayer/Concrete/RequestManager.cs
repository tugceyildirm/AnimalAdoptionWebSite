using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RequestManager : IRequestService
    {
        IRequestDal _requestDal;
        public RequestManager(IRequestDal requestDal)
        {
            _requestDal = requestDal;
        }
        public void RequestAdd(Request request)
        {
            _requestDal.Insert(request);
        }

        public void RequestUpdate(Request request)
        {
            _requestDal.Update(request);
        }

        public void RequestDelete(Request request)
        {
            _requestDal.Delete(request);
        }

        public Request GetByID(int id)
        {
            return _requestDal.Get(x => x.RequestID == id);
        }

        public List<Request> GetAll()
        {
            return _requestDal.List();
        }
    }
}
