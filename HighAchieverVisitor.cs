using System;
using System.Collections.Generic;
using System.Text;

namespace students
{
    class HighAchieverVisitor : Visitor
    {
        private bool _hasStudents = false;

        public void startVisit()
        {
            _hasStudents = false;
        }
        public void visitStudent(int number, Student student)
        {
            bool good = true;
            
            foreach (KeyValuePair<string, int> item in student.marks)
            {
                if (item.Value < 5)
                {
                    good = false;
                }
            }
            if (student.marks.Count == 0)
            {
                good = false;
            }
            if (good)
            {
                Console.Write(number + ". ");
                student.print_Short();
            }
            /*
            Console.Write(number+". ");
            student.print_Short();
            */
            _hasStudents = true;
        }
        public void finishVisit()
        {
            if (!_hasStudents)
            {
                Console.WriteLine("Студентов в базе данных нет");
            }

        }
    }
}
