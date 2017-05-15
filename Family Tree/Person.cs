using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Family_Tree
{
    public class Person
    {
        public string name, surname, patronymic, birthPlace;
        public DateTime birthDate, deathDate;
        public Person()
        {
        }
        public Person(string Name, string Surname, string Patronymic, string BirthPlace, DateTime BirthDate, DateTime DeathDate)
        {
            name = Name;
            surname = Surname;
            patronymic = Patronymic;
            birthPlace = BirthPlace;
            birthDate = BirthDate;
            deathDate = DeathDate;
        }
        public string FullName
        {
            get 
            {
                return name + " " + surname;
            }
        }
        public string BasicInfo()
        {
            return string.Format("{0} {1} {2}, {3} - {4}, {5}", surname, name, patronymic, birthDate, deathDate, birthPlace);
        }
        private DateTime readDate(ref StreamReader input)
        {
            string[] s = input.ReadLine().Split(' ');
            int day = Int32.Parse(s[0]);
            int month = Int32.Parse(s[1]);
            int year = Int32.Parse(s[2]);
            DateTime d = new DateTime(year, month, day);
            return d;
        }
        public void writeToFile(ref StreamWriter output) 
        {
            output.WriteLine(name);
            output.WriteLine(surname);
            output.WriteLine(patronymic);
            output.WriteLine(birthPlace);
            output.WriteLine(string.Format("{0} {1} {2}", birthDate.Day, birthDate.Month, birthDate.Year));
            output.WriteLine(string.Format("{0} {1} {2}", deathDate.Day, deathDate.Month, deathDate.Year));
        }
        public void readFromFile(ref StreamReader input) 
        {
            name = input.ReadLine();
            surname = input.ReadLine();
            patronymic = input.ReadLine();
            birthPlace = input.ReadLine();
            birthDate = readDate(ref input);
            deathDate = readDate(ref input);
        }
    }
}
