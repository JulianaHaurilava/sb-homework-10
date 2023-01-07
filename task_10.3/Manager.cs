using System;

namespace task_10._3
{
    class Manager :
        Consultant, IManagerMayEddit
    {
        public Manager(Repository r):
            base(r)
        {

        }
        public void ChangeSurname(User userToEdit)
        {
            Console.Write("Введите новую фамилию клиента: ");
            userToEdit.Surname = Console.ReadLine();
            r.AllInFile();
        }
        public void ChangeName(User userToEdit)
        {
            Console.Write("Введите новое имя клиента: ");
            userToEdit.Name = Console.ReadLine();
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
        public void ChangePassportInfo(User userToEdit)
        {
            Console.Write("Введите новую серию паспорта клиента: ");
            userToEdit.PassportSeries = Console.ReadLine();
            Console.Write("Введите новый номер паспорта клиента: ");
            userToEdit.PassportNumber = Console.ReadLine();
            r.AllInFile();
        }
        public void AddNewUser()
        {
            Console.WriteLine("Введите информацию о клиенте.\n");

            Console.WriteLine("Введите Ф.И.О.");
            string fullName = Console.ReadLine();
            string[] fullNameArray = fullName.Split(' ');

            Console.Write("Введите номер телефона\n+375");
            string phoneNumber = Console.ReadLine();
            if (!r.CheckPhoneNumber(phoneNumber))
            {
                Console.WriteLine("Клиент с введенным номером телефона уже зарегистрирован в системе!");
                return;
            }
            Console.WriteLine("Введите серию паспорта");
            string passportSeries = Console.ReadLine();
            Console.WriteLine("Введите номер паспорта");
            string passportNumber = Console.ReadLine();

            r.AddUser(new User(fullNameArray[0], fullNameArray[1], fullNameArray[2],
                phoneNumber, passportSeries, passportNumber));

            Change lastChange = new(InfoToChange.AllAccount, TypeOfChange.Adding, Editor.Manager);
            lastChange.WriteLastChangeInFile();
        }
        protected void ChangeUserInfo(User userToEdit)
        {
            while (true)
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
                        Change lastChange = new(InfoToChange.Surname, TypeOfChange.Editing, Editor.Manager);
                        lastChange.WriteLastChangeInFile();
                        break;
                    case '2':
                        ChangeName(userToEdit);
                        lastChange = new(InfoToChange.Name, TypeOfChange.Editing, Editor.Manager);
                        lastChange.WriteLastChangeInFile();
                        break;
                    case '3':
                        ChangePatronimic(userToEdit);
                        break;
                    case '4':
                        ChangePhoneNumber(userToEdit);
                        lastChange = new(InfoToChange.PhoneNumber, TypeOfChange.Editing, Editor.Manager);
                        lastChange.WriteLastChangeInFile();
                        break;
                    case '5':
                        ChangePassportInfo(userToEdit);
                        lastChange = new(InfoToChange.PassportSeriesNumber, TypeOfChange.Editing, Editor.Manager);
                        lastChange.WriteLastChangeInFile();
                        break;
                    case '0':
                        return;
                }
                Console.Clear();
            }
        }
        public new void LogIn()
        {
            while (true)
            {
                Console.WriteLine("    Меню\n\n" +
                                "1 - просмотреть информацию обо всех клиентах\n" +
                                "2 - найти клиента по номеру телефона\n" +
                                "3 - изменить информацию о клиенте\n" +
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
                        PrintUserByPhoneNumber();
                        break;
                    case '3':
                        Console.Clear();
                        User userToEdit = FindUserByPhoneNumber();
                        if (userToEdit.Name != "")
                            ChangeUserInfo(userToEdit);
                        break;
                    case '4':
                        Console.Clear();
                        AddNewUser();
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