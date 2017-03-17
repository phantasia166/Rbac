using Rbac.Model.Interface;
using Rbac.Provider.Interface;
using System;
using System.Collections.Generic;

namespace Rbac.Provider
{
    public class RbacRoleProvider<TRbacRole, TRbacPermission> : IRbacRoleProvider<TRbacRole, TRbacPermission>
        where TRbacRole : IRbacRole<TRbacPermission>
        where TRbacPermission : IRbacPermission
    {
        private Func<string, IList<TRbacRole>> _getUserRoles;
        private Func<string, string, bool> _isUserInRole;

        public RbacRoleProvider(Func<string, IList<TRbacRole>> getUserRoles, Func<string, string, bool> isUserInRole)
        {
            _getUserRoles = getUserRoles;
            _isUserInRole = isUserInRole;
        }

        public IList<TRbacRole> GetUserRoles(string username)
        {
            return _getUserRoles(username);
        }

        public bool IsUserInRole(string username, string roleName)
        {
            return _isUserInRole(username, roleName);
        }
    }

    public class RbacRoleProvider : IRbacRoleProvider
    {
        private Func<string, IList<string>> _getUserRoles;
        private Func<string, string, bool> _isUserInRole;

        public RbacRoleProvider(Func<string, IList<string>> getUserRoles, Func<string, string, bool> isUserInRole)
        {
            _getUserRoles = getUserRoles;
            _isUserInRole = isUserInRole;
        }

        public IList<string> GetUserRoles(string username)
        {
            return _getUserRoles(username);
        }

        public bool IsUserInRole(string username, string roleName)
        {
            return _isUserInRole(username, roleName);
        }
    }
}
