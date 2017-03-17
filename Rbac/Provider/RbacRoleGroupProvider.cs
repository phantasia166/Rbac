using Rbac.Model.Interface;
using Rbac.Provider.Interface;
using System;
using System.Collections.Generic;

namespace Rbac.Provider
{
    public class RbacRoleGroupProvider<TRoleGroup, TRbacRole, TRbacPermission> : IRbacRoleGroupProvider<TRoleGroup, TRbacRole, TRbacPermission>
        where TRoleGroup : IRoleGroup<TRbacRole, TRbacPermission>
        where TRbacRole : IRbacRole<TRbacPermission>
        where TRbacPermission : IRbacPermission
    {
        private Func<string, IList<TRoleGroup>> _getRoleGroups;
        private Func<string, IList<TRbacRole>> _getGroupRoles;
        private Func<string, string, bool> _isRoleInGroup;

        public RbacRoleGroupProvider(Func<string, IList<TRoleGroup>> getRoleGroups, Func<string, IList<TRbacRole>> getGroupRoles, Func<string, string, bool> isRoleInGroup)
        {
            _getRoleGroups = getRoleGroups;
            _getGroupRoles = getGroupRoles;
            _isRoleInGroup = isRoleInGroup;
        }

        public IList<TRoleGroup> GetRoleGroups(string roleName)
        {
            return _getRoleGroups(roleName);
        }

        public IList<TRbacRole> GetGroupRoles(string groupName)
        {
            return _getGroupRoles(groupName);
        }

        public bool IsRoleInGroup(string roleName, string groupName)
        {
            return _isRoleInGroup(roleName, groupName);
        }
    }

    public class RbacRoleGroupProvider : IRbacRoleGroupProvider
    {
        private Func<string, IList<string>> _getRoleGroups;
        private Func<string, IList<string>> _getGroupRoles;
        private Func<string, string, bool> _isRoleInGroup;

        public RbacRoleGroupProvider(Func<string, IList<string>> getRoleGroups, Func<string, IList<string>> getGroupRoles, Func<string, string, bool> isRoleInGroup)
        {
            _getRoleGroups = getRoleGroups;
            _getGroupRoles = getGroupRoles;
            _isRoleInGroup = isRoleInGroup;
        }

        public IList<string> GetGroupRoles(string groupName)
        {
            return _getGroupRoles(groupName);
        }

        public IList<string> GetRoleGroups(string roleName)
        {
            return _getRoleGroups(roleName);
        }

        public bool IsRoleInGroup(string roleName, string groupName)
        {
            return _isRoleInGroup(roleName, groupName);
        }
    }
}
