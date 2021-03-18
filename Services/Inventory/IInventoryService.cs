using System;
using System.Collections.Generic;
using System.Text;
using DataViewModel;
namespace Services.Inventory
{
   public interface IInventoryService
    {
        List<InventoryModel> GetAllInventory();
        InventoryModel GetInventoryById(int id);
        bool InsertInventory(InventoryModel obj);

        bool UpdateInventory(InventoryModel obj);

        bool DeleteInventory(int id);
    }
}
