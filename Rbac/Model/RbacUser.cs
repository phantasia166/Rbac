using Rbac.Model.Interface;
using System.Collections.Generic;
using System.Security.Principal;
using System.Linq;

namespace Rbac.Model
{
    public class RbacUser : IRbacUser<RbacRole, RbacPermission>
    {
        public string UserName { get; set; }

        public IList<RbacRole> Roles { get; set; } = new List<RbacRole>();

        public IList<RbacPermission> Permissions { get; set; } = new List<RbacPermission>();

        public IIdentity Identity { get; }

        public RbacUser(string username)
        {
            UserName = username;
        }

        public bool IsInRole(string role)
        {
            return Roles.Any(p => p.Name == role);
        }
    }
}
