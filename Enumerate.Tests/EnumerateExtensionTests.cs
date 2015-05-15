using Enumerate.Tests.Properties;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Resources;
using System.Windows;
using System.Windows.Markup;

namespace Enumerate.Tests
{
    [TestClass]
    public sealed class EnumerateExtensionTests
    {
        #region Public Methods

        [TestMethod]
        public void DetectCulture()
        {
            ResourceManager resourceManager = Resources.ResourceManager;
            CultureInfo cultureInfo = new CultureInfo("ee-EE");

            CollectionAssert.AreEquivalent(
                new string[]
                {
                    resourceManager.GetString("Cat", cultureInfo),
                    resourceManager.GetString("Dog", cultureInfo)
                },
                new EnumerateExtension(typeof(Animal)) { Converter = new AnimalToStringConverter() }
                    .ProvideValue(
                        new ProvideValueTarget(
                            new FrameworkElement() { Language = XmlLanguage.GetLanguage(cultureInfo.Name) },
                            FrameworkElement.LanguageProperty
                            )
                        ) as object[]
                );
        }

        [TestMethod]
        public void ProvideValueForBoolean()
        {
            CollectionAssert.AreEquivalent(
                new bool[] { true, false },
                new EnumerateExtension(typeof(bool)).ProvideValue(null) as object[]
                );
        }

        [TestMethod]
        public void ProvideValueForNullableBoolean()
        {
            CollectionAssert.AreEquivalent(
                new bool?[] { true, false, null },
                new EnumerateExtension(typeof(bool?)).ProvideValue(null) as object[]
                );
        }

        [TestMethod]
        public void ProvideValueForEnum()
        {
            CollectionAssert.AreEquivalent(
                new Animal[] { Animal.Cat, Animal.Dog },
                new EnumerateExtension(typeof(Animal)).ProvideValue(null) as object[]
                );
        }

        [TestMethod]
        public void ProvideValueForNullableEnum()
        {
            CollectionAssert.AreEquivalent(
                new Animal?[] { Animal.Cat, Animal.Dog, null },
                new EnumerateExtension(typeof(Animal?)).ProvideValue(null) as object[]
                );
        }

        [TestMethod]
        public void ProvideValueUsingConverter()
        {
            CollectionAssert.AreEquivalent(
                new string[] { Resources.Cat, Resources.Dog, Resources.NotSet },
                new EnumerateExtension(typeof(Animal?)) { Converter = new AnimalToStringConverter() }.ProvideValue(null) as object[]
                );
        }

        #endregion
    }
}
