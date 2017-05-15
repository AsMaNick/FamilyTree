using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_Tree
{
    public class Person
    {
        public string name, surname, patronymic, birthPlace;
        public DateTime birthDate, deathDate;
        public Person(string Name, string Surname, string Patronymic, string BirthPlace, DateTime BirthDate, DateTime DeathDate)
        {
            name = Name;
            surname = Surname;
            patronymic = Patronymic;
            birthPlace = BirthPlace;
            birthDate = BirthDate;
            deathDate = DeathDate;
        }
        public string BasicInfo()
        {
            return string.Format("{0} {1} {2}, {3} - {4}, {5}", surname, name, patronymic, birthDate, deathDate, birthPlace);
        }
    }
}
