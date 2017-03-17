using Rbac.Model.Interface;
using System.Collections.Generic;

namespace Rbac.Provider.Interface
{
    public interface IRbacPermissionProvider<TRbacPermission>
        where TRbacPermission : IRbacPermission
    {
        IList<TRbacPermission> GetRolePermissions(string roleName);

        IList<TRbacPermission> GetRolePermissions(IList<string> roleNames);

        bool IsRoleGranted(string roleName, string permissionName);

        IList<TRbacPermission> GetUserPermissions(string username);

        bool IsUserGranted(string username, string permissionName);
    }

    public interface IRbacPermissionProvider
    {
        IList<string> GetRolePermissions(string roleName);

        IList<string> GetRolePermissions(IList<string> roleNames);

        bool IsRoleGranted(string roleName, string permissionName);

        IList<string> GetUserPermissions(string username);

        bool IsUserGranted(string username, string permissionName);
    }
}
