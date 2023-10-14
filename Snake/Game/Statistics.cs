using Snake.Game;

namespace Snake.Game
{
    
    public class Statistics
    {
        private readonly Snake _snake;
        public TimeSpan GameTime { get; private set; }
        private DateTime GameStarted { get; set; }
        public int GameScore { get; private set; }
        public int snakeSize;
        private DateTime TurnStarted { get; set; }
        public Statistics(Snake snake)
        {
            _snake = snake;

            if (_snake.IsMoving)
            {
                GameStarted = DateTime.UtcNow;
            }
            else
            {
                GameStarted = DateTime.MinValue;
            }
            snakeSize = _snake.SnakeSize;
            GameTime = TimeSpan.Zero;
            GameScore = 0;
        }
        public void Tick()
        {
            if (_snake.IsMoving && GameStarted == DateTime.MinValue)
            {
                GameStarted = DateTime.Now;
                TurnStarted = GameStarted;
            }

            if (_snake.IsMoving)
            {
                GameTime = DateTime.Now - GameStarted;
            }
            if (_snake.SnakeSize != snakeSize)
            {
                snakeSize = _snake.SnakeSize;
                //base score 100
                //100 for 10 turn i.e. 10 sec
                //0 for more than 20 sec


                var eatSeconds = (int)((DateTime.Now - TurnStarted).TotalSeconds);

                if (eatSeconds < 10)
                {
                    GameScore += 100;
                }else if (eatSeconds <= 20)
                {
                    GameScore += 10 * (20 - eatSeconds);
                }
            }
        }

    }
}
