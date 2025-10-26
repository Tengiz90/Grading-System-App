using System.Collections.ObjectModel;
using Homework5.Data;
using Homework5.Models;

namespace Homework5;

public partial class CoursesOfLecturerPage : ContentPage
{
    private readonly DataSourceManager _data;
    private readonly int _lecturerId;
    public ObservableCollection<Course> Courses { get; set; }

    public CoursesOfLecturerPage(DataSourceManager data, int lecturerId)
    {
        InitializeComponent();
        _data = data;
        _lecturerId = lecturerId;
        Courses = new ObservableCollection<Course>();
        FillCoursesListWithData();
        BindingContext = this;
    }

    private void FillCoursesListWithData()
    {
        var lecturerCourses = _data.Courses.Where(c => c.LecturerId == _lecturerId);
        foreach (var course in lecturerCourses)
            Courses.Add(course);
    }

    private async void OnAddCourseClicked(object sender, EventArgs e)
    {
        string courseName = courseNameEntry.Text?.Trim();

        if (string.IsNullOrEmpty(courseName))
        {
            AddCourseErrorMesasage.Text = "Please enter a course name.";
            AddCourseErrorMesasage.IsVisible = true;
            return;
        }

        
        var newCourse = new Course
        {
            Id = _data.Courses.Any() ? _data.Courses.Max(c => c.Id) + 1 : 1,
            Name = courseName,
            LecturerId = _lecturerId
        };

      
        _data.AddCourse(newCourse);

       
        Courses.Add(newCourse);

        
        courseNameEntry.Text = string.Empty;
        AddCourseErrorMesasage.IsVisible = false;

        await DisplayAlert("Success", $"Course '{newCourse.Name}' added successfully!", "OK");
    }

    private async void OnSeeStudentsClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var course = button?.CommandParameter as Course;

        if (course != null)
        {
            await Navigation.PushAsync(new StudentsInCoursePage(course, _data));
        }
    }

}

