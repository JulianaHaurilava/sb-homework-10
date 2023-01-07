using System;

namespace task_10._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository r = new("all_users.txt");

            while (true)
            {
                Console.WriteLine("    Вход в систему\n\n" +
                                "1 - консультант\n" +
                                "2 - менеджер\n" +
                                "0 - выйти\n");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Consultant cs = new(r);
                        cs.LogIn();
                        break;
                    case '2':
                        Console.Clear();
                        Manager mg = new(r);
                        mg.LogIn();
                        break;
                    case '0':
                        return;
                }
                Console.Clear();
            }
        }
    }
}
