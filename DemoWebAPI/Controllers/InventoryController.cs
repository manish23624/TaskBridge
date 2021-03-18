using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataViewModel;
using Services.Inventory;

namespace RCMSWebAPI.Controllers
{
    [RoutePrefix("api/Inventory")]
    public class InventoryController : ApiController
    {
        IInventoryService _service;

        public InventoryController(IInventoryService service)
        {
            _service = service;
        }
        //[Authorize]
        [HttpPost]
        [Route("GetAllInventory")]
        public IHttpActionResult GetAllInventory()
        {
            try
            {
                return Ok(_service.GetAllInventory());
            }
            catch
            {
                return InternalServerError();
            }
        }
        //[Authorize]
        [HttpPost]
        [Route("GetInventoryById")]
        public IHttpActionResult GetInventoryById(int id)
        {
            try
            {
                return Ok(_service.GetInventoryById(id));
            }
            catch
            {
                return InternalServerError();
            }
        }
        //[Authorize]
        [HttpPost]
        [Route("InsertInventory")]
        public IHttpActionResult InsertInventory(InventoryModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(_service.InsertInventory(obj));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return InternalServerError();
            }
        }
        //[Authorize]
        [HttpPost]
        [Route("UpdateInventory")]
        public IHttpActionResult UpdateInventory(InventoryModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(_service.UpdateInventory(obj));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        [Route("DeleteInventory")]
        public IHttpActionResult DeleteInventory(int id)
        {
            try
            {

                return Ok(_service.DeleteInventory(id));
            }
            catch
            {
                return InternalServerError();
            }
        }
        
    }
}
