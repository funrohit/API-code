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
