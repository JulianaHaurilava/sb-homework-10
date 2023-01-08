﻿using System;
using System.Collections.Generic;
using System.IO;

namespace task_10._3
{
    class Repository
    {

        private string fileName; // Имя файла

        private List<User> allUsers; // Коллекция клиентов банка

        public Repository(string fileName)
        {
            this.fileName = fileName;
            allUsers = new List<User>();
            ReadFile();
        }

        /// <summary>
        /// Ищет клиента по номеру телефона
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public User FindUserByPhoneNumber(string phoneNumber)
        {
            foreach (User user in allUsers)
            {
                if (user.PhoneNumber == string.Format("{0:+375 (##) ###-##-##}", int.Parse(phoneNumber)))
                    return user;
            }
            return new User();
        }

        /// <summary>
        /// Считывает данные из файла
        /// </summary>
        private void ReadFile()
        {
            if (File.Exists(fileName))
            {
                using (StreamReader stream = new StreamReader(fileName, true))
                {
                    while (!stream.EndOfStream)
                    {
                        allUsers.Add(new User(stream.ReadLine()));
                    }
                }
            }
        }

        /// <summary>
        /// Перезаписывает информацию в файле
        /// </summary>
        public void AllInFile()
        {
            using (StreamWriter stream = new StreamWriter(fileName))
            {
                foreach (User user in allUsers)
                {
                    stream.WriteLine(user.CreateStringForFile());
                }
            }
        }

        /// <summary>
        /// Выводит информацию обо всех клиентах
        /// </summary>
        public void PrintAllUsers()
        {
            if (allUsers.Count == 0) Console.WriteLine("Записей о клиентах нет.");
            else
            {
                Console.WriteLine("Клиенты банка\n");
                foreach (User user in allUsers)
                {
                    user.Print();
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Добавляет нового клиента в репозиторий
        /// </summary>
        /// <param name="newUser"></param>
        public void AddUser(User newUser)
        {
            allUsers.Add(newUser);
            WriteUserInFile(newUser);
        }

        /// <summary>
        /// Записывает пользователя в конец файла
        /// </summary>
        /// <param name="newUser"></param>
        private void WriteUserInFile(User newUser)
        {
            using (StreamWriter stream = new StreamWriter(fileName, true))
            {
                stream.WriteLine(newUser.CreateStringForFile());
            }
        }

    }
}
