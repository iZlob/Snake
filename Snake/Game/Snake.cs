using System.Drawing;

namespace Snake.Game
{
    public class Snake
    {
        private Queue<Point> _snakeBody;

        private const int size = 4;
        public Point[] SnakeBody => _snakeBody.Where(x => x != SnakeHead).ToArray();
        public Point SnakeHead => _snakeBody.Last();

        private Point _speed;
        public Point Speed { get; set; } = Point.Empty;
        public bool IsDead { get; private set; } = false;
        public bool IsMoving { get; private set; } = false;
        public bool IsGrowing { get; set; } = false;
        public int SnakeSize => _snakeBody.Count;
        public Snake()
        {
            Random rnd = new Random();
            int headX = rnd.Next(Field.FIELD_WIDTH);
            int headY = rnd.Next(Field.FIELD_HIGHT);

            _snakeBody = new Queue<Point>();
            
            for (int i = 0; i < size; i++)
            {
                _snakeBody.Enqueue(new Point(headX, headY));
            }

            IsDead = false;
        }

        public void Move()
        {
            if (IsDead)
            {
                IsMoving = false;
                return;
            }

            IsMoving = Speed != Point.Empty;
            Point head = SnakeHead;
            Point nexthead = new Point(head.X + Speed.X, head.Y + Speed.Y);

            IsDead = IsOutOfField(nexthead);

            if (IsDead)
            {
                IsMoving = false;
                return;
            }

            IsDead = IsHitMyself(nexthead);
            Console.WriteLine(IsDead);

            if (IsDead)
            {
                IsMoving = false;
                return;
            }

            if (!IsGrowing)
            {
                _snakeBody.Dequeue();
            }
            else
            {
                IsGrowing = false;
            }

            _snakeBody.Enqueue(nexthead);
        }
        private bool IsHitMyself(Point nexthead)
        {
            return SnakeBody.Length >= size - 1 && _snakeBody.Contains(nexthead);
        }
        private bool IsOutOfField(Point nextHead)
        {
            return nextHead.X >= Field.FIELD_WIDTH || nextHead.X < 0 ||
                   nextHead.Y >= Field.FIELD_HIGHT || nextHead.Y < 0;
        }
    }
}
