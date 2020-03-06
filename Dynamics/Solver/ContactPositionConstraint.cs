using Microsoft.Xna.Framework;
using VelcroPhysics.Collision.Narrowphase;

namespace VelcroPhysics.Dynamics.Solver
{
    public sealed class ContactPositionConstraint
    {
        public int IndexA;
        public int IndexB;
        public float InvIA, InvIB;
        public float InvMassA, InvMassB;
        public XNAVector2 LocalCenterA, LocalCenterB;
        public XNAVector2 LocalNormal;
        public XNAVector2 LocalPoint;
        public XNAVector2[] LocalPoints = new XNAVector2[Settings.MaxManifoldPoints];
        public int PointCount;
        public float RadiusA, RadiusB;
        public ManifoldType Type;
    }
}