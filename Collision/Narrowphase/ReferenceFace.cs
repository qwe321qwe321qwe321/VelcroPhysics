using Microsoft.Xna.Framework;

namespace VelcroPhysics.Collision.Narrowphase
{
    /// <summary>
    /// Reference face used for clipping
    /// </summary>
    public struct ReferenceFace
    {
        public int i1, i2;

        public XNAVector2 v1, v2;

        public XNAVector2 Normal;

        public XNAVector2 SideNormal1;
        public float SideOffset1;

        public XNAVector2 SideNormal2;
        public float SideOffset2;
    }
}