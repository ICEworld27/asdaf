using System;
using System.Collections.Generic;
using System.Text;

namespace students
{
    class BriefPrintVisitor : Visitor
    {
        private bool _hasStudents = false;

        public void startVisit()
        {
            _hasStudents = false;
        }
        public void visitStudent(int number, Student student)
        {
            Console.Write((number+1) + "." );
            student.print_Short();
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
