using Microsoft.AspNetCore.Mvc;
using Snake.Models.API;
using System.Drawing;
using SnakeGame = Snake.Game.Game;

namespace Snake.Controllers
{
    public class APIController : Controller
    {
        private readonly SnakeGame _game;

        object locker = new();
        
        public APIController(SnakeGame game)
        {
            _game = game;
        }

        public IActionResult GetField()
        {
            var dataModel = new GetFieldDataModel(_game);
            return PartialView("/Views/Parts/SnakeTable.cshtml", dataModel);
        }

        //Get
        public SnakeStatusDataModel GetStatusDataModel()
        {
            return new SnakeStatusDataModel(_game);
        }

        //get
        public IActionResult GetStatus()
        {
            var dataModel = new SnakeStatusDataModel(_game);
            return PartialView("/Views/Parts/SnakeStatus.cshtml", dataModel);
        }

        public void GoUp()
        {
            lock (locker)
            {
                _game.Snake.Speed = new Point(0, -1);
            }
        }

        public void Godown()
        {
            lock (locker)
            {
                _game.Snake.Speed = new Point(0, 1);
            }
        }

        public void GoLeft()
        {
            lock (locker)
            {
                _game.Snake.Speed = new Point(-1, 0);
            }
        }

        public void GoRight()
        {
            lock (locker)
            {
                _game.Snake.Speed = new Point(1, 0);
            }
        }

        //public void NewGame()
        //{
        //    _game.NewGame();
        //}
    }
}
