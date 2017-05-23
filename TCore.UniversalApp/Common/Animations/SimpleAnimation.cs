using System;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace TCore.UniversalApp.Common.Animations
{
    public class SimpleAnimation
    {
        public Storyboard AnimationStoryBoard;
        public FrameworkElement AtachedFrameworkElement;
        private bool _isFinishedAnimation;
        private Action<object> _actionAfterStops;

        public void PlayAnimation()
        {
            AnimationStoryBoard.Completed += _storyBoard_Completed;
            AnimationStoryBoard.Begin();
        }

        public void PlayAnimation(Action<object> actionAfterStopsWithAttachedElement)
        {
            _actionAfterStops = actionAfterStopsWithAttachedElement;
            AnimationStoryBoard.Completed += _storyBoard_Completed;
            AnimationStoryBoard.Begin();
        }

        public async Task PlayAnimationAndWaitUntilStops()
        {
            AnimationStoryBoard.Completed += _storyBoard_Completed;
            AnimationStoryBoard.Begin();

            while (!_isFinishedAnimation)
            {
                await Task.Delay(50);
            }
        }

        private void _storyBoard_Completed(object sender, object e)
        {
            AnimationStoryBoard.Completed -= _storyBoard_Completed;
            AnimationStoryBoard.Stop();
            AnimationStoryBoard.Seek(TimeSpan.FromMilliseconds(0));

            _actionAfterStops?.Invoke(AtachedFrameworkElement);

            _isFinishedAnimation = true;
        }

        public SimpleAnimation(FrameworkElement frameworkElement, TimeSpan length, double startPosition, double endPosition, AnimationType animationType, AnimationOrientation orientation)
        {
            AtachedFrameworkElement = frameworkElement;
            AnimationStoryBoard = new Storyboard();

            DoubleAnimationUsingKeyFrames animationKeyFramesNewView = AddKeyFrame(endPosition, startPosition, TimeSpan.FromMilliseconds(0), length);

            AddAnimationToStoryBoard(AtachedFrameworkElement, AnimationStoryBoard, animationKeyFramesNewView, orientation);
        }

        public SimpleAnimation(FrameworkElement frameworkElement, TimeSpan length, double startPosition, double endPosition, AnimationType animationType, AnimationOrientation orientation, Action<object> actionAfterStopsWithAttachedElement)
        {
            AtachedFrameworkElement = frameworkElement;
            AnimationStoryBoard = new Storyboard();
            _actionAfterStops = actionAfterStopsWithAttachedElement;

            DoubleAnimationUsingKeyFrames animationKeyFramesNewView = AddKeyFrame(endPosition, startPosition, TimeSpan.FromMilliseconds(0), length);

            AddAnimationToStoryBoard(AtachedFrameworkElement, AnimationStoryBoard, animationKeyFramesNewView, orientation);
        }

        private DoubleAnimationUsingKeyFrames AddKeyFrame(double endValue, double startValue, TimeSpan timeStart, TimeSpan time)
        {
            DoubleAnimationUsingKeyFrames animationKeyFrames = new DoubleAnimationUsingKeyFrames();
            var keyFrameStart = new EasingDoubleKeyFrame();
            keyFrameStart.KeyTime = KeyTime.FromTimeSpan(timeStart);
            keyFrameStart.Value = startValue;
            keyFrameStart.EasingFunction = new CubicEase();
            keyFrameStart.EasingFunction.EasingMode = EasingMode.EaseIn;

            var keyFrameEnd = new EasingDoubleKeyFrame();
            keyFrameEnd.KeyTime = KeyTime.FromTimeSpan(time);

            animationKeyFrames.KeyFrames.Add(keyFrameStart);

            animationKeyFrames.KeyFrames.Add(keyFrameEnd);

            keyFrameEnd.Value = endValue;
            keyFrameEnd.EasingFunction = new CubicEase();
            keyFrameEnd.EasingFunction.EasingMode = EasingMode.EaseInOut;
            return animationKeyFrames;
        }

        private void AddAnimationToStoryBoard(object view, Storyboard storyBoard, DoubleAnimationUsingKeyFrames animationKeyFrames, AnimationOrientation orientation)
        {
            if (orientation == AnimationOrientation.Horizontal)
            {
                Storyboard.SetTargetProperty(animationKeyFrames, "(UIElement.Projection).(PlaneProjection.GlobalOffsetX)");
            }
            else if (orientation == AnimationOrientation.Vertical)
            {
                Storyboard.SetTargetProperty(animationKeyFrames, "(UIElement.Projection).(PlaneProjection.GlobalOffsetY)");
            }

            (view as UIElement).Projection = new PlaneProjection() { GlobalOffsetY = 0, GlobalOffsetX = 0 };

            Storyboard.SetTarget(animationKeyFrames, view as UIElement);
            storyBoard.Children.Add(animationKeyFrames);
        }
    }
}
