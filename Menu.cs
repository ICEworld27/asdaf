using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using com.sun.org.apache.bcel.@internal.generic;

namespace students
{

    class Menu : Item
       {
        private bool sub;
        private Item[] items =  new Item[0];
        Action startup_command = null;
        Action before_select_command = null;
        Action tear_down_command = null;
        public void setStartupCommand(Action newcommand)
        {
            startup_command = newcommand;
        }
        public void setBeforeSelectCommand(Action newcommand)
        {
            before_select_command = newcommand;
        }
        public void setTearDownCommand(Action newcommand)
        {
            tear_down_command = newcommand;
        }
        public void print_menu() 
        {
            
                
            
            for (int i = 0; i < items.Length; i++)
            {

                Console.WriteLine((i + 1) + ". " + items[i].get_title());
            }
            //if (this is Menu)
            //{
                Menu oi = this;
                
                if (oi.getSub() == true)
                {
                    Console.WriteLine((items.Length + 1) + ". Назад");
                }
                else
                {
                    Console.WriteLine((items.Length + 1) + ". Выход");
                }
           // }
            
            Console.Write("Введите нужный номер: ");
        }
        public bool HandleUserInput()
        {
            int asd = Convert.ToInt32(Console.ReadLine());
            if (asd-1 < items.Length && asd-1 > -1)
            {
                items[asd-1].Run();
                return false;
            }
            else
            {
                if (asd-1 == items.Length)
                {
                    return true;
                }
            }
            return false;
        }
        /*
        public override void Run() 
        {
            while (true)
            {
                print_menu();
                if (HandleUserInput() == true)
                {
                    Console.WriteLine("y/n");
                    if (Console.ReadLine() == "y")
                    {
                        return;
                    }
                    
                }
            }

        }
        */
        
        public override void Run()
        {
            try
            {
                if (startup_command != null) startup_command();
            }
            catch
            {
                Console.WriteLine("Возникло исключение!");
            }
            
            while (true)
            {
                if (before_select_command != null) before_select_command();
                print_menu();
                if (HandleUserInput() == true)
                {
                    Console.WriteLine("y/n");
                    if (Console.ReadLine() == "y")
                    {
                        if (tear_down_command != null) tear_down_command();
                        return;
                    }

                }
            }

        }
        
        
        public void addSimpleMenuItem(string title, Action action)
        {
            // создать пункт меню и добавить в массив
            Simple_Item r = new Simple_Item(action, title);
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = r;
        }
        public Menu addSubmenu(string title)
        {
            Menu qwe = new Menu(title);
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = qwe;
            return qwe;
            //return ref qwe;
            // создать экземпляр меню и сообщить ему, что он -- подменю
            // добавить этот экземпляр в массив
            // вернуть ссылку на экземпляр
        }
        public bool getSub()
        {

            return sub;
            //return ref qwe;
            // создать экземпляр меню и сообщить ему, что он -- подменю
            // добавить этот экземпляр в массив
            // вернуть ссылку на экземпляр
        }
        /*
        public void Add(Item a)
        {
            Array.Resize(ref items, items.Length + 1);
            items[items.Length - 1] = a;
        }
        */
        public Menu() : base("")
        {
            //int[] z = new int[0];
            sub = false;
        }
        private Menu(string title) : base(title)
        {
            sub = true;
            //int[] z = new int[0];
        }
    }
}
