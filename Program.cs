using sun.reflect.generics.visitor;
using System;
using System.Collections.Generic;

namespace students
{

    class Program 
    {

        private List<Student> Students = new List<Student>();
        static public void  ListStudentsCommand()
        {
            StudentRegistry.GetInstance().visitStudents(new DetaliedPrintVisitor());
            /*
            StudentRegistry  a = StudentRegistry.GetInstance();
            int len = a.getStudentCount();
            Student st = a.getStudent(0);
            //Console.WriteLine("===" + (i + 1) + "===");
            //st.print_Long();
            DetaliedPrintVisitor ar = new DetaliedPrintVisitor();
            ar.startVisit();
            ar.visitStudent(0 + 1, st);
            */
        }

            
    
   
    static public void AddStudentCommand()
        {
            StudentRegistry a = StudentRegistry.GetInstance();
            string name, srname, ot, gr;
            Console.WriteLine("Введите имя: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите фамилию: ");
            srname = Console.ReadLine();
            Console.WriteLine("Введите отчество: ");
            ot = Console.ReadLine();
            Console.WriteLine("Введите группу: ");
            gr = Console.ReadLine();

            a.AddStudent(new Student(srname, name, ot, gr));
            Console.WriteLine("Успешно добавлен!");
        }
        static public void RemoveStudentCommand()
        {
            StudentRegistry.GetInstance().visitStudents(new BriefPrintVisitor());
            StudentRegistry a = StudentRegistry.GetInstance();
           
            
            if (a.getStudentCount() > 0)
            {
                int n;
                Console.WriteLine("Введите номер: ");
                n = Convert.ToInt32(Console.ReadLine());
                while (n <= 0 || n > a.getStudentCount())
                {
                    Console.WriteLine("Введён неверный номер!");
                    Console.WriteLine("Введите номер: ");
                    n = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Вы уверены? y/n ");
                string vp;
                vp = Console.ReadLine();
                if (vp == "y")
                {
                    a.removeStudent(n - 1);
                    Console.WriteLine("Удалён успешно!");
                }

            }

           
        }
        static public void ShowHighAchiversCommand()
        {
            StudentRegistry.GetInstance().visitStudents(new HighAchieverVisitor());
            /*
            StudentRegistry a = StudentRegistry.GetInstance();
            int len = a.getStudentCount();
            
            for (int i = 0; i < len; i++)
            {
                Student st = a.getStudent(i);
                HighAchieverVisitor arq = new HighAchieverVisitor();
                arq.startVisit();
                arq.visitStudent(i + 1, st);
                //
                bool good = true;
                Student stu = a.getStudent(i);
                foreach (KeyValuePair<string, int> item in stu.marks)
                {
                    if (item.Value < 5)
                    {
                        good = false;
                    }
                }
                if (good)
                {
                    stu.print_Short();
                }
                //
            }
        */
        }
        static public void ShowLowAchiversCommand()
        {

            //StudentRegistry a = StudentRegistry.GetInstance();
            //int len = a.getStudentCount();
            StudentRegistry.GetInstance().visitStudents(new LowAchiverVisitor());
            /*
            for (int i = 0; i < len; i++)
            {
                Student stu = a.getStudent(i);
                Student st = a.getStudent(i);
                LowAchiverVisitor arq = new LowAchiverVisitor();
                arq.startVisit();
                arq.visitStudent(i + 1, st);
                //
                bool good = true;
                foreach (KeyValuePair<string, int> item in stu.marks)
                {
                    if (item.Value > 2)
                    {
                        good = false;
                    }
                }
                if (good)
                {
                    stu.print_Short();
                }

                //
            }
        */
        }
        static void SelectStudentCommand()
        {
            StudentRegistry.GetInstance().visitStudents(new BriefPrintVisitor());
            Console.WriteLine("Введите порядковый номер студента (от 1 до " + StudentRegistry.GetInstance().getStudentCount() + " включительно): ");
            int nv = Convert.ToInt32(Console.ReadLine());
            if (StudentRegistry.GetInstance().getStudentCount() > 0)
            {
                while (nv < 1 && nv > StudentRegistry.GetInstance().getStudentCount())
                {
                    Console.WriteLine("Введён неверный номер!");
                    Console.WriteLine("Введите порядковый номер студента (от 1 до " + StudentRegistry.GetInstance().getStudentCount() + " включительно): ");
                    nv = Convert.ToInt32(Console.ReadLine());
                }
                EditContext.GetInstance().student = StudentRegistry.GetInstance().getStudent(nv - 1);
            }


        }
        static void ShowSelectedCommand()
        {
           
            EditContext.GetInstance().student.print_Long();
        }
        static void DeselectStudentCommand()
        {

            EditContext.GetInstance().student = null;
        }
        static void M1()
        {
            Console.WriteLine("ASDADASD");
        }
         static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
            Menu main_menu = new Menu();
            main_menu.addSimpleMenuItem("Список студентов", ListStudentsCommand);
            main_menu.addSimpleMenuItem("Добавить студента", AddStudentCommand);
            main_menu.addSimpleMenuItem("Удалить студентоа", RemoveStudentCommand);
            main_menu.addSimpleMenuItem("Показать список отличников", ShowHighAchiversCommand);
            main_menu.addSimpleMenuItem("Показать список неуспевающих", ShowLowAchiversCommand);
            /*Console.WriteLine(6 / 2*(1 + 2));
            ListStudentsCommand();
            StudentRegistry.GetInstance();*/
            main_menu.Run();

            



        }

    }
}
