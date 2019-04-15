using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;

namespace ExerceoBitcamp2019.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IConfiguration _iconfig = null;
        public ValuesController (IConfiguration config)
        {
            _iconfig = config;
        }
        // GET api/values 
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var query = "select * from Enroll";
            using (SqlConnection conn = new SqlConnection(_iconfig.GetSection("Data").GetSection("DefaultConnection").GetSection("ConnectionString").Value))
            {
                using (SqlCommand comm = new SqlCommand(query, conn))
                {
                    conn.Open();
                    var reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        //first column
                        reader.GetValue(0);
                    }
                }
            }

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value) //Any data type (Objects)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
