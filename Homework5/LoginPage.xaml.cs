using Homework5.Data;
using Microsoft.Maui.Controls;
using System;
using System.Linq;

namespace Homework5
{
    public partial class LoginPage : ContentPage
    {
        private readonly DataSourceManager _data;
        private string _selectedRole = ""; 

        public LoginPage(DataSourceManager data)
        {
            InitializeComponent();
            _data = data;
        }

        private void OnRoleChanged(object sender, CheckedChangedEventArgs e)
        {
            if (studentRadio.IsChecked)
                _selectedRole = "Student";
            else if (lecturerRadio.IsChecked)
                _selectedRole = "Lecturer";
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string idText = idEntry.Text?.Trim();
            string password = passwordEntry.Text?.Trim();

            if (string.IsNullOrEmpty(idText) || string.IsNullOrEmpty(password))
            {
                ShowError("Please enter both ID and password.");
                return;
            }

            if (!int.TryParse(idText, out int id))
            {
                ShowError("Invalid ID format. ID must be a number.");
                return;
            }

            if (_selectedRole == "Student")
            {
                var student = _data.Students.FirstOrDefault(s => s.Id == id && s.Password == password);
                if (student != null)
                {
                    await DisplayAlert("Success", $"Welcome, {student.FirstName} {student.LastName}!", "OK");
                    errorLabel.IsVisible = false;
                    await Navigation.PushAsync(new CoursesForStudentsPage(_data, student.Id));
                }
            }
            else if (_selectedRole == "Lecturer")
            {
                var lecturer = _data.Lecturers.FirstOrDefault(l => l.Id == id && l.Password == password);
                if (lecturer != null)
                {
                    await DisplayAlert("Success", $"Welcome, {lecturer.FirstName} {lecturer.LastName}!", "OK");
                    errorLabel.IsVisible = false;
                    await Navigation.PushAsync(new CoursesOfLecturerPage(_data, lecturer.Id));
                }
            } else
            {
                ShowError("Please select a role.");
                return;
            }

            ShowError("Invalid ID or password.");
        }

        private void ShowError(string message)
        {
            errorLabel.Text = message;
            errorLabel.IsVisible = true;
        }
    }
}
