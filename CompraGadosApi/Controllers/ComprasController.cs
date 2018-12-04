using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompraGadosApi.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CompraGadosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprasController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CompraGadoDto>> Get()
        {
            return null;
        }

        [HttpGet("{id}")]
        public ActionResult<CompraGadoDto> Get(int id)
        {
            return null;
        }

        [HttpPost]
        public void Post([FromBody] CompraGadoDto Compra)
        {

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
