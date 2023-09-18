using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ReproMP3.BL;
using ReproMP3.EN;
using System.Text.Json;

namespace WEBApi.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class MmusicaController : ControllerBase
    {
        private MmusicaBL mmusicaBl = new MmusicaBL();
        [HttpGet]
        public async Task<IEnumerable<Mmusica>> Get()
        {
            return await mmusicaBl.ObtenerTodosAsync();
        }
        [HttpGet("id")]
        public async Task<Mmusica> Get(int Id)
        {
            Mmusica mmusica = new Mmusica();
            mmusica.Id = Id;  
            return await mmusicaBl.ObtenerPorIdAsync(mmusica);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Mmusica mmusica)
        {
            try
            {
                await mmusicaBl.CrearAsync(mmusica);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpPut("id")]
        public async Task<ActionResult<Mmusica>> Put(int id, [FromBody] Mmusica mmusica)
        {

            {
                if (mmusica.Id == id)
                {
                    await mmusicaBl.ModificarAsync(mmusica);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            try
            {
                Mmusica mmusica = new Mmusica();
                mmusica.Id = id;
                await mmusicaBl.EliminarAsync(mmusica);
                return Ok();
            } 
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Mmusica>> Buscar([FromBody] object pMmusica)
        {
            var option = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            String strMmusica = JsonSerializer.Serialize(pMmusica);
            Mmusica mmusica= JsonSerializer.Deserialize<Mmusica>(strMmusica, option);
            return await mmusicaBl.BuscarAsync(mmusica);
        }
    }

}
