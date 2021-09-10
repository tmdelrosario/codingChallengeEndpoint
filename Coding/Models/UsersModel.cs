using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coding.Models
{
    public class UsersModel
    {
        public string accountBalance { get; set; }
        public List<PaymentsModel> paymentList { get; set; }
    }
}