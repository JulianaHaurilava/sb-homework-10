using System;
using System.Collections.Generic;
using System.IO;

namespace task_10._1
{
    class Repository
    {

        private string fileName; // Имя файла

        private List<User> allUsers; // Коллекция клиентов банка

        public List<User> AllUsers { get { return AllUsers; } private set { AllUsers = value; } }

        public Repository(string fileName)
        {
            this.fileName = fileName;
            allUsers = new List<User>();
            ReadFile();
        }

        /// <summary>
        /// Находит клиента в коллекции
        /// </summary>
        /// <param name="fio"></param>
        /// <returns></returns>
        public User FindUserByFio(string fio)
        {
            string[] fioArray = fio.Split(" ");
            string surname = fioArray[0];
            string name = fioArray[1];
            string patronymic = fioArray[2];

            foreach (User user in allUsers)
            {
                if (user.Surname == surname &&
                    user.Name == name &&
                    user.Patronymic == patronymic)
                    return user;
            }

            User nullUser = new User();
            return nullUser;
        }

        public void ReadFile()
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
        /// Выводит информацию о сотрудниках
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
                }
            }
            

        }

        private void AddUser(User newUser)
        {
            allUsers.Add(newUser);
            WriteUserToFile(newUser);
        }

        /// <summary>
        /// Записывает информацию о сотруднике в файл
        /// </summary>
        /// <param name="newUser"></param>
        public void WriteUserToFile(User newUser)
        {
            using (StreamWriter stream = new StreamWriter(fileName, true))
            {
                stream.WriteLine(newUser.CreateStringForFile());
            }
        }
     
    }
}
