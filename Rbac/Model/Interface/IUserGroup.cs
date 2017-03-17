using System.Collections.Generic;

namespace Rbac.Model.Interface
{
    public interface IUserGroup<TRbacUser, TRbacRole, TRbacPermission> : IRbacModel
        where TRbacUser : IRbacUser<TRbacRole, TRbacPermission>
        where TRbacRole : IRbacRole<TRbacPermission>
        where TRbacPermission : IRbacPermission
    {
        IList<TRbacUser> Users { get; set; }
    }
}
