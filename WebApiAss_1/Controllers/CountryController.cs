using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WebApiAss_1.Models;

//1.Create a Model called Country under Models Folder.
//2. Add Properties in the country model as 
//   ID, CountryName, Capital

//3. Create an Empty api controller called Country

//4. Perform CRUD operations using either (HTTPResponseMessage / IHttpActionResult / others) and show the changes to the user

namespace WebApiAss_1.Controllers
{
    public class CountryController : ApiController
    {
        static List<Country> Countrylist = new List<Country>()  //Sample Values
        {
            new Country{id = 1,CountryName = "India",Capital ="Delhi"},
              new Country{id = 2,CountryName = "Pakistan",Capital ="Islamabad"},
                new Country{id = 3,CountryName = "Russia",Capital ="Moscow"},

        };



        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, Countrylist);
            return response;
        }

  
        public IHttpActionResult Get(int pid) //Read
        {
            var val = Countrylist.Where(x => x.id == pid).SingleOrDefault()?.CountryName;
            if (val == null)
            {
                return NotFound();
            }
            return Ok(val);
        }

        public IHttpActionResult Post([FromBody] Country c) // create
        {
            Countrylist.Add(c);
            return Ok(Countrylist);
        }

        public IHttpActionResult Put(int id, [FromBody] Country c) //update
        {
            var Countryval = Countrylist.Find(a => a.id == id);
            if (Countryval != null)
            {
                Countrylist[id - 1] = c;
                return Ok(Countrylist);
            }
            else
            {
                return NotFound();
            }
        }
        public IHttpActionResult Delete(int id) //delete
        {
            var Countryval = Countrylist.Find(a => a.id == id);
            if (Countryval != null)
            {
                Countrylist.RemoveAt(id - 1);
                return Ok(Countrylist);

            }
            else
            {
                return NotFound();
            }

        }
    }
}
