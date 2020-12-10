using CMS_HERA_MVC.Data;
using CMS_HERA_MVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_HERA_MVC.Models;

namespace CMS_HERA_MVC.Repository
{
    public interface IRole
    {
        IEnumerable<Role> GetAllRole();
        Role GetRoleById(int? roleId);
        int? AddRole(Role role);
        int? UpdateRole(Role role);
        void DeleteRole(int? id_role);
        bool CheckRoleNameExists(string titre_role);
        IQueryable<Role> ShowAllRole(string sortColumn, string sortColumnDir, string search);
        List<Role> GetAllActiveRoles();
        //int? UpdateRoleStatus(ViewMenuRoleStatusUpdateModel vmrolemodel);
    }
}
