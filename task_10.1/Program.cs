using System;

namespace task_10._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository r = new("all_users.txt");
            Consultant cs = new(r);

            cs.LogIn();
        }
    }
}
