using Homework5.Data;
using Microsoft.Maui.Controls;

namespace Homework5
{
    public partial class ShowMarksPage : ContentPage
    {
        private readonly DataSourceManager _data;

        public ShowMarksPage(DataSourceManager data, int studentId, int courseId)
        {
            InitializeComponent();
            _data = data;

            var marks = _data.ViewStudentMarksByCourse(studentId, courseId);

            if (marks == null)
            {
                studentForCourseMarksLabel.Text = "No marks available for this course.";
                return;
            }


            homework1Label.Text = marks.Homework1.ToString();
            homework2Label.Text = marks.Homework2.ToString();
            homework3Label.Text = marks.Homework3.ToString();
            homework4Label.Text = marks.Homework4.ToString();
            homework9Label.Text = marks.Homework9.ToString();
            homework5Label.Text = marks.Homework5.ToString();
            homework6Label.Text = marks.Homework6.ToString();
            homework7Label.Text = marks.Homework7.ToString();
            homework8Label.Text = marks.Homework8.ToString();
            homework10Label.Text = marks.Homework10.ToString();
            midtermExamLabel.Text = marks.MidtermExam.ToString();
            presentationLabel.Text = marks.Presentation.ToString();
            finalExamLabel.Text = marks.FinalExam.ToString();

            var student = data.Students.FirstOrDefault(s => s.Id == studentId);
            var course = data.Courses.FirstOrDefault(c => c.Id == courseId);

            studentForCourseMarksLabel.Text = $"{student?.FirstName} {student?.LastName} - {course?.Name}";        }
    }
}
