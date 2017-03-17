using Rbac.Model.Interface;
using Rbac.Provider.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Provider
{
    public class RbacUserGroupProvider<TUserGroup, TRbacUser, TRbacRole, TRbacPermission> : IRbacUserGroupProvider<TUserGroup, TRbacUser, TRbacRole, TRbacPermission>
        where TUserGroup : IUserGroup<TRbacUser, TRbacRole, TRbacPermission>
        where TRbacUser : IRbacUser<TRbacRole, TRbacPermission>
        where TRbacRole : IRbacRole<TRbacPermission>
        where TRbacPermission : IRbacPermission
    {
        private Func<string, IList<TUserGroup>> _getUserGroups;
        private Func<string, string, bool> _isUserInGroup;

        public RbacUserGroupProvider(Func<string, IList<TUserGroup>> getUserGroups, Func<string, string, bool> isUserInGroup)
        {
            _getUserGroups = getUserGroups;
            _isUserInGroup = isUserInGroup;
        }

        public IList<TUserGroup> GetUserGroups(string username)
        {
            return _getUserGroups(username);
        }

        public bool IsUserInGroup(string username, string groupName)
        {
            return _isUserInGroup(username, groupName);
        }
    }

    public class RbacUserGroupProvider : IRbacUserGroupProvider
    {
        private Func<string, IList<string>> _getUserGroups;
        private Func<string, string, bool> _isUserInGroup;

        public RbacUserGroupProvider(Func<string, IList<string>> getUserGroups, Func<string, string, bool> isUserInGroup)
        {
            _getUserGroups = getUserGroups;
            _isUserInGroup = isUserInGroup;
        }

        public IList<string> GetUserGroups(string username)
        {
            return _getUserGroups(username);
        }

        public bool IsUserInGroup(string username, string groupName)
        {
            return _isUserInGroup(username, groupName);
        }
    }
}
