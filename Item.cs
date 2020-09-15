using System;
using System.Collections.Generic;
using System.Text;

namespace students
{
    abstract class Item
    {
        string title;
           
        public abstract void Run();
        public Item(string titl)
        {
            title = titl;
        }
        public string get_title()
        {
            return title;
        }
    }
}
