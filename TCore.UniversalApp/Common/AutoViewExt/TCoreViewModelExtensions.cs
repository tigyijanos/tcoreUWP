using System;
using System.Collections.Generic;
using System.Linq;
using TCore.UniversalApp.Interfaces.Common;
using Windows.UI.Xaml;

namespace TCore.UniversalApp.Common.AutoViewExt
{
    public static class TCoreViewModelExtensions
    {
        internal static Dictionary<string, Type> _registeredViews = new Dictionary<string, Type>();

        /// <summary>
        /// Registers a viewType for a viewModel
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="view"></param>
        public static void RegisterView(this ITCoreViewModel viewModel, ITCoreView view)
        {
            var viewType = view.GetType();

            var stringKey = viewModel.ViewKey.ToString();

            if (!_registeredViews.TryGetValue(stringKey, out Type registeredView))
            {
                _registeredViews.Add(stringKey, viewType);
            }
        }

        /// <summary>
        /// Gets a new instance of a view for viewmodel
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        public static FrameworkElement GetViewForViewModel(this ITCoreViewModel viewModel)
        {
            if (viewModel.ViewKey != null && _registeredViews.TryGetValue(viewModel.ViewKey.ToString(), out Type registeredView))
            {
                return Activator.CreateInstance(registeredView) as FrameworkElement;
            }

            return null;
        }

        /// <summary>
        /// Removes the registration of view by viewmodel's key
        /// </summary>
        /// <param name="viewModel"></param>
        /// <param name="view"></param>
        public static void UnregisterView(this ITCoreViewModel viewModel, ITCoreView view)
        {
            var viewType = view.GetType();
            var viewModelName = nameof(viewModel);

            var key = viewType.Name + viewModelName;

            _registeredViews = _registeredViews.Where(x => x.Key != key)
                                                .ToDictionary(x => x.Key, x => x.Value);
        }
    }
}
