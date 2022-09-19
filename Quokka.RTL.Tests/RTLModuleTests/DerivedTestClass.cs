namespace Quokka.RTL.Tests
{
    public class DerivedTestClass : BaseMembersTestClass
    {
        public bool DerivedPublic1;
        byte[] DerivedPrivate1 = new byte[256];

        RTLBitArray DerivedPrivate2;
        RTLBitArray DerivedPrivate3 => DerivedPublic1;
    }

    public class CustomRTLBitArray : RTLBitArray
    {
        public CustomRTLBitArray() : base(byte.MinValue)
        {

        }
    }

    public class CustomBitArrayClass
    {
        CustomRTLBitArray b;
    }
}
