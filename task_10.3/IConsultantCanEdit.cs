namespace task_10._3
{
    interface IConsultantCanEdit
    {
        /// <summary>
        /// Меняет номер телефона клиента
        /// </summary>
        /// <param name="userToEdit"></param>
        public void ChangePhoneNumber(User userToEdit);
    }
}
