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
        private localdbEntities1 ld = new localdbEntities1();

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
