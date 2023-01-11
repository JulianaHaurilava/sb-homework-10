using System;
using System.IO;

enum InfoToChange { Surname, Name, Patronymic, PhoneNumber, PassportSeriesNumber, AllAccount }
enum TypeOfChange { Editing, Adding }
enum WorkerType { Consultant, Manager }

namespace task_10._3
{
    class Change
    {
        private DateTime dateTimeOfChange;
        private string changedInfo;
        private string typeOfChange;
        private string editor;


        public Change(InfoToChange changedInfo, TypeOfChange typeOfChange, WorkerType editor)
        {
            dateTimeOfChange = DateTime.Now;

            this.changedInfo = changedInfo switch
            {
                InfoToChange.Surname => "Фамилия",
                InfoToChange.Name => "Имя",
                InfoToChange.Patronymic => "Отчество",
                InfoToChange.PhoneNumber => "Номер телефона",
                InfoToChange.PassportSeriesNumber => "Паспортные данные",
                InfoToChange.AllAccount => "Все данные",
                _ => "Ошибка",
            };

            this.typeOfChange = typeOfChange switch
            {
                TypeOfChange.Editing => "Редактирование",
                TypeOfChange.Adding => "Добавление новой записи",
                _ => "Ошибка",
            };

            this.editor = editor switch
            {
                WorkerType.Consultant => "Консультант",
                WorkerType.Manager => "Менеджер",
                _ => "Ошибка",
            };
        }

        /// <summary>
        /// Записывает информацию о последнем изменении в файл
        /// </summary>
        public void WriteLastChangeInFile()
        {
            using (StreamWriter stream = new StreamWriter("commited_changes.txt", true))
            {
                stream.WriteLine("Дата изменения записи: " + dateTimeOfChange.ToString("d"));
                stream.WriteLine("Время изменения записи: " + dateTimeOfChange.ToString("T"));
                stream.WriteLine("Тип измененных данных: " + changedInfo);
                stream.WriteLine("Тип изменений: " + typeOfChange);
                stream.WriteLine("Кто изменил данные: " + editor + "\n");
            }
        }
    }
}
