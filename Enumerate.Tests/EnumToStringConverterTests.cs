using Enumerate.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Enumerate.Tests
{
    [TestClass]
    public sealed class EnumToStringConverterTests
    {
        #region Public Methods

        [TestMethod]
        public void Convert()
        {
            EnumToStringConverter converter = new EnumToStringConverter();

            Assert.AreEqual(Resources.Cat, converter.Convert(Animal.Cat, typeof(string), null, null));
            Assert.AreEqual(Resources.Dog, converter.Convert(Animal.Dog, typeof(string), null, null));
        }

        [TestMethod]
        public void ConvertBack()
        {
            EnumToStringConverter converter = new EnumToStringConverter();

            Assert.AreEqual(Animal.Cat, converter.ConvertBack(Resources.Cat, typeof(Animal), null, null));
            Assert.AreEqual(Animal.Dog, converter.ConvertBack(Resources.Dog, typeof(Animal), null, null));
        }

        #endregion
    }
}
