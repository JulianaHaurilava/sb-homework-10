using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10._1
{
    class User
    {
        public string Surname { get; private set; }
        public string Name { get; private set; }
        public string Patronymic { get; private set; }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return $"+375{phoneNumber}"; }
            set
            {
                if (value.Length == 13 && value.StartsWith("+375"))
                {
                    phoneNumber = value.Substring(4);
                }
                else if (value.Length == 9)
                {
                    phoneNumber = value;
                }

            }
        }

        private string passportSeries;
        private string PassportSeries
        {
            get { return "**"; }
            set { passportSeries = value; }
        }

        private string passportNumber;
        private string PassportNumber
        {
            get { return "*******"; }
            set { passportNumber = value; }
        }

        public User()
        {
            Surname = "";
            Name = "";
            Patronymic = "";
            PhoneNumber = "";
            passportSeries = "";
            passportNumber = "";
        }

        public User(string userInfo)
        {
            string[] userInfoArray = userInfo.Split(" ");
            Surname = userInfoArray[0];
            Name = userInfoArray[1];
            Patronymic = userInfoArray[2];
            PhoneNumber = userInfoArray[3];
            passportSeries = userInfoArray[4];
            passportNumber = userInfoArray[5];
        }

        public User(string surname, string name, string patronymic,
            string phoneNumber, string passportSeries, string passportNumber)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            PhoneNumber = phoneNumber;
            this.passportSeries = passportSeries;
            this.passportNumber = passportNumber;
        }

        /// <summary>
        /// Выводит всю информацию о клиенте
        /// </summary>
        public void Print()
        {
            Console.Write($"Ф.И.О: {Surname + " " + Name + " " + Patronymic}\n" +
                $"Номер телефона: {PhoneNumber}\n");
            if (!String.IsNullOrEmpty(passportSeries))
                Console.Write($"Серия и номер паспорта: {PassportSeries + PassportNumber}\n");
            else Console.Write($"Серия и номер паспорта: данные не указаны\n");
        }

        public string CreateStringForFile()
        {
            return Surname + " " + Name + " " + Patronymic + " " + phoneNumber +
                " " + passportSeries + " " + passportNumber;
        }
    }
}
