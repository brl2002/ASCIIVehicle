using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    class Vector2
    {
        public int x;
        public int y;

        public Vector2 normalized
        {
            get
            {
                Vector2 temp = new Vector2();
                float d = Magnitude();
                temp.x = (int)(x / d);
                temp.y = (int)(y / d);

                return temp;
            }
        }

        public Vector2()
        {
            x = 0;
            y = 0;
        }

        public Vector2(int xVal, int yVal)
        {
            x = xVal;
            y = yVal;
        }

        public float SquaredMagnitude()
        {
            return x * x + y * y;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(SquaredMagnitude());
        }

        public static bool operator ==(Vector2 lhs, Vector2 rhs)
        {
            return (lhs.x == rhs.x) && (lhs.y == rhs.y);
        }

        public static bool operator !=(Vector2 lhs, Vector2 rhs)
        {
            return (lhs.x != rhs.x) || (lhs.y != rhs.y);
        }

        public static Vector2 operator-(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x - rhs.x, lhs.y - rhs.y);
        }

        public static Vector2 operator +(Vector2 lhs, Vector2 rhs)
        {
            return new Vector2(lhs.x + rhs.x, lhs.y + rhs.y);
        }

        public static Vector2 operator*(Vector2 lhs, float f)
        {
            return new Vector2((int)(lhs.x * f), (int)(lhs.y * f));
        }

        public static Vector2 operator *(Vector2 lhs, double d)
        {
            return new Vector2((int)(lhs.x * d), (int)(lhs.y * d));
        }

        public static float Dot(Vector2 v1, Vector2 v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
        }

        public static Vector2 Lerp(Vector2 from, Vector2 to, double fraction)
        {
            if (fraction > 1.0f)
                fraction = 1.0f;
            else if (fraction < 0.0)
                fraction = 0.0f;

            Vector2 lerpPos = ((to - from) * (float)fraction);
            lerpPos = lerpPos + from;

            return lerpPos;
        }
    }
}
