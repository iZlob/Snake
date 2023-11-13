using Microsoft.AspNetCore.Server.IIS.Core;
using Snake.Game;

namespace Snake.Models.API
{    
    public class SnakeStatusDataModel
    {
        public int SnakeSize { get; }
        public int SnakeScore { get; }
        public string SnakeTime { get; }
        public bool IsSnakeAlive { get; }
        public bool IsSnakeMove { get; }
        public SnakeStatusDataModel(Game.Game model)
        {
            SnakeTime = model.Statistics.GameTime.ToString(@"hh\:mm\:ss");
            SnakeSize = model.Snake.SnakeSize;
            SnakeScore = model.Statistics.GameScore;
            IsSnakeAlive = !model.Statistics.IsSnakeDead;
            IsSnakeMove = model.Snake.IsMoving;
        }
        public string alive = "Кажись живой!";
        public string dead = "Помёр бобёр!";
        public string run = "Ран, Форест, ран!";
        public string no_run = "Чё-та даже не дрыгается...";
    }
}
