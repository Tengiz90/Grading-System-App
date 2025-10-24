using Microsoft.Maui;

namespace Homework5;

public partial class RegisterPage : ContentPage
{
	public RegisterPage()
	{
		InitializeComponent();
	}

    private void OnRoleChanged(object sender, CheckedChangedEventArgs e)
    {
        if (studentRadio.IsChecked)
            majorEntry.IsVisible = true;
        else
            majorEntry.IsVisible = false;
    }

    private async void OnFinishClicked(object sender, EventArgs e)
    {
        string id = idEntry.Text?.Trim();
        string firstName = firstNameEntry.Text?.Trim();
        string lastName = lastNameEntry.Text?.Trim();
        string password = passwordEntry.Text;
        string repeatPassword = repeatPasswordEntry.Text;

      
        if (string.IsNullOrEmpty(id) ||
            string.IsNullOrEmpty(firstName) ||
            string.IsNullOrEmpty(lastName) ||
            string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(repeatPassword))
        {
            await DisplayAlert("Error", "Please fill in all required fields.", "OK");
            return;
        }

        if (password != repeatPassword)
        {
            await DisplayAlert("Error", "Passwords do not match.", "OK");
            return;
        }

        if (!studentRadio.IsChecked && !lecturerRadio.IsChecked)
        {
            await DisplayAlert("Error", "Please select a role.", "OK");
            return;
        }

        string role = studentRadio.IsChecked ? "Student" : "Lecturer";
        string majorOrDepartment = majorEntry.IsVisible ? majorEntry.Text?.Trim() : "";

        await DisplayAlert("Success", $"Registered {role}:\n\nID: {id}\nName: {firstName} {lastName}", "OK");

        idEntry.Text = firstNameEntry.Text = lastNameEntry.Text = passwordEntry.Text = repeatPasswordEntry.Text = "";
        studentRadio.IsChecked = lecturerRadio.IsChecked = false;
        majorEntry.IsVisible = false;
    }


}