namespace task_10._3
{
    interface IManagerCanEdit:
        IConsultantCanEdit
    {
        /// <summary>
        /// Меняет фамилию клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        /// 
        public void ChangeSurname(User userToEdit);

        /// <summary>
        /// Меняет имя клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        public void ChangeName(User userToEdit);

        /// <summary>
        /// Меняет отчество клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        public void ChangePatronimic(User userToEdit);

        /// <summary>
        /// Меняет номер телефона клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        public new void ChangePhoneNumber(User userToEdit);

         /// <summary>
        /// Меняет паспортные данные клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        public void ChangePassportInfo(User userToEdit);

        /// <summary>
        /// Создает нового клиента
        /// </summary>
        /// <returns></returns>
        public User CreateUserFromConsole();

        /// <summary>
        /// Добавляет нового клиента в репозиторий
        /// </summary>
        /// <param name="newUser"></param>
        public void AddNewUser(User newUser);
    }
}
