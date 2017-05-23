using TCore.UniversalApp;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TestApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            atv.AssemblyNameForViews = "TestApp";
            atv.NameSpaceForViews = "TestApp";
            atv.ViewModel = new TestViewModel();
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            atv.ViewModel = new TestViewModel();
        }

        private void Button_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            atv.ViewModel = new TestBViewModel();
        }
    }
}
