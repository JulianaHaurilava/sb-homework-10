using System;
using System.IO;

enum InfoToChange { Surname, Name, Patronymic, PhoneNumber, PassportSeriesNumber, AllAccount }
enum TypeOfChange { Editing, Adding }
enum Editor { Consultant, Manager }

namespace task_10._3
{
    struct Change
    {
        private DateTime dateTimeOfChanging;
        private string changedInfo;
        private string typeOfChange;
        private string editor;


        public Change(InfoToChange changedInfo, TypeOfChange typeOfChange, Editor editor)
        {
            dateTimeOfChanging = DateTime.Now;

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
                Editor.Consultant => "Консультант",
                Editor.Manager => "Менеджер",
                _ => "Ошибка",
            };
        }

        public void WriteLastChangeInFile()
        {
            using (StreamWriter stream = new StreamWriter("commited_changes", true))
            {
                stream.WriteLine("Дата и время изменения записи: " + dateTimeOfChanging.ToString());
                stream.WriteLine("Тип измененных данных: " + changedInfo);
                stream.WriteLine("Тип изменений: " + typeOfChange);
                stream.WriteLine("Кто изменил данные: " + editor);
            }
        }
    }
}
