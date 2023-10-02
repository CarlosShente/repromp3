using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ReproMP3.BL;
using ReproMP3.EN;
using System.Text.Json;

namespace WEBApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class CcarpetaController : ControllerBase
    {
        private CcarpetaBL ccarpetaBl = new CcarpetaBL();
        [HttpGet]
        public async Task<IEnumerable<Ccarpeta>> Get()
        {
            return await ccarpetaBl.ObtenerTodosAsync();
        }
        [HttpGet("{id}")]
        public async Task<Ccarpeta> Get(int Id)
        {
            Ccarpeta ccarpeta = new Ccarpeta();
            ccarpeta.Id = Id;
            return await ccarpetaBl.ObtenerPorIdAsync(ccarpeta);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Ccarpeta ccarpeta)
        {
            try
            {
                await ccarpetaBl.CrearAsync(ccarpeta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Ccarpeta>> Put(int id, [FromBody] Ccarpeta ccarpeta)
        {

            {
                if (ccarpeta.Id == id)
                {
                    await ccarpetaBl.ModificarAsync(ccarpeta);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Ccarpeta ccarpeta = new Ccarpeta();
                ccarpeta.Id = id;
                await ccarpetaBl.EliminarAsync(ccarpeta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Ccarpeta>> Buscar([FromBody] object pCcarpeta)
        {
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            String strCarpeta = JsonSerializer.Serialize(pCcarpeta);
            Ccarpeta ccarpeta = JsonSerializer.Deserialize<Ccarpeta>(strCarpeta, option);
            return await ccarpetaBl.BuscarAsync(ccarpeta);
        }
    }

}
