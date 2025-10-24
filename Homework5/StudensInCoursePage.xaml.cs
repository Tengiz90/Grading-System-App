using System.Collections.ObjectModel;

namespace Homework5;

public partial class StudentsInCoursePage : ContentPage
{
    public ObservableCollection<Student> Students { get; set; }

    private CourseOfLecturer course;

    public StudentsInCoursePage(CourseOfLecturer selectedCourse)
    {
        InitializeComponent();
        course = selectedCourse;

        courseLabel.Text = $"Students in {course.Name}";

        
        Students = new ObservableCollection<Student>
        {
            new Student { FullName = "Alice Johnson" },
            new Student { FullName = "Bob Smith" },
            new Student { FullName = "Charlie Brown" },
            new Student { FullName = "Diana Prince" }
        };

        BindingContext = this;
    }

    private async void OnManageMarksClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var student = button?.CommandParameter as Student;

        if (student != null)
        {
            await Navigation.PushAsync(new ManageMarksPage(student, course));
        }
    }
}

public class Student
{
    public string FullName { get; set; }
}
