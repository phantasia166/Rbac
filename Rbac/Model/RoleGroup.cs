using Rbac.Model.Interface;
using System.Collections.Generic;

namespace Rbac.Model
{
    public class RoleGroup<TRbacRole, TRbacPermission> : RbacModelBase, IRoleGroup<TRbacRole, TRbacPermission>
        where TRbacRole : IRbacRole<TRbacPermission>
        where TRbacPermission : IRbacPermission
    {
        public IList<TRbacRole> Roles { get; set; } = new List<TRbacRole>();

        public RoleGroup(string name) : base(name) { }
    }

    public class RoleGroup : RoleGroup<RbacRole, RbacPermission>
    {
        public RoleGroup(string name) : base(name) { }
    }
}
