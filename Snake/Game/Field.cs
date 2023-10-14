using Snake.Models.API;
using System;
using System.Diagnostics.Contracts;
using System.Drawing;


namespace Snake.Game
{
    public class Field
    {
        public const int FIELD_WIDTH = 30;
        public const int FIELD_HIGHT = 30;
        public int[][] FieldData => _field;
        private int[][] _field;
        private readonly Snake _snake;

        private void AddSnakeDataField()
        {
            Point snakeHead = _snake.SnakeHead;
            Point[] snakeBody = _snake.SnakeBody;
            _field[snakeHead.Y][snakeHead.X] = 3;

            foreach(var snakeBodyPart in snakeBody)
            {
                _field[snakeBodyPart.Y][snakeBodyPart.X] = 2;
            }
        }
        private static int[][] InitField() {
            int[][] rez = new int[FIELD_HIGHT][];
                for (int i = 0; i < FIELD_HIGHT; i++)
                {
                rez[i] = new int[FIELD_WIDTH];
                    Array.Fill(rez[i], 0, 0, FIELD_WIDTH);
                }
            return rez;
        }
        public Field(Snake snake)
        {
            _snake = snake;
            _field = InitField();
        }
        public void ChangeField()
        {
            _field = InitField();
            AddSnakeDataField();
            var randomizer = new Random();
            var rndRow = randomizer.Next() % FIELD_HIGHT;
            var rndCol = randomizer.Next() % FIELD_WIDTH;
            _field[rndRow][rndCol] = 1;

        }
    }
}
