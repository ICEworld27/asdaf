using System;
using System.Collections.Generic;
using System.Text;

namespace students
{

    interface  Visitor
    {
        abstract void startVisit();
        abstract void visitStudent(int number, Student student);
        abstract void finishVisit();
    
    }
    
}
