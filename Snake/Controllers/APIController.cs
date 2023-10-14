using Microsoft.AspNetCore.Mvc;
using Snake.Models.API;
using System.Drawing;
using SnakeGame = Snake.Game.Game;

namespace Snake.Controllers
{
    public class APIController : Controller
    {
        private SnakeGame _game;
        private object _getFieldLockObj = new();
        public APIController(SnakeGame game)
        {
            _game = game;
        }
        public IActionResult GetField()
        {
            //_game.Field.ChangeField();
            var dataModel = new GetFieldDataModel(_game);
            return PartialView("/Views/Parts/SnakeTable.cshtml", dataModel);
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
