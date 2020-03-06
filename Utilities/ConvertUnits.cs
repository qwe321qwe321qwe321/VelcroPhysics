/*
* Velcro Physics:
* Copyright (c) 2017 Ian Qvist
*/

using Microsoft.Xna.Framework;

namespace VelcroPhysics.Utilities
{
    /// <summary>
    /// Convert units between display and simulation units.
    /// </summary>
    public static class ConvertUnits
    {
        private static float _displayUnitsToSimUnitsRatio = 100f;
        private static float _simUnitsToDisplayUnitsRatio = 1 / _displayUnitsToSimUnitsRatio;

        public static void SetDisplayUnitToSimUnitRatio(float displayUnitsPerSimUnit)
        {
            _displayUnitsToSimUnitsRatio = displayUnitsPerSimUnit;
            _simUnitsToDisplayUnitsRatio = 1 / displayUnitsPerSimUnit;
        }

        public static float ToDisplayUnits(float simUnits)
        {
            return simUnits * _displayUnitsToSimUnitsRatio;
        }

        public static float ToDisplayUnits(int simUnits)
        {
            return simUnits * _displayUnitsToSimUnitsRatio;
        }

        public static XNAVector2 ToDisplayUnits(XNAVector2 simUnits)
        {
            return simUnits * _displayUnitsToSimUnitsRatio;
        }

        public static void ToDisplayUnits(ref XNAVector2 simUnits, out XNAVector2 displayUnits)
        {
            XNAVector2.Multiply(ref simUnits, _displayUnitsToSimUnitsRatio, out displayUnits);
        }

        public static XNAVector3 ToDisplayUnits(XNAVector3 simUnits)
        {
            return simUnits * _displayUnitsToSimUnitsRatio;
        }

        public static XNAVector2 ToDisplayUnits(float x, float y)
        {
            return new XNAVector2(x, y) * _displayUnitsToSimUnitsRatio;
        }

        public static void ToDisplayUnits(float x, float y, out XNAVector2 displayUnits)
        {
            displayUnits = XNAVector2.Zero;
            displayUnits.X = x * _displayUnitsToSimUnitsRatio;
            displayUnits.Y = y * _displayUnitsToSimUnitsRatio;
        }

        public static float ToSimUnits(float displayUnits)
        {
            return displayUnits * _simUnitsToDisplayUnitsRatio;
        }

        public static float ToSimUnits(double displayUnits)
        {
            return (float)displayUnits * _simUnitsToDisplayUnitsRatio;
        }

        public static float ToSimUnits(int displayUnits)
        {
            return displayUnits * _simUnitsToDisplayUnitsRatio;
        }

        public static XNAVector2 ToSimUnits(XNAVector2 displayUnits)
        {
            return displayUnits * _simUnitsToDisplayUnitsRatio;
        }

        public static XNAVector3 ToSimUnits(XNAVector3 displayUnits)
        {
            return displayUnits * _simUnitsToDisplayUnitsRatio;
        }

        public static void ToSimUnits(ref XNAVector2 displayUnits, out XNAVector2 simUnits)
        {
            XNAVector2.Multiply(ref displayUnits, _simUnitsToDisplayUnitsRatio, out simUnits);
        }

        public static XNAVector2 ToSimUnits(float x, float y)
        {
            return new XNAVector2(x, y) * _simUnitsToDisplayUnitsRatio;
        }

        public static XNAVector2 ToSimUnits(double x, double y)
        {
            return new XNAVector2((float)x, (float)y) * _simUnitsToDisplayUnitsRatio;
        }

        public static void ToSimUnits(float x, float y, out XNAVector2 simUnits)
        {
            simUnits = XNAVector2.Zero;
            simUnits.X = x * _simUnitsToDisplayUnitsRatio;
            simUnits.Y = y * _simUnitsToDisplayUnitsRatio;
        }
    }
}