using System;
using System.Collections.Generic;
using System.Reflection;
using TCore.UniversalApp.Interfaces.Common;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Linq;
using Windows.UI.Xaml.Data;
using TCore.UniversalApp.Common.Animations;

using AutoviewExt = TCore.UniversalApp.Common.AutoViewExt;
using System.Threading;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace TCore.UniversalApp.Common
{
    public sealed partial class AutoView : UserControl
    {
        private static Dictionary<string, FrameworkElement> _viewCache = new Dictionary<string, FrameworkElement>();
        private static List<SimpleAnimation> _simpleAnimationList = new List<SimpleAnimation>();

        public int AnimationsLengthMilliSecond
        {
            get { return (int)GetValue(AnimationsLengthMilliSecondProperty); }
            set { SetValue(AnimationsLengthMilliSecondProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AnimationsLengthMilliSecond.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnimationsLengthMilliSecondProperty =
            DependencyProperty.Register("AnimationsLengthMilliSecond", typeof(int), typeof(AutoView), new PropertyMetadata(500));

        public List<string> PreCacheableViewsNameList
        {
            get { return (List<string>)GetValue(PreCacheableViewsNameListProperty); }
            set { SetValue(PreCacheableViewsNameListProperty, value); }
        }

        public static void ClearCachedViews()
        {
            _viewCache.Clear();
        }

        // Using a DependencyProperty as the backing store for PreCacheableViewsNameList.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PreCacheableViewsNameListProperty =
            DependencyProperty.Register("PreCacheableViewsNameList", typeof(List<string>), typeof(AutoView), new PropertyMetadata(null, OnPreCacheableViewsNameListPropertyChanged));

        private static void OnPreCacheableViewsNameListPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as AutoView;

            var listForActivate = e.NewValue as List<string>;

            if (listForActivate != null && listForActivate.Count > 0)
            {
                var viewModelAssembly = Assembly.Load(new AssemblyName(control.AssemblyNameForViews));

                foreach (var itemForActivate in listForActivate)
                {
                    ActivateViewOrGetFromCache(control, itemForActivate, viewModelAssembly);
                }
            }
        }

        public bool IsViewCacheAble
        {
            get { return (bool)GetValue(IsViewCacheAbleProperty); }
            set { SetValue(IsViewCacheAbleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsViewCacheAble.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsViewCacheAbleProperty =
            DependencyProperty.Register("IsViewCacheAble", typeof(bool), typeof(AutoView), new PropertyMetadata(false));



        public bool IsAnimated
        {
            get { return (bool)GetValue(IsAnimatedProperty); }
            set { SetValue(IsAnimatedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsAnimated.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsAnimatedProperty =
            DependencyProperty.Register("IsAnimated", typeof(bool), typeof(AutoView), new PropertyMetadata(false));



        public ITCoreViewModel ViewModel
        {
            get { return (ITCoreViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(ITCoreViewModel), typeof(AutoView), new PropertyMetadata(null, OnViewModelPropertyChanged));

        public string AssemblyNameForViews
        {
            get { return (string)GetValue(AssemblyNameForViewsProperty); }
            set { SetValue(AssemblyNameForViewsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AssemblyNameForViews.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AssemblyNameForViewsProperty =
            DependencyProperty.Register("AssemblyNameForViews", typeof(string), typeof(AutoView), new PropertyMetadata(string.Empty));

        public string NameSpaceForViews
        {
            get { return (string)GetValue(NameSpaceForViewsProperty); }
            set { SetValue(NameSpaceForViewsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NameSpaceForViews.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameSpaceForViewsProperty =
            DependencyProperty.Register("NameSpaceForViews", typeof(string), typeof(AutoView), new PropertyMetadata(string.Empty, OnNameSpacePropertyForViewsChanged));

        private static string _nameSpaceForViewsString = "";

        private static void OnNameSpacePropertyForViewsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (d as AutoView);
            var nVal = e.NewValue.ToString();
            AutoView._nameSpaceForViewsString = nVal;
        }

        public enum AutoViewInitStates
        {
            Initializing,
            Initialized,
            InitFailed,
        }

        private static void OnViewModelPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (d as AutoView);
            var viewModel = (e.NewValue as ITCoreViewModel);

            VisualStateManager.GoToState(control, AutoViewInitStates.Initializing.ToString(), true);

            if (viewModel != null)
            {
                // tries to get view if it's registered for viewmodel
                var activatedView = AutoviewExt.TCoreViewModelExtensions.GetViewForViewModel(viewModel);

                if (activatedView is null)
                {
                    // tries to find the view if it's not registered for viewModel
                    string viewName = viewModel.GetType().Name.Replace("ViewModel", "View");

                    var viewModelAssembly = Assembly.Load(new AssemblyName(control.AssemblyNameForViews));

                    activatedView = ActivateViewOrGetFromCache(control, viewName, viewModelAssembly);
                }

                activatedView.SetBinding(DataContextProperty, new Binding() { Source = viewModel });

                if (!control.autoViewGrid.Children.Contains(activatedView))
                {
                    activatedView.Loaded += ActivatedView_Loaded;
                    control.autoViewGrid.Children.Add(activatedView);
                }
                else
                {
                    ActivatedView_Loaded(activatedView, null);
                }
            }
        }

        /// <summary>
        /// Creates a new instance of view or gets from cache
        /// </summary>
        /// <param name="control"></param>
        /// <param name="viewName"></param>
        /// <param name="viewModelAssembly"></param>
        /// <returns></returns>
        private static FrameworkElement ActivateViewOrGetFromCache(AutoView control, string viewName, Assembly viewModelAssembly)
        {
            FrameworkElement activatedView;
            if (control.IsViewCacheAble)
            {
                if (!_viewCache.TryGetValue(viewName, out activatedView))
                {
                    activatedView = ActivateView(viewName, viewModelAssembly);
                    _viewCache.Add(viewName, activatedView);
                }
            }
            else
            {
                activatedView = ActivateView(viewName, viewModelAssembly);
            }

            return activatedView;
        }
        
        /// <summary>
        /// Activate a new instance of view
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="viewModelAssembly"></param>
        /// <returns></returns>
        private static FrameworkElement ActivateView(string viewName, Assembly viewModelAssembly)
        {
            FrameworkElement activatedView;
            var viewType = viewModelAssembly.GetType(string.Format("{0}.{1}", AutoView._nameSpaceForViewsString, viewName)) /*?? typeof(ViewNotFound)*/;

            activatedView = (FrameworkElement)(Activator.CreateInstance(viewType));
            return activatedView;
        }

        private static async void ActivatedView_Loaded(object sender, RoutedEventArgs e)
        {
            await ((sender as FrameworkElement).DataContext as ITCoreViewModel).InitializeViewModel();

            try
            {
                VisualStateManager.GoToState((((((sender as FrameworkElement).Parent) as FrameworkElement)
                    .Parent as FrameworkElement)
                    .Parent as AutoView), AutoViewInitStates.Initialized.ToString(), true);

                CreateAnimationForViews(sender);

                (sender as FrameworkElement).Loaded -= ActivatedView_Loaded;
            }
            catch
            {
                // TODO : lekezelni a hibát
            }
        }

        private static void CreateAnimationForViews(object sender)
        {
            var autoView = (((((sender as FrameworkElement).Parent) as FrameworkElement).Parent as FrameworkElement).Parent as AutoView);

            int animationLength = 0;

            if (autoView.IsAnimated)
            {
                animationLength = autoView.AnimationsLengthMilliSecond;
            }

            var controlWidth = autoView.autoViewGrid.ActualWidth;

            var newViewAnimation = new SimpleAnimation(sender as FrameworkElement, TimeSpan.FromMilliseconds(animationLength), 0 - controlWidth, 0, AnimationType.Normal, AnimationOrientation.Horizontal);

            if (autoView.autoViewGrid.Children.Count > 1)
            {
                var unWantedView = autoView.autoViewGrid.Children.FirstOrDefault(i => i != sender && _simpleAnimationList.Any(j => j.AtachedFrameworkElement == i) == false);

                if (unWantedView != null)
                {
                    _simpleAnimationList.Add(new SimpleAnimation(unWantedView as FrameworkElement,
                        TimeSpan.FromMilliseconds(animationLength),
                        0, 0 + controlWidth,
                        AnimationType.Normal,
                        AnimationOrientation.Horizontal,
                        (ss) =>
                            {
                                autoView.autoViewGrid.Children.Remove(ss as FrameworkElement);
                                _simpleAnimationList.Remove(_simpleAnimationList.First(i => i.AtachedFrameworkElement == ss));
                            }));

                    _simpleAnimationList.Last().PlayAnimation();
                }

                newViewAnimation.PlayAnimation();
            }
        }

        public AutoView()
        {
            this.InitializeComponent();
            VisualStateManager.GoToState(this, AutoViewInitStates.Initialized.ToString(), false);
        }

        /// <summary>
        /// Clipping the maingrid prevent uggly animations
        /// </summary>
        private void ClipAutoviewMainGrid(object sender, SizeChangedEventArgs e)
        {
            Grid mainGrid = sender as Grid;

            mainGrid.Clip = new RectangleGeometry();
            mainGrid.Clip.Rect = new Windows.Foundation.Rect(0, 0, this.ActualWidth, this.ActualHeight);
        }
    }
}
