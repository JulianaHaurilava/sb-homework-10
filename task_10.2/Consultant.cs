using System;

namespace task_10._2
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
        protected void ChangePhoneNumber(User userToEdit)
        {
            Console.Write("Введите новый номер клиента:\n+375");
            string phoneNumber = Console.ReadLine();
            if (r.FindUserByPhoneNumber(phoneNumber).Name == "")
            {
                userToEdit.PhoneNumber = phoneNumber;
                r.AllInFile();
                return;
            }
            else Console.WriteLine("Клиент с введенным номером телефона уже зарегистрирован в системе!");
        }
        public void LogIn()
        {
            while (true)
            {
                Console.WriteLine("    Меню\n\n" +
                                "1 - просмотреть информацию обо всех клиентах\n" +
                                "2 - изменить номер телефона клиента\n" +
                                "0 - выйти\n");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Console.Clear();
                        r.PrintAllUsers();
                        break;
                    case '2':
                        Console.Clear();
                        User userToEdit = FindUserByPhoneNumber();
                        if (userToEdit.Name != "")
                            ChangePhoneNumber(userToEdit);
                        else Console.Write("Клиент с таким номером телефона не найден!\n");
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
