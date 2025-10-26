using System.Threading.Tasks;
using Homework5.Data;

namespace Homework5
{
    public partial class MainPage : ContentPage
    {
        private readonly DataSourceManager _data;

        public MainPage(DataSourceManager data)
        {
            InitializeComponent();
            _data = data;
        }

        private async void OnLoginClicked(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.IsEnabled = false;
                await Navigation.PushAsync(new LoginPage(_data));
                btn.IsEnabled = true; 
            }
        
        }

        private async void OnRegisterClicked(object? sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                btn.IsEnabled = false; 
                await Navigation.PushAsync(new RegisterPage(_data));
                btn.IsEnabled = true; 
            }
        }
    }
}
