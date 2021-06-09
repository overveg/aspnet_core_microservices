using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/crud")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly ValuesHolder _holder;

        public CrudController(ValuesHolder holder)
        {
            _holder = holder;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] DateTime date, int temperature)
        {
            _holder.Add(date, temperature);
            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read(DateTime fromDate, DateTime toDate)
        {
            return Ok(_holder.Get(fromDate, toDate));
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime date, int temperature)
        {
            _holder.Update(date, temperature);
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime date)
        {
            _holder.Delete(date);
            return Ok();
        }
    }
}
