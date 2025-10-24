using Microsoft.Maui.Controls;
using System;

namespace Homework5
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string id = idEntry.Text?.Trim();
            string password = passwordEntry.Text;

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(password))
            {
                errorLabel.Text = "Please enter both ID and password.";
                errorLabel.IsVisible = true;
                return;
            }

            if (id == "123" && password == "test")
            {
                errorLabel.IsVisible = false;
                await DisplayAlert("Success", "Login successful!", "OK");

            }
            else
            {
                errorLabel.Text = "Invalid ID or password.";
                errorLabel.IsVisible = true;
            }
        }
    }
}
