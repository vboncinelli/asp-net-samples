using Microsoft.AspNetCore.Mvc;
using text_adventure.mvc.Services;

namespace text_adventure.mvc.Controllers
{
    public class AdventureController : Controller
    {
        private readonly IGameService _gameService;

        public AdventureController(IGameService gameService)
        {
            _gameService = gameService ?? throw new ArgumentNullException(nameof(gameService));
        }

        public IActionResult Index()
        {
            var gameState = _gameService.LoadGameState();

            return View(gameState);
        }

        [HttpPost]
        public IActionResult ProcessCommand(string command)
        {
            var gameState = _gameService.LoadGameState();

            var output = _gameService.ProcessPlayerCommand(command.ToLower().Trim(), gameState);

            _gameService.SaveGameState(gameState);
            
            ViewBag.Output = output;

            return View("Index", gameState);
        }
    }
}
