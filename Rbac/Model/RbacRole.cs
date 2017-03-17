using Rbac.Model.Interface;
using System.Collections.Generic;

namespace Rbac.Model
{
    public class RbacRole<TRbacPermission> : RbacModelBase, IRbacRole<TRbacPermission>
        where TRbacPermission : IRbacPermission
    {
        public IList<TRbacPermission> Permissions { get; set; } = new List<TRbacPermission>();

        public RbacRole(string name) : base(name) { }
    }

    public class RbacRole : RbacRole<RbacPermission>
    {
        public RbacRole(string name) : base(name) { }
    }
}
