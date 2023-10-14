using Microsoft.AspNetCore.Mvc;
using Snake.Models.API;
using SnakeGame = Snake.Game.Game;

namespace Snake.Controllers
{
    

    public class GameController : Controller
    {
        private SnakeGame _game;
        public GameController(SnakeGame game)
        {
            _game = game;
        }
        public IActionResult Index()
        {
            var dataModel = new GetFieldDataModel(_game);
            return View(dataModel);
        }
    }
}
