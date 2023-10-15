using Microsoft.AspNetCore.Mvc;
using Snake.Models.API;
using System.Drawing;
using SnakeGame = Snake.Game.Game;

namespace Snake.Controllers
{
    public class APIController : Controller
    {

        private readonly SnakeGame _game;
        public APIController(SnakeGame game)
        {
            _game = game;
        }
        public IActionResult GetField()
        {
            var dataModel = new GetFieldDataModel(_game);
            return PartialView("/Views/Parts/SnakeTable.cshtml", dataModel);
        }

        public IActionResult GetStatus()
        {
            var dataModel = new SnakeStatusDataModel(_game);
            return PartialView("/Views/Parts/SnakeStatus.cshtml", dataModel);
        }

        public void GoUp()
        {
            _game.Snake.Speed = new Point(0, -1);
        }
        public void Godown()
        {
            _game.Snake.Speed = new Point(0, 1);
        }
        public void GoLeft()
        {
            _game.Snake.Speed = new Point(-1, 0);
        }
        public void GoRight()
        {
            _game.Snake.Speed = new Point(1, 0);
        }
    }
}
