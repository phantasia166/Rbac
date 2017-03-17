using Rbac.Model.Interface;

namespace Rbac.Provider.Interface
{
    public interface IRbacUserProvider<TRbacUser, TRbacRole, TRbacPermission>
        where TRbacUser : IRbacUser<TRbacRole, TRbacPermission>
        where TRbacRole : IRbacRole<TRbacPermission>
        where TRbacPermission : IRbacPermission
    {
        TRbacUser GetUser(string username);
    }

    public interface IRbacUserProvider<TRbacUser>
        where TRbacUser : IRbacUser
    {
        TRbacUser GetUser(string username);
    }
}
