using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Database;
using WebApplication5.Database.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    public class MyDBController : Controller
    {
        private MobileContext db;

        public MyDBController(MobileContext context)
        {
            this.db = context;
        }   


        // GET: api/<controller>
        [HttpGet]
        public ArrayList Get()
        {
            var res = new ArrayList();
            IEnumerable<Phone> phones= this.db.Phones.ToList();
            foreach (var phone in phones)
            {
                res.Add(new { phone.Company, phone.Name, phone.Price });
            }

            return res;
        }

        // POST api/<controller>
        [HttpPost]
        public string Post(string name)
        {
            var phone = new Phone() {Company = "Samsung", Name = name, Price = 1990};
            try
            {
                this.db.Phones.Add(phone);
                this.db.SaveChanges();
                return "OKAY";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
                return "HUEVA";
            }                    
        }


        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
