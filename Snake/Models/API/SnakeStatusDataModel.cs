using Microsoft.AspNetCore.Server.IIS.Core;
using Snake.Game;

namespace Snake.Models.API
{
    
    public class SnakeStatusDataModel
    {
        public int SnakeSize { get; }
        public int SnakeScore { get; }
        public TimeSpan SnakeTime { get; }
        public SnakeStatusDataModel(Game.Game model)
        {
            int hour = model.statistics.GameTime.Hours;
            int min = model.statistics.GameTime.Minutes;
            int sec = model.statistics.GameTime.Seconds;
            SnakeTime = new TimeSpan(hour, min, sec);
            SnakeSize = model.Snake.SnakeSize;
            SnakeScore = model.statistics.GameScore;
        }
    }
}
