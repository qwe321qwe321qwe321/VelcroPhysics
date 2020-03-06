using System.Diagnostics;
using Microsoft.Xna.Framework;
using VelcroPhysics.Collision.Narrowphase;
using VelcroPhysics.Shared;
using VelcroPhysics.Utilities;

namespace VelcroPhysics.Dynamics.Solver
{
    public static class PositionSolverManifold
    {
        public static void Initialize(ContactPositionConstraint pc, Transform xfA, Transform xfB, int index, out XNAVector2 normal, out XNAVector2 point, out float separation)
        {
            Debug.Assert(pc.PointCount > 0);

            switch (pc.Type)
            {
                case ManifoldType.Circles:
                    {
                        XNAVector2 pointA = MathUtils.Mul(ref xfA, pc.LocalPoint);
                        XNAVector2 pointB = MathUtils.Mul(ref xfB, pc.LocalPoints[0]);
                        normal = pointB - pointA;

                        //Velcro: Fix to handle zero normalization
                        if (normal != XNAVector2.Zero)
                            normal.Normalize();

                        point = 0.5f * (pointA + pointB);
                        separation = XNAVector2.Dot(pointB - pointA, normal) - pc.RadiusA - pc.RadiusB;
                    }
                    break;

                case ManifoldType.FaceA:
                    {
                        normal = MathUtils.Mul(xfA.q, pc.LocalNormal);
                        XNAVector2 planePoint = MathUtils.Mul(ref xfA, pc.LocalPoint);

                        XNAVector2 clipPoint = MathUtils.Mul(ref xfB, pc.LocalPoints[index]);
                        separation = XNAVector2.Dot(clipPoint - planePoint, normal) - pc.RadiusA - pc.RadiusB;
                        point = clipPoint;
                    }
                    break;

                case ManifoldType.FaceB:
                    {
                        normal = MathUtils.Mul(xfB.q, pc.LocalNormal);
                        XNAVector2 planePoint = MathUtils.Mul(ref xfB, pc.LocalPoint);

                        XNAVector2 clipPoint = MathUtils.Mul(ref xfA, pc.LocalPoints[index]);
                        separation = XNAVector2.Dot(clipPoint - planePoint, normal) - pc.RadiusA - pc.RadiusB;
                        point = clipPoint;

                        // Ensure normal points from A to B
                        normal = -normal;
                    }
                    break;
                default:
                    normal = XNAVector2.Zero;
                    point = XNAVector2.Zero;
                    separation = 0;
                    break;
            }
        }
    }
}