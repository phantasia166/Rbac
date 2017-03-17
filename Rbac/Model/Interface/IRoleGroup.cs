using System.Collections.Generic;

namespace Rbac.Model.Interface
{
    public interface IRoleGroup<TRbacRole, TRbacPermission> : IRbacModel
        where TRbacRole : IRbacRole<TRbacPermission>
        where TRbacPermission : IRbacPermission
    {
        IList<TRbacRole> Roles { get; set; }
    }
}
