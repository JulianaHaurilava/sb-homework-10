using System;

namespace task_10._3
{
    class Manager :
        Consultant, IManagerCanEdit
    {
        public Manager(Repository r):
            base(r)
        {

        }
        public void ChangeSurname(User userToEdit)
        {
            Console.Write("Введите новую фамилию клиента: ");
            userToEdit.Surname = Console.ReadLine();
            Change lastChange = new(InfoToChange.Surname, TypeOfChange.Editing, Editor.Manager);
            lastChange.WriteLastChangeInFile();
            r.AllInFile();
        }
        public void ChangeName(User userToEdit)
        {
            Console.Write("Введите новое имя клиента: ");
            userToEdit.Name = Console.ReadLine();
            Change lastChange = new(InfoToChange.Name, TypeOfChange.Editing, Editor.Manager);
            lastChange.WriteLastChangeInFile();
            r.AllInFile();
        }
        public void ChangePatronimic(User userToEdit)
        {
            Console.Write("Введите новое отчество клиента: ");
            userToEdit.Patronymic = Console.ReadLine();
            Change lastChange = new(InfoToChange.Patronymic, TypeOfChange.Editing, Editor.Manager);
            lastChange.WriteLastChangeInFile();
            r.AllInFile();
        }
        public new void ChangePhoneNumber(User userToEdit)
        {
            Console.Write("Введите новый номер клиента:\n+375");
            string phoneNumber = Console.ReadLine();
            if (r.FindUserByPhoneNumber(phoneNumber).Name == "")
            {
                userToEdit.PhoneNumber = phoneNumber;
                Change lastChange = new(InfoToChange.PhoneNumber, TypeOfChange.Editing, Editor.Manager);
                lastChange.WriteLastChangeInFile();
                r.AllInFile();
                return;
            }
            else Console.WriteLine("Клиент с введенным номером телефона уже зарегистрирован в системе!");
        }
        public void ChangePassportInfo(User userToEdit)
        {
            Console.Write("Введите новую серию паспорта клиента: ");
            userToEdit.PassportSeries = Console.ReadLine();
            Console.Write("Введите новый номер паспорта клиента: ");
            userToEdit.PassportNumber = Console.ReadLine();
            Change lastChange = new(InfoToChange.PassportSeriesNumber, TypeOfChange.Editing, Editor.Consultant);
            lastChange.WriteLastChangeInFile();
            r.AllInFile();
        }
        public User CreateUserFromConsole()
        {
            Console.WriteLine("Введите информацию о клиенте.\n");

            Console.WriteLine("Введите Ф.И.О.");
            string fullName = Console.ReadLine();
            string[] fullNameArray = fullName.Split(' ');

            Console.Write("Введите номер телефона\n+375");
            string phoneNumber = Console.ReadLine();
            if (r.FindUserByPhoneNumber(phoneNumber).Name != "")
            {
                Console.WriteLine("Клиент с введенным номером телефона уже зарегистрирован в системе!");
                return new User();
            }
            Console.WriteLine("Введите серию паспорта");
            string passportSeries = Console.ReadLine();
            Console.WriteLine("Введите номер паспорта");
            string passportNumber = Console.ReadLine();

            return new User(fullNameArray[0], fullNameArray[1], fullNameArray[2],
                phoneNumber, passportSeries, passportNumber);
        }
        public void AddNewUser(User newUser)
        {
            if (newUser.Name != "")
            {
                r.AddUser(newUser);
                Change lastChange = new(InfoToChange.AllAccount, TypeOfChange.Adding, Editor.Manager);
                lastChange.WriteLastChangeInFile();
            }
        }

        /// <summary>
        /// Метод меню редактирования данных о клиенте
        /// </summary>
        /// <param name="userToEdit"></param>
        protected void ChangeUserInfo(User userToEdit)
        {
            if (userToEdit.Name != "")
            {
                Console.WriteLine("    Какое поле вы хотите редактировать?\n\n" +
                                "1 - фамилия\n" +
                                "2 - имя\n" +
                                "3 - отчество\n" +
                                "4 - номер телефона\n" +
                                "5 - серия и номер паспорта\n" +
                                "0 - выйти\n");

                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        ChangeSurname(userToEdit);
                        break;
                    case '2':
                        ChangeName(userToEdit);
                        break;
                    case '3':
                        ChangePatronimic(userToEdit);
                        break;
                    case '4':
                        ChangePhoneNumber(userToEdit);
                        break;
                    case '5':
                        ChangePassportInfo(userToEdit);
                        break;
                    case '0':
                        return;
                }
            }
            else Console.Write("Клиент с таким номером телефона не найден!\n");
        }

        /// <summary>
        /// Метод пользовательского меню менеджера
        /// </summary>
        public new void LogIn()
        {
            while (true)
            {
                Console.WriteLine("    Меню\n\n" +
                                "1 - просмотреть информацию обо всех клиентах\n" +
                                "2 - изменить информацию о клиенте\n" +
                                "3 - добавить нового клиента\n" +
                                "0 - выйти\n");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Console.Clear();
                        r.PrintAllUsers();
                        break;
                    case '2':
                        Console.Clear();
                        ChangeUserInfo(FindUserByPhoneNumber());
                        break;
                    case '3':
                        Console.Clear();
                        AddNewUser(CreateUserFromConsole());
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