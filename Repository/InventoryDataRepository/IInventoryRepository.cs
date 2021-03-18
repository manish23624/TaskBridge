using DataViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.InventoryRepository
{
   public interface IInventoryRepository
    {
        List<InventoryModel> GetAllInventory();
        InventoryModel GetInventoryById(int id);
        bool InsertInventory(InventoryModel obj);

        bool UpdateInventory(InventoryModel obj);

        bool DeleteInventory(int id);
    }
}
