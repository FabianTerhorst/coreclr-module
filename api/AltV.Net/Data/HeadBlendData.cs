using System;
using System.Runtime.InteropServices;

namespace AltV.Net.Data
{
    [StructLayout(LayoutKind.Sequential)]
    public struct HeadBlendData : IEquatable<HeadBlendData>
    {
        public static HeadBlendData Zero = new(0, 0, 0, 0, 0, 0, 0, 0, 0);

        public uint ShapeFirstID;
        public uint ShapeSecondID;
        public uint ShapeThirdID;
        public uint SkinFirstID;
        public uint SkinSecondID;
        public uint SkinThirdID;
        public float ShapeMix;
        public float SkinMix;
        public float ThirdMix;

        public HeadBlendData(uint shapeFirstID, uint shapeSecondID, uint shapeThirdID, uint skinFirstID, uint skinSecondID, uint skinThirdID, float shapeMix, float skinMix, float thirdMix)
        {
            ShapeFirstID = shapeFirstID;
            ShapeSecondID = shapeSecondID;
            ShapeThirdID = shapeThirdID;
            SkinFirstID = skinFirstID;
            SkinSecondID = skinSecondID;
            SkinThirdID = skinThirdID;
            ShapeMix = shapeMix;
            SkinMix = skinMix;
            ThirdMix = thirdMix;
        }
        public override string ToString()
        {
            return $"HeadBlendData(shapeFirstID: {ShapeFirstID}, shapeSecondID: {ShapeSecondID}, shapeThirdID: {ShapeThirdID}, skinFirstID: {SkinFirstID}, skinSecondID: {SkinSecondID}, skinThirdID: {SkinThirdID}, shapeMix: {ShapeMix}, skinMix: {SkinMix}, thirdMix: {ThirdMix})";
        }

        public override bool Equals(object obj)
        {
            return obj is HeadBlendData other && Equals(other);
        }

        public bool Equals(HeadBlendData other)
        {
            return ShapeFirstID.Equals(other.ShapeFirstID) && ShapeSecondID.Equals(other.ShapeSecondID) && ShapeThirdID.Equals(other.ShapeThirdID) && SkinFirstID.Equals(other.SkinFirstID)
                && SkinSecondID.Equals(other.SkinSecondID) && SkinThirdID.Equals(other.SkinThirdID) && ShapeMix.Equals(other.ShapeMix) && SkinMix.Equals(other.SkinMix) && ThirdMix.Equals(other.ThirdMix);
        }

        public override int GetHashCode() => HashCode.Combine(HashCode.Combine(ShapeFirstID.GetHashCode(), ShapeSecondID.GetHashCode(), ShapeThirdID.GetHashCode(), SkinFirstID.GetHashCode(), SkinSecondID.GetHashCode(), SkinThirdID.GetHashCode(), ShapeMix.GetHashCode(), SkinMix.GetHashCode()), ThirdMix.GetHashCode());
    }
}