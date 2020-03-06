using Microsoft.Xna.Framework;
using VelcroPhysics.Shared;
using VelcroPhysics.Utilities;

namespace VelcroPhysics.Collision
{
    public static class TestPointHelper
    {
        public static bool TestPointCircle(ref XNAVector2 pos, float radius, ref XNAVector2 point, ref Transform transform)
        {
            XNAVector2 center = transform.p + MathUtils.Mul(transform.q, pos);
            XNAVector2 d = point - center;
            return XNAVector2.Dot(d, d) <= radius * radius;
        }

        public static bool TestPointPolygon(Vertices vertices, Vertices normals, ref XNAVector2 point, ref Transform transform)
        {
            XNAVector2 pLocal = MathUtils.MulT(transform.q, point - transform.p);

            for (int i = 0; i < vertices.Count; ++i)
            {
                float dot = XNAVector2.Dot(normals[i], pLocal - vertices[i]);
                if (dot > 0.0f)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
