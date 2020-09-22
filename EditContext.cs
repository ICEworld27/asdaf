using System;
using System.Collections.Generic;
using System.Text;

namespace students
{
    class EditContext
    {
        private static EditContext instance = null;
        public Student student;
        private EditContext()
        {

        }
        public static EditContext GetInstance()
        {
            if (instance == null) instance = new EditContext();
            return instance;
        }
    }
}
