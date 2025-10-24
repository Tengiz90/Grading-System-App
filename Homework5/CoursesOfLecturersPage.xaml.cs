using System.Collections.ObjectModel;

namespace Homework5;

public partial class CoursesOfLecturersPage : ContentPage
{
    public ObservableCollection<CourseOfLecturer> Courses { get; set; }

    public CoursesOfLecturersPage()
    {
        InitializeComponent();

        Courses = new ObservableCollection<CourseOfLecturer>
        {
            new CourseOfLecturer { Name = "Object-Oriented Programming" },
            new CourseOfLecturer { Name = "Database Systems"},
            new CourseOfLecturer { Name = "Mobile App Development" },
            new CourseOfLecturer { Name = "Web Development"  },
            new CourseOfLecturer { Name = "Data Structures" }
        };

        BindingContext = this;
    }

    private async void OnSeeStudentsClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var course = button?.CommandParameter as CourseOfLecturer;

        if (course != null)
        {
            await Navigation.PushAsync(new StudentsInCoursePage(course));
        }
    }

}

public class CourseOfLecturer
{
    public string Name { get; set; }
}
