namespace task_10._3
{
    interface IManagerCanEdit:
        IConsultantCanEdit
    {
        public void ChangeSurname(User userToEdit);
        public void ChangeName(User userToEdit);
        public void ChangePatronimic(User userToEdit);
        public new void ChangePhoneNumber(User userToEdit);
        public void ChangePassportInfo(User userToEdit);
        public User CreateUserFromConsole();
        public void AddNewUser(User newUser);
    }
}
