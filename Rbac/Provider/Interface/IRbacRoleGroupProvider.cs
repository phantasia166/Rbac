using Rbac.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rbac.Provider.Interface
{
    public interface IRbacRoleGroupProvider<TRoleGroup, TRbacRole, TRbacPermission>
        where TRoleGroup : IRoleGroup<TRbacRole, TRbacPermission>
        where TRbacRole : IRbacRole<TRbacPermission>
        where TRbacPermission : IRbacPermission
    {
        IList<TRoleGroup> GetRoleGroups(string roleName);

        IList<TRbacRole> GetGroupRoles(string groupName);

        bool IsRoleInGroup(string roleName, string groupName);
    }

    public interface IRbacRoleGroupProvider
    {
        IList<string> GetRoleGroups(string roleName);

        IList<string> GetGroupRoles(string groupName);

        bool IsRoleInGroup(string roleName, string groupName);
    }
}
