﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10._1
{
    class Consultant
    {

        private User FindUserByPhoneNumber(Repository r)
        {
            Console.Write("Введите номер телефона клиента:\n+375");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine();

            return r.FindUserByPhoneNumber(phoneNumber);
        }

        private void PrintUserByPhoneNumber(Repository r)
        {
            User userToFind = FindUserByPhoneNumber(r);
            if (userToFind.PhoneNumber != "")
            {
                userToFind.Print();
            }
            else Console.Write("Клиент с таким номером телефона не найден!\n");
        }

        private Repository ChangePhoneNumber(Repository r)
        {
            User userToEdit = FindUserByPhoneNumber(r);
            if (userToEdit.PhoneNumber != "")
            {
                Console.Write("Введите новый номер телефона клиента: ");
                userToEdit.PhoneNumber = Console.ReadLine();
                r.AllInFile();
            }
            else Console.Write("Клиент с таким номер телефона не найден!\n");
            return r;
        }

        public Repository LogIn(Repository r)
        {
            while (true)
            {
                Console.WriteLine("    Меню\n\n" +
                                "1 - просмотреть информацию обо всех клиентах\n" +
                                "2 - найти клиента по номеру телефона\n" +
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
                        PrintUserByPhoneNumber(r);
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
