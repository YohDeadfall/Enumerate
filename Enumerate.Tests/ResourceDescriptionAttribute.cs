using Enumerate.Tests.Properties;
using System.ComponentModel;

namespace Enumerate.Tests
{
    public sealed class ResourceDescriptionAttribute : DescriptionAttribute
    {
        #region Fields

        private readonly string resourceName;

        #endregion

        #region Constructors

        public ResourceDescriptionAttribute(string resourceName)
        {
            this.resourceName = resourceName;
        }

        #endregion

        #region DescriptionAttribute Membmers

        public override string Description
        {
            get { return Resources.ResourceManager.GetString(resourceName); }
        }

        #endregion
    }
}
