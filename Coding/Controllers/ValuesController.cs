using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Coding.Models;

namespace Coding.Controllers
{
    public class ValuesController : ApiController
    {
        private localdbEntities2 ld = new localdbEntities2();

        public IHttpActionResult GetAllUserInfo()
        {
            List<UsersModel> uModel = new List<UsersModel>();
            IList<UserIdModel> userid = ld.SelectAllUsers().Select(x => new UserIdModel()
            {
                userid = Convert.ToInt32(x)
            }).ToList<UserIdModel>();

            foreach (var y in userid)
            {
                IList<PaymentsModel> tlobj1 = ld.SelectUserPaymentList(y.userid.ToString()).Select(x => new PaymentsModel()
                {
                    date = x.date_created.ToString(),
                    amount = x.amount.ToString(),
                    status = x.payment_status
                }).ToList<PaymentsModel>();

                IList<UsersModel> tlobj = ld.SelectUserAccountBalance(y.userid.ToString()).Select(x => new UsersModel()
                {
                    accountBalance = x.ToString(),
                paymentList = tlobj1 as List<PaymentsModel>
                }).ToList<UsersModel>();

                foreach(var objmodel in tlobj)
                {
                    uModel.Add(objmodel);
                }
            }
           
            return Json(uModel);
        }
        public IHttpActionResult GetUserInfo(int id)
        {
            IList<PaymentsModel> tlobj1 = ld.SelectUserPaymentList(id.ToString()).Select(x => new PaymentsModel()
            {
                date = x.date_created.ToString(),
                amount = x.amount.ToString(),
                status = x.payment_status
            }).ToList<PaymentsModel>();

            IList<UsersModel> tlobj = ld.SelectUserAccountBalance(id.ToString()).Select(x => new UsersModel()
            {
                accountBalance = x.ToString(),
                paymentList = tlobj1 as List<PaymentsModel>
            }).ToList<UsersModel>();

            return Json(tlobj);
        }
    }
}
