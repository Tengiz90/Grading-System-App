namespace Homework5;

public partial class ManageMarksPage : ContentPage
{
    private readonly Student selectedStudent;
    private readonly CourseOfLecturer selectedCourse;

    public ManageMarksPage(Student student, CourseOfLecturer course)
    {
        InitializeComponent();

        selectedStudent = student;
        selectedCourse = course;

        studentLabel.Text = $"{selectedStudent.FullName} - {selectedCourse.Name}";
    }

    private async void OnSaveMarksClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Marks Saved",
            $"Marks saved for {selectedStudent.FullName} in {selectedCourse.Name}.",
            "OK");

        await Navigation.PopAsync();
    }
}
