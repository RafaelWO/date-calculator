using DateCalculator.ViewModels;

namespace DateCalculator
{
    public class Startup
    {
        public Startup()
        {
            var mainVm = new MainViewModel();
            var mainView = new MainWindow(mainVm);
            mainView.ShowDialog();
        }
    }
}
