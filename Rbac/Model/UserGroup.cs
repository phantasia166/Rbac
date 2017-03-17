using Rbac.Model.Interface;
using System.Collections.Generic;

namespace Rbac.Model
{
    public class UserGroup<TRbacUser, TRbacRole, TRbacPermission> : RbacModelBase, IUserGroup<TRbacUser, TRbacRole, TRbacPermission>
        where TRbacUser : IRbacUser<TRbacRole, TRbacPermission>
        where TRbacRole : IRbacRole<TRbacPermission>
        where TRbacPermission : IRbacPermission
    {
        public IList<TRbacUser> Users { get; set; } = new List<TRbacUser>();

        public UserGroup(string name) : base(name) { }
    }

    public class UserGroup : UserGroup<RbacUser, RbacRole, RbacPermission>
    {
        public UserGroup(string name) : base(name) { }
    }
}
