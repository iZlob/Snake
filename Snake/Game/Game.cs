using Snake.Game;
using System.Net.NetworkInformation;

namespace Snake.Game
{
    public class Game
    {
        public Field Field => _field;
        public Snake Snake => _snake;
        public GameTimer Timer => _timer;

        private readonly Field _field;

        private readonly Snake _snake ;
        private readonly GameTimer _timer;

        public Statistics statistics { get; private set; }

        
        public Game()
        {
            _snake = new Snake();
            _field = new Field(_snake);

            statistics = new Statistics(_snake);

            _timer = new GameTimer(TimeSpan.FromSeconds(0.5f), _field.ChangeField, _snake.Move, statistics.Tick);
            
        }
    }
 
}
