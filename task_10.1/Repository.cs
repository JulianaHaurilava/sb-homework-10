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

        public User FindUserByPhoneNumber(string phoneNumber)
        {
            foreach (User user in allUsers)
            {
                if (user.PhoneNumber == string.Format("{0:+375 (##) ###-##-##}", int.Parse(phoneNumber)))
                    return user;
            }
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
                }
            }
            

        }
     
    }
}
