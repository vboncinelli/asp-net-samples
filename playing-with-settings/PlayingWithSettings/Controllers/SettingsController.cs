using Microsoft.AspNetCore.Mvc;

namespace PlayingWithSettings.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public SettingsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // per testare: https://localhost:5000/api/settings/<nome_del_setting>
        // es: https://localhost:5000/api/settings/mysetting

        //TODO: i parametri possono essere presi da appsettings.<environment>.json,
        // da un altro file json, da variabili ambientali (vedi file Properties--> launchSettings.json) 
        // o da riga di comando.
        [HttpGet("{setting}")]
        public IActionResult Get(string setting)
        {
            var value = this._configuration[setting];

            if (value == null)
                return BadRequest();

            return Ok(value);
        }
    }
}
