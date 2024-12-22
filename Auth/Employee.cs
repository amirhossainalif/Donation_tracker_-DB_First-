using Donation_Tracker.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Donation_Tracker.Auth
{
    public class Employee : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (Login)httpContext.Session["user"];
            if (user != null && user.UserType.Equals("Employee"))
            {
                return true;
            }
            return false;
        }
    }
}