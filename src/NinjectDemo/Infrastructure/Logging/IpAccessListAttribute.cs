using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace NinjectDemo.Infrastructure.Logging
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IpAccessListAttribute : FilterAttribute, IAuthorizationFilter
    {
        public string[] IpList { get; set; }
        public string AppSettingsKey { get; set; }

        public bool CheckIp(string ip)
        {
            IpList = IpList ?? ((!string.IsNullOrEmpty(AppSettingsKey) && ConfigurationManager.AppSettings[AppSettingsKey] != null)
                ? ConfigurationManager.AppSettings[AppSettingsKey].Split(';')
                : new string[] { });
            return IpList.Contains(ip);
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var attr = (IpAccessListAttribute)filterContext.ActionDescriptor.GetCustomAttributes(typeof (IpAccessListAttribute), true).FirstOrDefault() 
                ?? (IpAccessListAttribute)filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(IpAccessListAttribute), true).FirstOrDefault();
            if (attr == null) return;
            if (!attr.CheckIp(filterContext.HttpContext.Request.UserHostAddress))
                filterContext.Result = new HttpUnauthorizedResult();

        }
    }
}