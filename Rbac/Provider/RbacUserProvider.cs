using Rbac.Model;
using Rbac.Model.Interface;
using Rbac.Provider.Interface;
using System;

namespace Rbac.Provider
{
    public class RbacUserProvider<TRbacUser, TRbacRole, TRbacPermission> : IRbacUserProvider<TRbacUser, TRbacRole, TRbacPermission>
        where TRbacUser : IRbacUser<TRbacRole, TRbacPermission>
        where TRbacRole : IRbacRole<TRbacPermission>
        where TRbacPermission : IRbacPermission
    {
        private Func<string, TRbacUser> _getUser;

        public RbacUserProvider(Func<string, TRbacUser> getUser)
        {
            _getUser = getUser;
        }

        public TRbacUser GetUser(string username)
        {
            return _getUser(username);
        }
    }

    public class RbacUserProvider<TRbacUser> : IRbacUserProvider<TRbacUser>
        where TRbacUser : IRbacUser
    {
        private Func<string, TRbacUser> _getUser;

        public RbacUserProvider(Func<string, TRbacUser> getUser)
        {
            _getUser = getUser;
        }

        public TRbacUser GetUser(string username)
        {
            return _getUser(username);
        }
    }

    public class RbacUserProvider : RbacUserProvider<RbacUser, RbacRole, RbacPermission>
    {
        public RbacUserProvider(Func<string, RbacUser> getUser) : base(getUser)
        {
        }
    }
}
