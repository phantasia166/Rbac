using System.Collections.Generic;

namespace Rbac.Model.Interface
{
    public interface IRbacRole<TRbacPermission> : IRbacModel
        where TRbacPermission : IRbacPermission
    {
        IList<TRbacPermission> Permissions { get; set; }
    }

    public interface IRbacRole : IRbacRole<RbacPermission>
    {

    }
}
