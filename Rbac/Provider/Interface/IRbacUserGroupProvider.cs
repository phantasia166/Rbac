using Rbac.Model.Interface;
using System.Collections.Generic;

namespace Rbac.Provider.Interface
{
    public interface IRbacUserGroupProvider<TUserGroup, TRbacUser, TRbacRole, TRbacPermission>
        where TUserGroup : IUserGroup<TRbacUser, TRbacRole, TRbacPermission>
        where TRbacUser : IRbacUser<TRbacRole, TRbacPermission>
        where TRbacRole : IRbacRole<TRbacPermission>
        where TRbacPermission : IRbacPermission
    {
        IList<TUserGroup> GetUserGroups(string username);

        bool IsUserInGroup(string username, string groupName);
    }

    public interface IRbacUserGroupProvider
    {
        IList<string> GetUserGroups(string username);

        bool IsUserInGroup(string username, string groupName);
    }
}
