using Homework5.Data;
using Homework5.Models;

namespace Homework5;

public partial class ManageMarksPage : ContentPage
{
    private readonly int studentId;
    private readonly int courseId;
    private readonly DataSourceManager data;

    public ManageMarksPage(int studentId, int courseId, DataSourceManager data)
    {
        InitializeComponent();

        this.studentId = studentId;
        this.courseId = courseId;
        this.data = data;

        var student = data.Students.FirstOrDefault(s => s.Id == studentId);
        var course = data.Courses.FirstOrDefault(c => c.Id == courseId);

        studentForCourseMarksLabel.Text = $"{student?.FirstName} {student?.LastName} - {course?.Name}";

        setupMarks();
    }

    private void setupMarks()
    {
        var marks = data.ViewStudentMarksByCourse(studentId, courseId);
        if (marks != null)
        {
            homework1Entry.Text = marks.Homework1.ToString();
            homework2Entry.Text = marks.Homework2.ToString();
            homework3Entry.Text = marks.Homework3.ToString();
            homework4Entry.Text = marks.Homework4.ToString();
            homework5Entry.Text = marks.Homework5.ToString();
            homework6Entry.Text = marks.Homework6.ToString();
            homework7Entry.Text = marks.Homework7.ToString();
            homework8Entry.Text = marks.Homework8.ToString();
            homework9Entry.Text = marks.Homework9.ToString();
            homework10Entry.Text = marks.Homework10.ToString();
            midtermExamEntry.Text = marks.MidtermExam.ToString();
            presentationEntry.Text = marks.Presentation.ToString();
            finalExamEntry.Text = marks.FinalExam.ToString();
        }
    }

    private async void OnSaveMarksClicked(object sender, EventArgs e)
    {
        var marks = new SingleCourseMarks
        {
            StudentId = studentId,
            CourseId = courseId,
            Homework1 = ParseMark(homework1Entry.Text),
            Homework2 = ParseMark(homework2Entry.Text),
            Homework3 = ParseMark(homework3Entry.Text),
            Homework4 = ParseMark(homework4Entry.Text),
            Homework5 = ParseMark(homework5Entry.Text),
            Homework6 = ParseMark(homework6Entry.Text),
            Homework7 = ParseMark(homework7Entry.Text),
            Homework8 = ParseMark(homework8Entry.Text),
            Homework9 = ParseMark(homework9Entry.Text),
            Homework10 = ParseMark(homework10Entry.Text),
            MidtermExam = ParseMark(midtermExamEntry.Text),
            Presentation = ParseMark(presentationEntry.Text),
            FinalExam = ParseMark(finalExamEntry.Text)
        };

        bool updated = data.ModifyStudentMarks(marks);

        if (!updated)
        {
            data.AddMark(marks);
        }

        await DisplayAlert("Marks Saved",
            $"Marks saved for {studentForCourseMarksLabel.Text}.",
            "OK");

        await Navigation.PopAsync();
    }

    private double ParseMark(string text)
    {
        return double.TryParse(text, out var result) ? result : 0;
    }
}
