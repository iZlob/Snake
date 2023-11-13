using Snake.Game;

namespace Snake.Game
{
    public class Statistics
    {
        private readonly Snake _snake;
        public TimeSpan GameTime { get; private set; }
        public int GameScore { get; private set; }
        public int snakeSize { get; private set; }
        private DateTime GameStarted { get; set; }
        private DateTime GameStoped { get; set; }
        private DateTime TurnStarted { get; set; }
        public bool IsSnakeDead { get; set; }
        public Statistics(Snake snake)
        {
            _snake = snake;
            IsSnakeDead = false;
            snakeSize = _snake.SnakeSize;
            GameStoped = DateTime.MinValue;
            GameTime = TimeSpan.Zero;
            GameScore = 0;            

            if (_snake.IsMoving)
            {
                GameStarted = DateTime.Now;
            }
            else
            {
                GameStarted = DateTime.MinValue;
            }

            TurnStarted = GameStarted;
        }
        public void Tick()
        {
            if (_snake.IsDead)
            {
                IsSnakeDead = true;
                GameStoped = GameStoped == DateTime.MinValue ? DateTime.Now : GameStoped;
            }

            if (_snake.IsMoving && GameStarted == DateTime.MinValue)
            {
                GameStarted = DateTime.Now;
                TurnStarted = GameStarted;
            }

            if (_snake.IsMoving)
            {
                GameTime = GameStoped == DateTime.MinValue ? 
                           DateTime.Now - GameStarted : 
                           GameStoped - GameStarted;
            }

            if (_snake.SnakeSize != snakeSize)
            {
                snakeSize = _snake.SnakeSize;
                //base score 100
                //100 for 10 turn i.e. 10 sec
                //1 for more than 20 sec

                var eatSeconds = (int)(DateTime.Now - TurnStarted).TotalSeconds;

                TurnStarted = DateTime.Now;

                if (eatSeconds <= 10)
                {
                    GameScore += 100;
                }else if (eatSeconds <= 20)
                {
                    GameScore += 10 * (20 - eatSeconds);
                }
                else
                {
                    GameScore += 1;
                }
            }
        }

        public void RestartStatistics()
        {
            IsSnakeDead = false;
            snakeSize = _snake.SnakeSize;
            GameStoped = DateTime.MinValue;
            GameTime = TimeSpan.Zero;
            GameScore = 0;

            if (_snake.IsMoving)
            {
                GameStarted = DateTime.Now;
            }
            else
            {
                GameStarted = DateTime.MinValue;
            }

            TurnStarted = GameStarted;
        }
    }
}
