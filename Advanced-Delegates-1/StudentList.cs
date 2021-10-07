using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Advanced_Delegates_1.Program;

namespace Advanced_Delegates_1
{
    class StudentList
    {
        public List<Student> Students { get; set; }

        public StudentList()
        {
            Students = new List<Student>();
        }
        public void AddStudent(Student s)
        {
            Students.Add(s);
        }

        public void RemoveStudent(Student s)
        {
            Students.Remove(s);
        }

        public List<Student> Filter(FilterStud filterDelegate)
        {
            return filterDelegate.Invoke(Students);
        }

        public bool Contains(CheckIfContains condDel)
        {
            return Students.Exists((stud) => condDel.Invoke(stud));
            //foreach (Student student in Students)
            //{
            //    if (condDel.Invoke(student))
            //        return true;
            //}
            //return false;
        }

        public int Sum(SumStudArg sumDel)
        {
            return sumDel(Students);
        }

        public double Avg(AvgStudArg avgDel)
        {
            return avgDel(Students);
        }

    }

    class Student
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
    }
}
