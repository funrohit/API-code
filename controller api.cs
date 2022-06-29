using Api1.dbdata;
using Api1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api1.Controllers
{
    public class mycontroller : ApiController    //api C
    {

       [HttpGet]
        [Route("emp/data")]
        public List<mydata> Getemp()   
        { 

            forapiEntities database = new forapiEntities();

              List<mymodel> mm = new List<mymodel>();

         var res = database.mydatas.ToList();


            return res;
        }


        [HttpPost]   // action verbs
        [Route("add/data")]    // proving route
        public HttpResponseMessage fun(mydata obj)     
        {
            forapiEntities database = new forapiEntities(); 

           mydata tt = new mydata();    

            if (obj.id == 0)
                {
                database.mydatas.Add(obj);
                database.SaveChanges();
            }
            else
            {
                database.Entry(obj).State= System.Data.Entity.EntityState.Modified;
                database.SaveChanges();

            }

            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);

            return res;
        }
 
    }
}






///////////////////////////////////////////GET PUT POST DELETE==========================================

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LinkPureAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class superherosController : ControllerBase
    {

        //Global
        public static List<superhero> heros = new List<superhero>()
        {
          new superhero
          {
              id= 0,
              name =null,
              FirstName =null,
              LastName =null,
              Place=null
          },
            new superhero
          {
              id= 100,
              name ="Avenger",
              FirstName ="tony",
              LastName ="stark",
              Place="USA"
          }

        };
      

       [HttpGet]
       [Route("get/data")]
        public async Task<IActionResult> Get()
        {
        
            return Ok(heros);
        }


        [HttpPost]
        public async Task<IActionResult> Post(superhero obj)
        {
            heros.Add(obj);

            return Ok(heros);
        }
        


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var res= heros.Where(i=>i.id==id).FirstOrDefault();
                
            if(res==null)
            {
                return BadRequest("Data is not found");
            }
            else
            {
                heros.Remove(res);
            }

                    return Ok("Data is deleted!");
        }

        [HttpPut]
        public async Task<IActionResult> Put(superhero oo)
        {
            var res = heros.Where(i=>i.id == oo.id).FirstOrDefault();

            if(res == null)
            {
                return BadRequest("Invalid data");
            }
            else
            {
                res.id = oo.id; 
                res.name = oo.name;
                res.FirstName = oo.FirstName;
                res.LastName = oo.LastName;
                res.Place = oo.Place;   

                heros.Add(res);
            }

            return Ok(heros);

        }
                 
        
    }
}
