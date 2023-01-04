using System;

namespace task_10._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository r = new Repository("all_users.txt");

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
                        Consultant cs = new Consultant();
                        r = cs.LogIn(r);
                        break;
                    case '2':
                        Console.Clear();
                        Manegar mg = new Manegar();
                        r = mg.LogIn(r);
                        break;
                    case '0':
                        return;
                }
                Console.Clear();
            }
        }
    }
}
