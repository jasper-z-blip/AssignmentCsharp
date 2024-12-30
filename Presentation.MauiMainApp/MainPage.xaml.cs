namespace Presentation.MauiMainApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void ExitProgramWhenClicked(object sender, EventArgs e)
        {
            Application.Current?.Quit();
        }
    }

}
