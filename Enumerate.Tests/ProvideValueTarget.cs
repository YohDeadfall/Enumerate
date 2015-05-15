using System;
using System.Windows.Markup;

namespace Enumerate.Tests
{
    public sealed class ProvideValueTarget : IServiceProvider, IProvideValueTarget
    {
        #region Fields

        private readonly object targetObject;
        private readonly object targetProperty;

        #endregion

        #region Constructors

        public ProvideValueTarget(object targetObject,object targetProperty)
        {
            this.targetObject = targetObject;
            this.targetProperty = targetProperty;
        }

        #endregion

        #region IServiceProvider Members

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(IProvideValueTarget))
            { return this; }

            return null;
        }

        #endregion

        #region IProvideValueTarget Members

        public object TargetObject
        {
            get { return targetObject; }
        }

        public object TargetProperty
        {
            get { return targetProperty; }
        }

        #endregion
    }
}
