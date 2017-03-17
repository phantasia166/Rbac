using Rbac.Model.Interface;
using System.Collections.Generic;

namespace Rbac.Provider.Interface
{
    public interface IRbacRoleProvider<TRbacRole, TRbacPermission>
        where TRbacRole : IRbacRole<TRbacPermission>
        where TRbacPermission : IRbacPermission
    {
        IList<TRbacRole> GetUserRoles(string username);

        bool IsUserInRole(string username, string roleName);
    }

    public interface IRbacRoleProvider
    {
        IList<string> GetUserRoles(string username);

        bool IsUserInRole(string username, string roleName);
    }
}
