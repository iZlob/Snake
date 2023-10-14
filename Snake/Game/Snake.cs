using System.Drawing;

namespace Snake.Game
{
    public class Snake
    {
        private Queue<Point> _snakeBody;
        private int size = 4;
        public Point[] SnakeBody => _snakeBody.Where(x => x != SnakeHead).ToArray();
        public Point SnakeHead => _snakeBody.Last();
        //private Point _snakeHead;
        private Point _speed;
        public Point Speed { get; set; } = Point.Empty;
        public Snake()
        {
            Random rnd = new Random();
            int headX = rnd.Next(Field.FIELD_W);
            int headY = rnd.Next(Field.FIELD_H);
            //_snakeHead = new Point(headX, headY);
            _snakeBody = new Queue<Point>();
            
            for (int i = 0; i < size; i++)
            {
                _snakeBody.Enqueue(new Point(headX, headY));
            }
        }

        public void Move()
        {
            Point head = SnakeHead;
            Point nexthead = new Point(head.X + Speed.X, head.Y + Speed.Y);
            //int headX = head.X + Speed.X;
           // int headY = head.Y + Speed.Y;
            _snakeBody.Enqueue(nexthead);
            _snakeBody.Dequeue();

        }

    }
}
