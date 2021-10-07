using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Delegates_1
{
    class Program
    {
        public delegate List<Student> FilterStud(List<Student> students);
        public delegate bool CheckIfContains(Student student);
        public delegate int SumStudArg(List<Student> students);
        public delegate double AvgStudArg(List<Student> students);
        static void Main(string[] args)
        {

            StudentList sl = new StudentList();

            Student s = new Student { FullName = "Avi", Age = 26, Grade = 80 };
            Student s1 = new Student { FullName = "Tali", Age = 31, Grade = 95 };
            Student s2 = new Student { FullName = "Riki", Age = 22, Grade = 100 };
            Student s3 = new Student { FullName = "Ran", Age = 52, Grade = 55 };
            sl.AddStudent(s);
            sl.AddStudent(s1);
            sl.AddStudent(s2);
            sl.AddStudent(s3);


            FilterStud byGrade = FilterByGradeUpTo90;
            FilterStud byName = FilterByLengthName;
            List<Student> ls = sl.Filter(byGrade);
            List<Student> ls2 = sl.Filter(byName);

            CheckIfContains cicByStartWith = new CheckIfContains(ContainsNameStartWithA);
            CheckIfContains cicByAgeIs = ContainsAgeIs25;
            bool isExist = sl.Contains(cicByStartWith);
            bool isExist2 = sl.Contains(cicByAgeIs);

            SumStudArg staGrade = SumGrade;
            SumStudArg staAges = SumAges;
            int sumGrades = sl.Sum(staGrade);
            int sumAges = sl.Sum(staAges);

            AvgStudArg ataGrade = AvgGrade;
            AvgStudArg ataAges = AvgAges;
            double avgGrades = sl.Avg(ataGrade);
            double avgAges = sl.Avg(ataAges);
        }

        #region Filter Methods
        static List<Student> FilterByGradeUpTo90(List<Student> students)
        {
            List<Student> filteredList = students.Where(s => s.Grade > 90).ToList();
            return filteredList;
        }

        static List<Student> FilterByLengthName(List<Student> students)
        {
            List<Student> filteredList = students.Where(s => s.FullName.Length > 3).ToList();
            return filteredList;
        }
        #endregion

        #region Contains Methods
        static bool ContainsNameStartWithA(Student s)
        {
            return s.FullName.StartsWith("A");
        }

        static bool ContainsAgeIs25(Student s)
        {
            return s.Age == 25;
        }
        #endregion

        #region Sum Methods

        static int SumGrade(List<Student> students)
        {
            int sumGrades = 0;
            foreach (Student stud in students)
            {
                sumGrades += (int)stud.Grade;
            }
            return sumGrades;
        }

        static int SumAges(List<Student> students)
        {
            int sumAges = 0;
            foreach (Student stud in students)
            {
                sumAges += (int)stud.Age;
            }
            return sumAges;
        }
        #endregion

        #region Avarege Methods

        static double AvgGrade(List<Student> students)
        {
            double sumGrades = 0;
            foreach (Student stud in students)
            {
                sumGrades += stud.Grade;
            }
            return sumGrades / students.Count;
        }

        static double AvgAges(List<Student> students)
        {
            double sumAges = 0;
            foreach (Student stud in students)
            {
                sumAges += stud.Age;
            }
            return sumAges / students.Count;
        }

        #endregion
    }
}

}
