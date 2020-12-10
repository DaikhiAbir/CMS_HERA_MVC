//using System;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Data;
//using System.Data.Entity;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using CMS_HERA_MVC.Models;
//using CMS_HERA_MVC.Repository;


//namespace ManageRoles.Repository
//{
//    public class RoleRepository : IRole
//    {
//        //private readonly DatabaseContext _context;
//        private bool _disposed = false;

//        //public RoleRepository(DatabaseContext context)
//        //{
//        //    _context = context;
//        //}

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!this._disposed)
//            {
//                if (disposing)
//                {
//                    //_context.Dispose();
//                }
//            }
//            this._disposed = true;
//        }

//        public void Dispose()
//        {
//            Dispose(true);

//            GC.SuppressFinalize(this);
//        }
//        public int? AddRoleMaster(Role role)
//        {
//            try
//            {
//                int? result = -1;
//                if (role != null)
//                {
//                    //role.CreateDate = DateTime.Now;
//                    //_context.RoleMasters.Add(role);
//                    //_context.SaveChanges();
//                    //result = role.id_role;
//                }
//                return result;
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

//        //public bool CheckRoleNameExists(string roleName)
//        //{
//        //    try
//        //    {
//        //        //var result = (from role in _context.Role
//        //        //              where role.titre_role == titre_role
//        //        //              select role).Any();

//        //        return result;
//        //    }
//        //    catch (Exception)
//        //    {
//        //        throw;
//        //    }
//        //}

//        public void DeleteRole(int? roleId)
//        {
//            try
//            {
//                Role roleMaster = _context.RoleMasters.Find(roleId);
//                if (roleMaster != null) _context.RoleMasters.Remove(roleMaster);
//                _context.SaveChanges();
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

//        public IEnumerable<Role> GetAllRole()
//        {
//            try
//            {
//                return _context.RoleMasters.ToList();
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

//        public Role GetRoleById(int? roleId)
//        {
//            try
//            {
//                return _context.RoleMasters.Find(roleId);
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

//        public IQueryable<Role> ShowAllRoleMaster(string sortColumn, string sortColumnDir, string search)
//        {
//            try
//            {
//                var queryablesRoleMasters = (from roleMaster in _context.RoleMasters
//                                             select roleMaster);

//                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
//                {
//                    queryablesRoleMasters = queryablesRoleMasters.OrderBy(sortColumn + " " + sortColumnDir);
//                }
//                if (!string.IsNullOrEmpty(search))
//                {
//                    queryablesRoleMasters = queryablesRoleMasters.Where(m => m.RoleName.Contains(search) || m.RoleName.Contains(search));
//                }

//                return queryablesRoleMasters;

//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public int? UpdateRole(Role roleMaster)
//        {
//            try
//            {
//                int? result = -1;

//                if (roleMaster != null)
//                {
//                    roleMaster.CreateDate = DateTime.Now;
//                    _context.Entry(roleMaster).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
//                    _context.SaveChanges();
//                    result = roleMaster.id_role;
//                }
//                return result;
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

//        public List<Role> GetAllActiveRoles()
//        {
//            try
//            {
//                var listofActiveMenu = (from roleMaster in _context.RoleMasters
//                                        where roleMaster.Status == true
//                                        select roleMaster).ToList();

//                listofActiveMenu.Insert(0, new Role()
//                {
//                    id_role = -1,
//                    titre_role = "---Select---"
//                });

//                return listofActiveMenu;
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }

//        public int? UpdateRoleStatus(ViewMenuRoleStatusUpdateModel vmrolemodel)
//        {
//            try
//            {
//                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString))
//                {
//                    con.Open();
//                    SqlTransaction trans = con.BeginTransaction();
//                    var param = new DynamicParameters();
//                    param.Add("@Status", vmrolemodel.Status);
//                    param.Add("@SavedMenuRoleId", vmrolemodel.SaveId);
//                    var result = con.Execute("Usp_UpdateRoleStatus", param, trans, 0, CommandType.StoredProcedure);
//                    if (result > 0)
//                    {
//                        trans.Commit();
//                    }
//                    else
//                    {
//                        trans.Rollback();
//                    }

//                    return result;
//                }
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public int? UpdateSubMenuRoleStatus(ViewSubMenuRoleStatusUpdateModel vmrolemodel)
//        {
//            try
//            {
//                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString))
//                {
//                    con.Open();
//                    SqlTransaction trans = con.BeginTransaction();
//                    var param = new DynamicParameters();
//                    param.Add("@Status", vmrolemodel.Status);
//                    param.Add("@SavedSubMenuRoleId", vmrolemodel.SaveId);
//                    var result = con.Execute("UpdateSubMenuRoleStatus", param, trans, 0, CommandType.StoredProcedure);
//                    if (result > 0)
//                    {
//                        trans.Commit();
//                    }
//                    else
//                    {
//                        trans.Rollback();
//                    }

//                    return result;
//                }
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }
//}
