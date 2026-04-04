using SmsControl.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmaControlTests.Extensions
{
    [TestClass]
    public class ByteExtensionTests
    {
        [DataTestMethod]
        [DynamicData(nameof(ByteData), DynamicDataSourceType.Method)]
        public void ToLongTests(long expected, byte[] data)
        {
            Assert.AreEqual(expected, data.ToLong());
        }

        static IEnumerable<object[]> ByteData()
        {
            yield return new object[] { 0, new byte[0] };
        }
    }
}
