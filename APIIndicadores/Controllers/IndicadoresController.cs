using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Dapper;

namespace APIIndicadores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndicadoresController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Indicador> Get(
            [FromServices]IConfiguration configuration)
        {
            using (SqlConnection conexao = new SqlConnection(
                configuration.GetConnectionString("BaseIndicadores")))
            {
                return conexao.Query<Indicador>(
                    "SELECT * FROM dbo.Indicadores");
            }
        }
    }
}