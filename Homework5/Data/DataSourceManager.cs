
using Homework5.Models;

namespace Homework5.Data
{
    public class DataSourceManager
    {
        private readonly List<Course> _courses = new();
        private readonly List<Lecturer> _lecturers = new();
        private readonly List<SingleCourseMarks> _marks = new();
        private readonly List<Student> _students = new();

        public IReadOnlyList<Course> Courses => _courses;
        public IReadOnlyList<Lecturer> Lecturers => _lecturers;
        public IReadOnlyList<SingleCourseMarks> Marks => _marks;
        public IReadOnlyList<Student> Students => _students;

        public void AddStudent(Student student) => _students.Add(student);
        public void AddCourse(Course course) => _courses.Add(course);
        public void AddLecturer(Lecturer lecturer) => _lecturers.Add(lecturer);
        public void AddMark(SingleCourseMarks mark) => _marks.Add(mark);

        public bool RemoveStudentById(int id)
        {
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _students.Remove(student);
                return true;
            }
            return false;
        }
        public bool RemoveLecturerById(int id)
        {
            var lecturer = _lecturers.FirstOrDefault(l => l.Id == id);
            if (lecturer != null)
            {
                _lecturers.Remove(lecturer);
                return true;
            }
            return false;
        }
        public bool RemoveCourseById(int id)
        {
            var course = _courses.FirstOrDefault(c => c.Id == id);
            if (course != null)
            {
                _courses.Remove(course);
                return true;
            }
            return false;
        }

        public bool EnrollStudentInTheCourse(int studentId, int courseId)
        {
            var student = _students.FirstOrDefault(s => s.Id == studentId);
            var course = _courses.FirstOrDefault(c => c.Id == courseId);

            if (student == null || course == null)
                return false;


            bool alreadyEnrolled = _marks.Any(m => m.StudentId == studentId && m.CourseId == courseId);
            if (alreadyEnrolled)
                return false;

            _marks.Add(new SingleCourseMarks
            {
                StudentId = studentId,
                CourseId = courseId,
                MidtermExam = 0,
                FinalExam = 0,
                Presentation = 0,
                Homework1 = 0,
                Homework2 = 0,
                Homework3 = 0,
                Homework4 = 0,
                Homework5 = 0,
                Homework6 = 0,
                Homework7 = 0,
                Homework8 = 0,
                Homework9 = 0,
                Homework10 = 0,
            });

            return true;
        }
        public bool UnenrollStudentInTheCourse(int studentId, int courseId)
        {
            var mark = _marks.FirstOrDefault(m => m.StudentId == studentId && m.CourseId == courseId);
            if (mark == null)
                return false;

            _marks.Remove(mark);
            return true;
        }
        public bool ModifyStudentMarks(SingleCourseMarks updatedMarks)
        {
            var marks = _marks.FirstOrDefault(m =>
               m.StudentId == updatedMarks.StudentId &&
               m.CourseId == updatedMarks.CourseId);

            if (marks == null)
                return false;

            marks.MidtermExam = updatedMarks.MidtermExam;
            marks.FinalExam = updatedMarks.FinalExam;
            marks.Presentation = updatedMarks.Presentation;
            marks.Homework1 = updatedMarks.Homework1;
            marks.Homework2 = updatedMarks.Homework2;
            marks.Homework3 = updatedMarks.Homework3;
            marks.Homework4 = updatedMarks.Homework4;
            marks.Homework5 = updatedMarks.Homework5;
            marks.Homework6 = updatedMarks.Homework6;
            marks.Homework7 = updatedMarks.Homework7;
            marks.Homework8 = updatedMarks.Homework8;
            marks.Homework9 = updatedMarks.Homework9;
            marks.Homework10 = updatedMarks.Homework10;
            return true;
        }
        public SingleCourseMarks? ViewStudentMarksByCourse(int studentId, int courseId)
        {
            var marks = _marks.FirstOrDefault(m => m.StudentId == studentId && m.CourseId == courseId);

            return marks;


        }
    }
}
