using System.Collections.ObjectModel;
using Homework5.Data;
using Homework5.Models;

namespace Homework5;

public partial class StudentsInCoursePage : ContentPage
{
    public ObservableCollection<StudentInCourse> Students { get; set; }

    private readonly Course course;
    private readonly DataSourceManager dataSource;

    public StudentsInCoursePage(Course selectedCourse, DataSourceManager data)
    {
        InitializeComponent();
        course = selectedCourse;
        dataSource = data;

        courseLabel.Text = $"Students in {course.Name}";

        var enrolledStudents = dataSource.Students
            .Where(s => dataSource.Marks.Any(m => m.StudentId == s.Id && m.CourseId == course.Id))
            .Select(s => new StudentInCourse
            {
                StudentId = s.Id,
                FullName = $"{s.FirstName} {s.LastName}"
            })
            .ToList();

        Students = new ObservableCollection<StudentInCourse>(enrolledStudents);

        BindingContext = this;
    }

    private async void OnManageMarksClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var student = button?.CommandParameter as StudentInCourse;

        if (student != null)
        {
            await Navigation.PushAsync(new ManageMarksPage(student.StudentId, course.Id, dataSource));
        }
    }
}

public class StudentInCourse
{
    public int StudentId { get; set; }
    public string FullName { get; set; }
}
