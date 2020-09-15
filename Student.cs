using System;
using System.Collections.Generic;
using System.Text;

namespace students
{
    class Student
    {
        public string first_name, midle_name, last_name, group;
        public Dictionary<string, int> marks = new Dictionary<string, int>();
        public Student(string first_namee, string midle_namee, string last_namee, string groupp)
        {
            //int[] z = new int[0];
            first_name = first_namee;
            midle_name = midle_namee;
            last_name = last_namee;
            group = groupp;
        }
        public void print_Long()
        {
            

                Console.WriteLine("Фамилия: " + first_name );
                Console.WriteLine("Имя: " + midle_name);
                Console.WriteLine("Отчество: " + last_name);
                Console.WriteLine("Группа: " + group);
                Console.WriteLine("Оценки: ");
                if (this.marks.Count > 0)
                {
                    foreach (KeyValuePair<string, int> item in marks)
                    {
                        Console.WriteLine(item.Key + " : " + item.Value);
                    }
                }
                else
                {
                    Console.WriteLine("Оценок пока нет!");
                }


            
        }
        public void print_Short()
        {
                Console.Write(first_name);
                Console.Write(" " + midle_name);
                Console.Write(" " + last_name);
                Console.WriteLine("(" + group + ")");

            
        }
        public void print_Subjects()
        {
            if (this.marks.Count > 0)
            {
                foreach (KeyValuePair<string, int> item in this.marks)
                {
                    Console.WriteLine("1." + item.Key);
                }
            }
            else
            {
                Console.WriteLine("Предметов пока нет!");
            }
            
        }
        
    }
}
