using System.Collections.Generic;
using System.Security.Principal;

namespace Rbac.Model.Interface
{
    public interface IRbacUser<TRbacRole, TRbacPermission> : IPrincipal
        where TRbacRole : IRbacRole<TRbacPermission>
        where TRbacPermission : IRbacPermission
    {
        string UserName { get; set; }

        IList<TRbacRole> Roles { get; set; }

        IList<TRbacPermission> Permissions { get; set; }
    }

    public interface IRbacUser : IPrincipal
    {
        string UserName { get; set; }

        IList<string> Roles { get; set; }

        IList<string> Permissions { get; set; }
    }
}
