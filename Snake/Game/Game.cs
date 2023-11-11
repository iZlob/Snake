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
        public Statistics statistics { get; }

        public Game()
        {
            _snake = new Snake();
            _apple = new Apple(_snake);
            _field = new Field(_snake, _apple);
            statistics = new Statistics(_snake);

            _timer = new GameTimer(TimeSpan.FromSeconds(0.3f), _snake.Move, _apple.OnDataUpdated, _field.ChangeField, statistics.Tick);
        }

        public void NewGame()
        {
            _timer.Pause();
            _snake.Reborn();
            _apple.RegenerateApple();
            _timer.Resume();
        }
    }
}
