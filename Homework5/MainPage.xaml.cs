using System.Threading.Tasks;

namespace Homework5
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }

        private async void OnRegisterClicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
