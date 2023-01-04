using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10._2
{
    class Manegar :
        Consultant
    {
        protected User CreateUserFromConsole(Repository r)
        {
            Console.WriteLine("Введите информацию о клиенте.\n");

            Console.WriteLine("Введите Ф.И.О.");
            string fullName = Console.ReadLine();

            string[] fioArray = fullName.Split(" ");
            string surname = fioArray[0];
            string name = fioArray[1];
            string patronymic = fioArray[2];

            Console.Write("Введите номер телефона\n+375");
            string phoneNumber = Console.ReadLine();
            if (!r.CheckPhoneNumber(phoneNumber))
            {
                Console.WriteLine("Клиент с таким номером телефона уже зарегистрирован в системе!");
                return new User();
            }

            Console.WriteLine("Введите серию паспорта");
            string passportSeries = Console.ReadLine();

            Console.WriteLine("Введите номер паспорта");
            string passportNumber = Console.ReadLine();


            return new User(surname, name, patronymic, phoneNumber,
                passportSeries, passportNumber);
        }
        public new Repository LogIn(Repository r)
        {
            while (true)
            {
                Console.WriteLine("    Меню\n\n" +
                                "1 - просмотреть информацию обо всех клиентах\n" +
                                "2 - найти клиента по ФИО\n" +
                                "3 - изменить номер телефона клиента\n" +
                                "4 - добавить нового клиента\n" +
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
                    case '4':
                        Console.Clear();
                        User newUser = CreateUserFromConsole(r);
                        if (newUser.PhoneNumber != "")
                        {
                            r.AddUser(newUser);
                        }
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