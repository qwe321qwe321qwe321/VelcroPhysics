using Microsoft.Xna.Framework;
using VelcroPhysics.Shared;
using VelcroPhysics.Utilities;

namespace VelcroPhysics.Collision
{
    public static class AABBHelper
    {
        public static void ComputeEdgeAABB(ref XNAVector2 start, ref XNAVector2 end, ref Transform transform, out AABB aabb)
        {
            XNAVector2 v1 = MathUtils.Mul(ref transform, ref start);
            XNAVector2 v2 = MathUtils.Mul(ref transform, ref end);

            aabb.LowerBound = XNAVector2.Min(v1, v2);
            aabb.UpperBound = XNAVector2.Max(v1, v2);

            XNAVector2 r = new XNAVector2(Settings.PolygonRadius, Settings.PolygonRadius);
            aabb.LowerBound = aabb.LowerBound - r;
            aabb.UpperBound = aabb.UpperBound + r;
        }

        public static void ComputeCircleAABB(ref XNAVector2 pos, float radius, ref Transform transform, out AABB aabb)
        {
            XNAVector2 p = transform.p + MathUtils.Mul(transform.q, pos);
            aabb.LowerBound = new XNAVector2(p.X - radius, p.Y - radius);
            aabb.UpperBound = new XNAVector2(p.X + radius, p.Y + radius);
        }

        public static void ComputePolygonAABB(Vertices vertices, ref Transform transform, out AABB aabb)
        {
            XNAVector2 lower = MathUtils.Mul(ref transform, vertices[0]);
            XNAVector2 upper = lower;

            for (int i = 1; i < vertices.Count; ++i)
            {
                XNAVector2 v = MathUtils.Mul(ref transform, vertices[i]);
                lower = XNAVector2.Min(lower, v);
                upper = XNAVector2.Max(upper, v);
            }

            XNAVector2 r = new XNAVector2(Settings.PolygonRadius, Settings.PolygonRadius);
            aabb.LowerBound = lower - r;
            aabb.UpperBound = upper + r;
        }
    }
}
