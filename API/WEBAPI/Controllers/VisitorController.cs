using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WEBAPI.DAL.Context;
using WEBAPI.DAL.Entities;

namespace WEBAPI.Controllers
{

    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {

        [HttpGet]
        [Route("GetVisitor")]
        public IActionResult GetVisitorList()
        {
            var data = new List<DAL.Entities.Visitor>() ;
            using(var context = new VisitorContext())
            {
                 data = context.Visitors.ToList();
            }
            return Ok(data);
        }

        [HttpGet]
        [Route("GetVisitor/{id}")]
        public IActionResult GetVisitor(int id)
        {
            var data = new DAL.Entities.Visitor();
            using (var context = new VisitorContext())
            {
                data = context.Visitors.Where(x => x.VisitorID == id).FirstOrDefault();
            }
            return Ok(data);
        }

        [HttpPost]
        [Route("AddVisitor")]
        public IActionResult AddVisitor(Visitor model)
        {
            using(var context = new VisitorContext())
            {
                context.Visitors.Add(model);
                context.SaveChanges();
            }  
            return Ok(model);   
        }


        [HttpPost]
        [Route("UpdateVisitor")]
        public IActionResult UpdateVisitor(Visitor model)
        {
            using (var context = new VisitorContext())
            {
                context.Visitors.Update(model);
                context.SaveChanges();
            }
            return Ok(model);
        }


        [HttpDelete]
        [Route("DeleteVisitor/{id}")]
        public IActionResult DeleteVisitor(int id)
        {
            using (var context = new VisitorContext())
            {
                var model = context.Visitors.Where(x => x.VisitorID == id).FirstOrDefault();
                context.Visitors.Remove(model); 
                context.SaveChanges();
            }
            return Ok();
        }

    }
}
