using System;
using System.Numerics;

namespace CGSpringChallenge2022
{
    public static class Geometry
    {
        public static Vector2? ClosestLineCircleIntersection(
            Vector2 circleCenter,
            float circleRadius,
            Vector2 lineStart,
            Vector2 lineEnd)
        {
            var intersectionCount =
                LineCircleIntersections(
                    circleCenter,
                    circleRadius,
                    lineStart,
                    lineEnd,
                    out var intersection1,
                    out var intersection2);

            return intersectionCount switch
            {
                1 => intersection1,
                2 => DistanceSqr(intersection1, lineStart) < DistanceSqr(intersection2, lineStart)
                         ? intersection1
                         : intersection2,
                _ => null
            };
        }

        public static int LineCircleIntersections(
            Vector2 circleCenter,
            float circleRadius,
            Vector2 lineStart,
            Vector2 lineEnd,
            out Vector2 intersection1,
            out Vector2 intersection2)
        {
            var dx = lineEnd.X - lineStart.X;
            var dy = lineEnd.Y - lineStart.Y;

            var A = dx * dx + dy * dy;
            var B = 2 * (dx * (lineStart.X - circleCenter.X) + dy * (lineStart.Y - circleCenter.Y));
            var C =
                (lineStart.X - circleCenter.X) * (lineStart.X - circleCenter.X) +
                (lineStart.Y - circleCenter.Y) * (lineStart.Y - circleCenter.Y) -
                circleRadius * circleRadius;

            var det = B * B - 4 * A * C;

            if (A <= 0.0000001 || det < 0)
            {
                // No real solutions.
                intersection1 = Vector2.Zero;
                intersection2 = Vector2.Zero;
                return 0;
            }

            if (det == 0)
            {
                // One solution.
                var t = -B / (2 * A);
                intersection1 = new Vector2(lineStart.X + t * dx, lineStart.Y + t * dy);
                intersection2 = Vector2.Zero;
                return 1;
            }
            else
            {
                // Two solutions.
                var t = (float)((-B + Math.Sqrt(det)) / (2 * A));
                intersection1 = new Vector2(lineStart.X + t * dx, lineStart.Y + t * dy);
                t = (float)((-B - Math.Sqrt(det)) / (2 * A));
                intersection2 = new Vector2(lineStart.X + t * dx, lineStart.Y + t * dy);
                return 2;
            }
        }

        public static double Distance(Vector2 p1, Vector2 p2) => Math.Sqrt(DistanceSqr(p1, p2));
        public static double DistanceSqr(Vector2 p1, Vector2 p2) => Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2);
    }
}