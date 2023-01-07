using System;
using System.Collections.Generic;
using System.IO;

namespace task_10._3
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

        public User FindUserByPhoneNumber(string phoneNumber)
        {
            foreach (User user in allUsers)
            {
                if (user.PhoneNumber == "+375" + phoneNumber)
                    return user;
            }

            Console.Write("Клиент с таким номером телефона не найден!\n");
            return new User();
        }

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

        public void AddUser(User newUser)
        {
            allUsers.Add(newUser);
            WriteUserInFile(newUser);
        }

        private void WriteUserInFile(User newUser)
        {
            using (StreamWriter stream = new StreamWriter(fileName, true))
            {
                stream.WriteLine(newUser.CreateStringForFile());
            }
        }

        public bool CheckPhoneNumber(string phoneNumber)
        {
            foreach (User user in allUsers)
            {
                if (user.PhoneNumber == "+375" + phoneNumber)
                    return false;
            }
            return true;
        }

    }
}
