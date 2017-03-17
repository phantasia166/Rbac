using Rbac.Model.Interface;

namespace Rbac.Model
{
    public class RbacPermission : RbacModelBase, IRbacPermission
    {
        public RbacPermission(string name) : base(name) { }
    }
}
