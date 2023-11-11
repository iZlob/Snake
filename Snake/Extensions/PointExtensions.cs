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
                int x = rnd.Next(Field.FIELD_WIDTH);
                int y = rnd.Next(Field.FIELD_HIGHT);

                if (!excludePointsFromGenerationArray.Any(z => z.X == x && z.Y == y))
                {
                    return new Point(x, y);
                }
            }
        }
    }
}