using Homework5.Data;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Homework5
{
    public partial class CoursesForStudentsPage : ContentPage
    {
        private readonly DataSourceManager _data;
        private readonly int _studentId;
        public ObservableCollection<CourseForStudents> Courses { get; set; }

        public CoursesForStudentsPage(DataSourceManager data, int studentId)
        {

            InitializeComponent();
            _data = data;
            _studentId = studentId;

            Courses = new ObservableCollection<CourseForStudents>(
                _data.Courses.Select(c => new CourseForStudents
                {
                    Name = c.Name,
                    Id = c.Id,
                    IsEnrolled = _data.Marks.Any(m => m.StudentId == studentId && m.CourseId == c.Id),
                    ButtonText = _data.Marks.Any(m => m.StudentId == studentId && m.CourseId == c.Id)
                        ? "Unenroll"
                        : "Enroll"
                })
            );

            BindingContext = this;
        }

        private void OnEnrollToggleClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is CourseForStudents course)
            {
                var courseEntity = _data.Courses.FirstOrDefault(c => c.Name == course.Name);
                if (courseEntity == null) return;

                if (course.IsEnrolled)
                {
                    _data.UnenrollStudentInTheCourse(_studentId, courseEntity.Id);
                    course.IsEnrolled = false;
                    course.ButtonText = "Enroll";
                }
                else
                {
                    _data.EnrollStudentInTheCourse(_studentId, courseEntity.Id);
                    course.IsEnrolled = true;
                    course.ButtonText = "Unenroll";
                }
            }
        }

        private async void OnSeeMarksClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var course = button?.CommandParameter as CourseForStudents;
            if (course != null)
            {
                await Navigation.PushAsync(new ShowMarksPage(_data, _studentId, course.Id));

            }
        }
    }

    public class CourseForStudents : BindableObject
    {
        private bool isEnrolled;
        private string buttonText = "Enroll";

        public string Name { get; set; }
        public int Id { get; set; }



        public bool IsEnrolled
        {
            get => isEnrolled;
            set
            {
                if (isEnrolled != value)
                {
                    isEnrolled = value;
                    OnPropertyChanged();
                }
            }
        }

        public string ButtonText
        {
            get => buttonText;
            set
            {
                if (buttonText != value)
                {
                    buttonText = value;
                    OnPropertyChanged();
                }
            }
        }


    }
}
