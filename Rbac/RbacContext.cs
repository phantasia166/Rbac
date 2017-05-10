using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rbac.Provider;
using Rbac.Model.Interface;

namespace Rbac
{
    /// <summary>
    /// Rbac Context 全泛型版本
    /// </summary>
    /// <typeparam name="TRbacUser">Rbac User</typeparam>
    /// <typeparam name="TRbacRole">Rbac Role</typeparam>
    /// <typeparam name="TRbacPermission">Rbac Permission</typeparam>
    /// <typeparam name="TUserGroup">User Group</typeparam>
    /// <typeparam name="TRoleGroup">Role Group</typeparam>
    public static class RbacContext<TRbacUser, TRbacRole, TRbacPermission, TUserGroup, TRoleGroup>
        where TRbacUser : class, IRbacUser<TRbacRole, TRbacPermission>
        where TRbacRole : class, IRbacRole<TRbacPermission>
        where TRbacPermission : class, IRbacPermission
        where TUserGroup : class, IUserGroup<TRbacUser, TRbacRole, TRbacPermission>
        where TRoleGroup : class, IRoleGroup<TRbacRole, TRbacPermission>
    {
        private static RbacUserProvider<TRbacUser, TRbacRole, TRbacPermission> _userProvider;
        public static bool HasUserProvider { get { return _userProvider != null; } }

        public static RbacUserGroupProvider<TUserGroup, TRbacUser, TRbacRole, TRbacPermission> UserGroupProvider { get; private set; }
        public static bool HasUserGroupProvider { get { return UserGroupProvider != null; } }

        public static RbacRoleProvider<TRbacRole, TRbacPermission> RoleProvider { get; private set; }
        public static bool HasRoleProvider { get { return RoleProvider != null; } }

        public static RbacRoleGroupProvider<TRoleGroup, TRbacRole, TRbacPermission> RoleGroupProvider { get; private set; }
        public static bool HasRoleGroupProvider { get { return RoleGroupProvider != null; } }

        public static RbacPermissionProvider<TRbacPermission> PermissionProvider { get; private set; }
        public static bool HasPermissionProvider { get { return PermissionProvider != null; } }

        public static void RegisterUserProvider(RbacUserProvider<TRbacUser, TRbacRole, TRbacPermission> provider)
        {
            _userProvider = provider;
        }

        public static void RegisterUserGroupProvider(RbacUserGroupProvider<TUserGroup, TRbacUser, TRbacRole, TRbacPermission> provider)
        {
            UserGroupProvider = provider;
        }

        public static void RegisterRoleProvider(RbacRoleProvider<TRbacRole, TRbacPermission> provider)
        {
            RoleProvider = provider;
        }

        public static void RegisterRoleGroupProvider(RbacRoleGroupProvider<TRoleGroup, TRbacRole, TRbacPermission> provider)
        {
            RoleGroupProvider = provider;
        }

        public static void RegisterPermissionProvider(RbacPermissionProvider<TRbacPermission> provider)
        {
            PermissionProvider = provider;
        }

        public static TRbacUser GetUser(string username)
        {
            if (_userProvider == null) return null;

            var user = _userProvider.GetUser(username);
            if (user == null) throw new Exception("Can not get a RBAC user from the provider!");

            if (HasRoleProvider) user.Roles = RoleProvider.GetUserRoles(username);
            if (HasPermissionProvider && user.Roles != null)
            {
                var permissions = PermissionProvider.GetRolePermissions(user.Roles.Select(p => p.Name).ToList());
                var userPermissions = PermissionProvider.GetUserPermissions(username);
                user.Permissions = permissions.Concat(userPermissions).Distinct().ToList();
            }

            return user;
        }
    }

    /// <summary>
    /// Rbac Context 用户泛型其他使用内置类型版本
    /// </summary>
    /// <typeparam name="TRbacUser">Rbac User</typeparam>
    public static class RbacContext<TRbacUser>
        where TRbacUser : class, IRbacUser
    {
        private static RbacUserProvider<TRbacUser> _userProvider;

        private static RbacRoleProvider _defaultRoleProvider;
        private static RbacPermissionProvider _defaultPermissionProvider;

        public static bool HasRoleProvider { get { return _defaultRoleProvider != null; } }
        public static bool HasPermissionProvider { get { return _defaultPermissionProvider != null; } }
        public static RbacUserGroupProvider UserGroupProvider { get; private set; }
        public static RbacRoleGroupProvider RoleGroupProvider { get; private set; }


        public static void RegisterUserProvider(RbacUserProvider<TRbacUser> provider)
        {
            _userProvider = provider;
        }

        public static void RegisterUserGroupProvider(RbacUserGroupProvider provider)
        {
            UserGroupProvider = provider;
        }

        public static void RegisterRoleProvider(RbacRoleProvider provider)
        {
            _defaultRoleProvider = provider;
        }

        public static void RegisterRoleGroupProvider(RbacRoleGroupProvider provider)
        {
            RoleGroupProvider = provider;
        }

        public static void RegisterPermissionProvider(RbacPermissionProvider provider)
        {
            _defaultPermissionProvider = provider;
        }

        public static TRbacUser GetUser(string username)
        {
            if (_userProvider == null) return null;

            var user = _userProvider.GetUser(username);
            if (user == null) throw new Exception("Can not get a RBAC user from the provider!");

            if (HasRoleProvider) user.Roles = _defaultRoleProvider.GetUserRoles(username);
            if (HasPermissionProvider && user.Roles != null)
            {
                var permissions = _defaultPermissionProvider.GetRolePermissions(user.Roles);
                var userPermissions = _defaultPermissionProvider.GetUserPermissions(username);
                user.Permissions = permissions.Concat(userPermissions).Distinct().ToList();
            }

            return user;
        }
    }
}
