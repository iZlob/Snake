using Snake.Game;
using System.Net.NetworkInformation;

namespace Snake.Game
{
    public class Game
    {
        private readonly Field _field;
        public Field Field => _field;

        private readonly Snake _snake;
        public Snake Snake => _snake;

        private readonly GameTimer _timer;
        public GameTimer Timer => _timer;

        private readonly Apple _apple;
        public Apple Apple => _apple;
        public bool isPlay { get; private set; }

        public Statistics statistics { get; }

        public Game()
        {
            _snake = new Snake();
            _apple = new Apple(_snake);
            _field = new Field(_snake, _apple);
            statistics = new Statistics(_snake);

            //_timer = new GameTimer(TimeSpan.FromSeconds(0.3f), _snake.Move, IsPlaying, statistics.Tick, _field.ChangeField, _apple.OnDataUpdated);
            //_timer = new GameTimer(TimeSpan.FromSeconds(0.3f), _snake.Move, IsPlaying, statistics.Tick, _apple.OnDataUpdated, _field.ChangeField);
            // _timer = new GameTimer(TimeSpan.FromSeconds(0.3f), _snake.Move, IsPlaying, _field.ChangeField, statistics.Tick, _apple.OnDataUpdated);
            //_timer = new GameTimer(TimeSpan.FromSeconds(0.3f), _snake.Move, IsPlaying, _field.ChangeField, _apple.OnDataUpdated, statistics.Tick);
            // _timer = new GameTimer(TimeSpan.FromSeconds(0.3f), _snake.Move, IsPlaying, _apple.OnDataUpdated, statistics.Tick, _field.ChangeField);
             _timer = new GameTimer(TimeSpan.FromSeconds(0.3f), _snake.Move, IsPlaying, _apple.OnDataUpdated, _field.ChangeField, statistics.Tick);

        }

        private void IsPlaying()
        {
            if (!_snake.IsDead)
            {
                isPlay = true;
            }
            else
            {
                isPlay = false;
            }
        }
    }
 
}
