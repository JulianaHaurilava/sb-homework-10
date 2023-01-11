using System;

namespace task_10._2
{
    class Manager :
        Consultant
    {
        public Manager(Repository r):
            base(r)
        {

        }

        /// <summary>
        /// Меняет фамилию клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        private void ChangeSurname(User userToEdit)
        {
            Console.Write("Введите новую фамилию клиента: ");
            userToEdit.Surname = Console.ReadLine();
            r.AllInFile();
            return;
        }

        /// <summary>
        /// Меняет имя клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        private void ChangeName(User userToEdit)
        {
            Console.Write("Введите новое имя клиента: ");
            userToEdit.Name = Console.ReadLine();
            r.AllInFile();
            return;
        }

        /// <summary>
        /// Меняет отчество клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        private void ChangePatronimic(User userToEdit)
        {
            Console.Write("Введите новое отчество клиента: ");
            userToEdit.Patronymic = Console.ReadLine();
            r.AllInFile();
            return;
        }

        /// <summary>
        /// Меняет паспортные данные клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        private void ChangePassportInfo(User userToEdit)
        {
            Console.Write("Введите новую серию паспорта клиента: ");
            userToEdit.PassportSeries = Console.ReadLine();
            Console.Write("Введите новый номер паспорта клиента: ");
            userToEdit.PassportNumber = Console.ReadLine();
            r.AllInFile();
            return;
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
                                "0 - выйти\n");
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '1':
                        Console.Clear();
                        r.PrintAllUsers(WorkerType.Manager);
                        break;
                    case '2':
                        Console.Clear();
                        ChangeUserInfo(FindUserByPhoneNumber());
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