using System;

namespace task_10._2
{
    class Consultant
    {

        protected User FindUserByFio(Repository r)
        {
            Console.Write("Введите ФИО клиента: ");
            string fio = Console.ReadLine();
            Console.WriteLine();

            return r.FindUserByFio(fio);
        }

        protected void PrintUserByFio(Repository r)
        {
            User userToFind = FindUserByFio(r);
            if (userToFind.PhoneNumber != "")
            {
                userToFind.Print();
            }
            else Console.Write("Клиент с таким ФИО не найден!\n");
        }

        protected Repository ChangePhoneNumber(Repository r)
        {
            User userToEdit = FindUserByFio(r);
            if (userToEdit.PhoneNumber != "")
            {
                Console.Write("Введите новый номер клиента: ");
                userToEdit.PhoneNumber = Console.ReadLine();
                r.AllInFile();
            }
            else Console.Write("Клиент с таким ФИО не найден!\n");
            return r;
        }

        public Repository LogIn(Repository r)
        {
            while (true)
            {
                Console.WriteLine("    Меню\n\n" +
                                "1 - просмотреть информацию обо всех клиентах\n" +
                                "2 - найти клиента по ФИО\n" +
                                "3 - изменить номер телефона клиента\n" +
                                "0 - выйти\n");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Console.Clear();
                        r.PrintAllUsers();
                        break;
                    case '2':
                        Console.Clear();
                        PrintUserByFio(r);
                        break;
                    case '3':
                        Console.Clear();
                        r = ChangePhoneNumber(r);
                        break;
                    case '0':
                        return r;
                }

                Console.WriteLine("\nДля того, чтобы выйти в главное меню, нажмите любую клавишу...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
