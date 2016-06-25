using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Security;

namespace Auction.Providers
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; set; }
        public bool IsInRole(string role)
        {
            RoleProvider roleProvider = (RoleProvider)System.Web.Mvc.DependencyResolver.Current.GetService(typeof(RoleProvider));
            return roleProvider.IsUserInRole(Identity.Name,role);
        }
        public CustomPrincipal(string login)
        {
            this.Identity = new GenericIdentity(login);
        }
    }
}