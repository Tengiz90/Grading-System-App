using Homework5.Data;
using Homework5.Models;
using Microsoft.Maui;

namespace Homework5;

public partial class RegisterPage : ContentPage
{


    private readonly DataSourceManager _data;

    public RegisterPage(DataSourceManager data)
    {
        InitializeComponent();
        _data = data;
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
        DateOnly birthDate = DateOnly.FromDateTime(dobPicker.Date);



        if (string.IsNullOrEmpty(id) ||
            string.IsNullOrEmpty(firstName) ||
            string.IsNullOrEmpty(lastName) ||
            string.IsNullOrEmpty(password) ||
            string.IsNullOrEmpty(repeatPassword))
        {
            await DisplayAlert("Error", "Please fill in all fields.", "OK");
            return;
        }

        if (!int.TryParse(id, out int idInt))
        {
            await DisplayAlert("Error", "Student id must be a whole number", "OK");
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

        if (role == "Student")
        {
            if (string.IsNullOrEmpty(majorEntry.Text))
            {
                await DisplayAlert("Error", "Please fill in Major field.", "OK");
                return;
            }
            if (_data.Students.Any(student => student.Id == idInt))
            {
                await DisplayAlert("Error", "A student with this ID already exists.", "OK");
                return;
            }
            _data.AddStudent(new Models.Student
            {
                Id = idInt,
                FirstName = firstName,
                LastName = lastName,
                DateOfBith = birthDate,
                Major = majorOrDepartment,
                Password = password
            });

        }
        else
        {
            if (_data.Lecturers.Any(l => l.Id == idInt))
            {
                await DisplayAlert("Error", "A lecturer with this ID already exists.", "OK");
                return;
            }

            _data.AddLecturer(new Models.Lecturer
            {
                Id = idInt,
                FirstName = firstName,
                LastName = lastName,
                DateOfBith = birthDate,
                Password = password
            });
        }

        await DisplayAlert("Success", $"Registered {role}:\n\nID: {id}\nName: {firstName} {lastName}", "OK");
        idEntry.Text = firstNameEntry.Text = lastNameEntry.Text = passwordEntry.Text = repeatPasswordEntry.Text = "";
        studentRadio.IsChecked = lecturerRadio.IsChecked = false;
        majorEntry.Text = "";
        majorEntry.IsVisible = false;
        dobPicker.Date = DateTime.Today;

    }


}