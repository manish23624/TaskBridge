using DataViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.InventoryRepository
{
   public class InventoryRepository : IInventoryRepository
    {
        public bool InsertInventory(InventoryModel obj)
        {
            try
            {
                List<SqlParameter> Prm = new List<SqlParameter>();
                Prm.Add(new SqlParameter("@Name", obj.Name));
                Prm.Add(new SqlParameter("@Description", obj.Description));
                Prm.Add(new SqlParameter("@Price", obj.Price));
                SqlHelper.ExecuteDataset(SqlHelper.DBConn, CommandType.StoredProcedure, "InsertInventory", Prm.ToArray());
                return true;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
       
        public bool UpdateInventory(InventoryModel obj)
        {

            try
            {
                
                List<SqlParameter> Prm = new List<SqlParameter>();
                Prm.Add(new SqlParameter("@Id", obj.Id));
                Prm.Add(new SqlParameter("@Name", obj.Name));
                Prm.Add(new SqlParameter("@Description", obj.Description));
                Prm.Add(new SqlParameter("@Price", obj.Price));
               SqlHelper.ExecuteDataset(SqlHelper.DBConn, CommandType.StoredProcedure, "UpdateInventory", Prm.ToArray());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public List<InventoryModel> GetAllInventory()
        {

            List<InventoryModel> Inventory = new List<InventoryModel>();
            try
            {
                DataSet dst;

                dst = SqlHelper.ExecuteDataset(SqlHelper.DBConn, CommandType.StoredProcedure, "GetInventory");
                if (dst.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dst.Tables[0].Rows.Count; i++)
                    {
                        InventoryModel obj = new InventoryModel();
                        obj.Id = Convert.ToInt32(dst.Tables[0].Rows[i]["Id"].ToString());
                        obj.Name = dst.Tables[0].Rows[i]["Name"].ToString();
                        obj.Description = dst.Tables[0].Rows[i]["Description"].ToString();
                        obj.Price = Convert.ToDouble(dst.Tables[0].Rows[i]["Price"].ToString());
                        obj.CreatedDate = Convert.ToDateTime(dst.Tables[0].Rows[i]["CreatedDate"].ToString());
                        Inventory.Add(obj);
                    }
                }
                return Inventory;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public InventoryModel GetInventoryById(int id)
        {
            try
            {
                InventoryModel obj = new InventoryModel();
            DataSet dst;
            List<SqlParameter> Prm = new List<SqlParameter>();
            Prm.Add(new SqlParameter("@Id", id));
            dst = SqlHelper.ExecuteDataset(SqlHelper.DBConn, CommandType.StoredProcedure, "GetInventoryById", Prm.ToArray());
            if (dst.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dst.Tables[0].Rows.Count; i++)
                {
                   
                    obj.Id = Convert.ToInt32(dst.Tables[0].Rows[i]["Id"].ToString());
                    obj.Name = dst.Tables[0].Rows[i]["Name"].ToString();
                    obj.Description = dst.Tables[0].Rows[i]["Description"].ToString();
                        obj.Price = Convert.ToDouble(dst.Tables[0].Rows[i]["Price"].ToString());
                        obj.CreatedDate = Convert.ToDateTime(dst.Tables[0].Rows[i]["CreatedDate"].ToString());
                }
            }
            return obj;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool DeleteInventory(int id)
        {
            try
            {
                List<SqlParameter> Prm = new List<SqlParameter>();
            Prm.Add(new SqlParameter("@Id", id));
            SqlHelper.ExecuteDataset(SqlHelper.DBConn, CommandType.StoredProcedure, "DeleteInventoryById", Prm.ToArray());
            
            return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

      
    }
}
