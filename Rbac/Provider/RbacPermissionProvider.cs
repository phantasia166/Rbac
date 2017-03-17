using Rbac.Model.Interface;
using Rbac.Provider.Interface;
using System;
using System.Collections.Generic;

namespace Rbac.Provider
{
    public class RbacPermissionProvider<TRbacPermission> : IRbacPermissionProvider<TRbacPermission>
        where TRbacPermission : IRbacPermission
    {
        private Func<IList<string>, IList<TRbacPermission>> _getRolesPermissions;
        private Func<string, string, bool> _isRoleGrantedPermission;
        private Func<string, IList<TRbacPermission>> _getUserPermissions;
        private Func<string, string, bool> _isUserGrantedPermission;
        private Func<string, IList<TRbacPermission>> _getRolePermissions;

        public RbacPermissionProvider(
            Func<IList<string>, IList<TRbacPermission>> getRolesPermissions,
            Func<string, string, bool> isRoleGrantedPermission,
            Func<string, IList<TRbacPermission>> getUserPermissions = null,
            Func<string, string, bool> isUserGrantedPermission = null,
            Func<string, IList<TRbacPermission>> getRolePermissions = null
            )
        {
            _getUserPermissions = getUserPermissions;
            _getRolesPermissions = getRolesPermissions;
            _isUserGrantedPermission = isUserGrantedPermission;
            _isRoleGrantedPermission = isRoleGrantedPermission;
            _getRolePermissions = getRolePermissions;
        }

        public IList<TRbacPermission> GetRolePermissions(string roleName)
        {
            return _getRolePermissions != null ? _getRolePermissions(roleName) : _getRolesPermissions(new List<string> { roleName });
        }

        public IList<TRbacPermission> GetRolePermissions(IList<string> roleNames)
        {
            return _getRolesPermissions(roleNames);
        }

        public bool IsRoleGranted(string roleName, string permissionName)
        {
            return _isRoleGrantedPermission(roleName, permissionName);
        }

        public IList<TRbacPermission> GetUserPermissions(string username)
        {
            return _getUserPermissions(username);
        }

        public bool IsUserGranted(string username, string permissionName)
        {
            return _isUserGrantedPermission(username, permissionName);
        }
    }

    public class RbacPermissionProvider : IRbacPermissionProvider
    {
        private Func<IList<string>, IList<string>> _getRolesPermissions;
        private Func<string, string, bool> _isRoleGrantedPermission;
        private Func<string, IList<string>> _getUserPermissions;
        private Func<string, string, bool> _isUserGrantedPermission;
        private Func<string, IList<string>> _getRolePermissions;

        public RbacPermissionProvider(
            Func<IList<string>, IList<string>> getRolesPermissions,
            Func<string, string, bool> isRoleGrantedPermission,
            Func<string, IList<string>> getUserPermissions = null,
            Func<string, string, bool> isUserGrantedPermission = null,
            Func<string, IList<string>> getRolePermissions = null
            )
        {
            _getRolesPermissions = getRolesPermissions;
            _isUserGrantedPermission = isUserGrantedPermission;
            _isRoleGrantedPermission = isRoleGrantedPermission;
            _getUserPermissions = getUserPermissions;
            _getRolePermissions = getRolePermissions;
        }

        public IList<string> GetRolePermissions(string roleName)
        {
            return _getRolePermissions(roleName);
        }

        public IList<string> GetRolePermissions(IList<string> roleNames)
        {
            return _getRolesPermissions(roleNames);
        }

        public bool IsRoleGranted(string roleName, string permissionName)
        {
            return _isRoleGrantedPermission(roleName, permissionName);
        }

        public IList<string> GetUserPermissions(string username)
        {
            return _getUserPermissions(username);
        }

        public bool IsUserGranted(string username, string permissionName)
        {
            return _isUserGrantedPermission(username, permissionName);
        }
    }
}
