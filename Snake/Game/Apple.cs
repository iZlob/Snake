using Snake.Extensions;
using System.Drawing;

namespace Snake.Game
{
    public class Apple
    {
        private readonly Snake _snake;
        public Point Position { get; private set; }
        public Apple(Snake snake)
        {
            _snake = snake;
            Position = GenerateApplePosition(_snake);
        }

        public void RegenerateApple()
        {
            Position = GenerateApplePosition(_snake);
        }

        private static Point GenerateApplePosition(Snake snake)
        {
            return Point.Empty.GenerateInFieldPoint(snake.SnakeBody.Union(new[] { snake.SnakeHead }));
        }

        public void OnDataUpdated()
        {
            if (Position == _snake.SnakeHead)
            {
                _snake.IsGrowing = true;
                RegenerateApple();
            }
        }
    }
}