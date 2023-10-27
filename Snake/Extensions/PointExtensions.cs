using System.Drawing;
using Snake.Game;

namespace Snake.Extensions
{
    public static class PointExtension
    {
        public static Point GenerateInFieldPoint(this Point point, IEnumerable<Point> excludePointsFromGeneration)
        {
            Random rnd = new Random();

            var excludePointsFromGenerationArray =
                excludePointsFromGeneration as Point[] ??
                excludePointsFromGeneration.ToArray();

            while (true)
            {
                int X = rnd.Next(Field.FIELD_WIDTH);
                int Y = rnd.Next(Field.FIELD_HIGHT);

                if (!excludePointsFromGenerationArray.Any(z => z.X == X && z.Y == Y))
                {
                    return new Point(X, Y);
                }
            }
        }
    }
}