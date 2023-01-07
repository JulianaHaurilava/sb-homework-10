using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_10._3
{
    interface IManagerMayEddit
    {
        public void ChangeSurname(User userToEdit);
        public void ChangeName(User userToEdit);
        public void ChangePatronimic(User userToEdit);
        public void ChangePhoneNumber(User userToEdit);
        public void ChangePassportInfo(User userToEdit);
        public void AddNewUser();
    }
}
