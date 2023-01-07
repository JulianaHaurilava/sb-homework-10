using System;

namespace task_10._3
{
    class Consultant
    {
        protected Repository r;

        public Consultant(Repository r)
        {
            this.r = r;
        }
        protected User FindUserByPhoneNumber()
        {
            Console.Write("Введите номер телефона клиента:\n+375");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine();
            return r.FindUserByPhoneNumber(phoneNumber);
        }

        protected void PrintUserByPhoneNumber()
        {
            User userToFind = FindUserByPhoneNumber();
            if (userToFind.Name != "")
                userToFind.Print();
        }

        public void ChangePhoneNumber(User userToEdit)
        {
            Console.Write("Введите новый номер клиента: ");
            userToEdit.PhoneNumber = Console.ReadLine();
            r.AllInFile();
        }

        public void LogIn()
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
                        PrintUserByPhoneNumber();
                        break;
                    case '3':
                        Console.Clear();
                        User userToEdit = FindUserByPhoneNumber();
                    if (userToEdit.Name != "")
                    {
                        ChangePhoneNumber(userToEdit);
                    }
                    break;
                case '0':
                        return;
                }

                Console.WriteLine("\nДля того, чтобы выйти в главное меню, нажмите любую клавишу...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
