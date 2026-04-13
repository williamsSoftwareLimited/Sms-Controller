using SmsControl.Extensions;

namespace SmsControlTests.Extensions
{
    [TestClass]
    public class ByteExtensionTests
    {
        [DataTestMethod]
        [DynamicData(nameof(ByteData), DynamicDataSourceType.Method)]
        public void ToLeIntTests(long expected, byte[] data)
        {
            Assert.AreEqual(expected, data.ToLeInt());
        }

        static IEnumerable<object[]> ByteData()
        {
            yield return new object[] { 0, new byte[0] };
            yield return new object[] { 10, new byte[] { 10 } };
            yield return new object[] { 10000, new byte[] { 16, 39 } };
            yield return new object[] { 388884483, new byte[] { 3, 232, 45, 23 } };
            yield return new object[] { 859124523, new byte[] { 43, 51, 53, 51 } }; //3335 332B = +353
            yield return new object[] { 0, new byte[] { 43, 51, 53, 51, 30 } }; //3335 332B = +353
        }
    }
}
