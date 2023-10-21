using Microsoft.AspNetCore.Server.IIS.Core;
using Snake.Game;

namespace Snake.Models.API
{
    
    public class SnakeStatusDataModel
    {
        public int SnakeSize { get; }
        public int SnakeScore { get; }
        public string SnakeTime { get; }
        public SnakeStatusDataModel(Game.Game model)
        {
            SnakeTime = model.statistics.GameTime.ToString(@"hh\:mm\:ss");
            SnakeSize = model.Snake.SnakeSize;
            SnakeScore = model.statistics.GameScore;
        }
    }
}
