/*  Universidad Tecnologica Metropolitana
    Aplicaciones Web Orientadas a Servicios
    Maestro Chuc Uc Joel Ivan
    Actividad 2 (Resistencia y Alcoholimetro API's)
    Jhonatan Canché Sulú
    Cuatrimestre: 4a DSM
    2° Parcial
*/
using Microsoft.AspNetCore.Mvc;
using AlcoholimetroApi.entities;
using AlcoholimetroApi.Services;



namespace AlcoholimetroApi.Controllers
{  [ApiController]
    [Route("api/[controller]")]
    public class AlcoholController : ControllerBase
    {
        
        [HttpPost]
        [Route("")]
        public IActionResult Calcular([FromBody] Personas person)
        {
            var personalcohol = new AlcoholServices();
            var alcohol = personalcohol.calcular(person);
            return Ok(alcohol);
        }


        //Metodo GET para calcular ingresando los datos en la direccion. Ej. https://localhost:5001/api/alcohol/cerveza.3.80
        [HttpGet]
        [Route("{tipo}.{cantidad}.{peso}")]
        public IActionResult Calcular(string tipo, int cantidad,int peso)
        {
            var personas = new Personas (tipo,cantidad,peso);
            
            var personalcohol = new AlcoholServices();
            var alcohol = personalcohol.calcular(personas);
            return Ok(alcohol);
        }

    }
}