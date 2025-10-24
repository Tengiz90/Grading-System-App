using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace Homework5
{
    public partial class CoursesForStudentsPage : ContentPage
    {
        public ObservableCollection<CourseForStudents> Courses { get; set; }

        public CoursesForStudentsPage()
        {
            InitializeComponent();

            Courses = new ObservableCollection<CourseForStudents>
            {
                new CourseForStudents { Name = "Object-Oriented Programming"},
                new CourseForStudents { Name = "Database Systems." },
                new CourseForStudents { Name = "Mobile App Development"},
                new CourseForStudents { Name = "Web Development"},
                new CourseForStudents { Name = "Data Structures" }
            };

            BindingContext = this;
        }

        private void OnEnrollClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is CourseForStudents course)
            {
                course.IsEnrolled = !course.IsEnrolled;
                course.ButtonText = course.IsEnrolled ? "Unenroll" : "Enroll";
            }
        }

        private void OnSeeMarksClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var course = button?.CommandParameter as CourseForStudents;
            if (course != null)
            {
                // Navigate to a Marks page or display course marks
                DisplayAlert("Marks", $"Showing marks for {course.Name}", "OK");
            }
        }
    }

    public class CourseForStudents : BindableObject
    {
        private bool isEnrolled;
        private string buttonText = "Enroll";

        public string Name { get; set; }
       

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
