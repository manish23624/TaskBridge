using System;
using System.Collections.Generic;
using System.Text;
using DataViewModel;

using Repository.InventoryRepository;

namespace Services.Inventory
{
    public class InventoryService : IInventoryService
    {
        IInventoryRepository _Repository;

        public InventoryService(IInventoryRepository repository)
        {
            _Repository = repository;
        }
       public List<InventoryModel> GetAllInventory()
        {
            return _Repository.GetAllInventory();
        }
        public InventoryModel GetInventoryById(int id)
        {
            return _Repository.GetInventoryById(id);
        }
        public bool InsertInventory(InventoryModel obj)
        {
            return _Repository.InsertInventory(obj);
        }

        public bool UpdateInventory(InventoryModel obj)
        {
            return _Repository.UpdateInventory(obj);
        }
        public bool DeleteInventory(int id)
        {
            return _Repository.DeleteInventory(id);
        }
       
    }
}
