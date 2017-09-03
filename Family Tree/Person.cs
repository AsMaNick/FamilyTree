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
        public int mother, father, partner, id;
        public List<int> children;
        public List<int> siblings;
        public bool man, alive;
        public string name, surname, patronymic, maidenName, birthPlace, contacts, burialPlace;
        public string fileAvatar;
        public string[] additionalInfo;
        public Date birthDate;
        public DateTime deathDate;
        public bool incognito;

        public Person(bool Incognito = false, bool Male = true)
        {
            mother = -1;
            father = -1;
            partner = -1;
            alive = true;
            siblings = new List<int> ();
            children = new List<int> ();
            incognito = Incognito;
            man = Male;
            fileAvatar = "";
        }

        public Person(string Name, string Surname, string Patronymic, string MaidenName, bool Man, bool Alive, string Contacts, string BirthPlace, string BurialPlace, Date BirthDate, DateTime DeathDate, string[] AdditionalInfo, string FileAvatar, int Id)
        {
            name = Name;
            surname = Surname;
            patronymic = Patronymic;
            maidenName = MaidenName;
            man = Man;
            alive = Alive;
            contacts = Contacts;
            birthPlace = BirthPlace;
            burialPlace = BurialPlace;
            birthDate = BirthDate;
            deathDate = DeathDate;
            additionalInfo = new string[AdditionalInfo.Length];
            for (int i = 0; i < AdditionalInfo.Length; ++i)
            {
                additionalInfo[i] = AdditionalInfo[i];
            }
            fileAvatar = FileAvatar;
            id = Id;
            mother = -1;
            father = -1;
            partner = -1;
            siblings = new List<int>();
            children = new List<int>();
            incognito = false;
        }
        public string FullName
        {
            get 
            {
                if (incognito)
                {
                    return "Неизвестно";
                }
                if (patronymic == "")
                {
                    return surname + " " + name;
                }
                return surname + " " + name + " " + patronymic;
                //return name + " " + surname;
            }
        }
        public string ShortName
        {
            get
            {
                if (incognito)
                {
                    return "Неизвестно";
                }
                return surname + " " + name;
            }
        }
        public string BasicInfo()
        {
            return string.Format("{0} {1} {2}, {3} - {4}, {5}", surname, name, patronymic, birthDate, deathDate, birthPlace);
        }
        public string getPathToAvatar()
        {
            if (fileAvatar == "")
            {
                if (this.man)
                {
                    return DataBase.pathToAvatars + "man2.png";
                }
                else
                {
                    return DataBase.pathToAvatars + "woman2.png";
                }
            }
            return DataBase.pathToAvatars + this.fileAvatar;
        }
        private DateTime readDateTime(ref StreamReader input)
        {
            string[] s = input.ReadLine().Split(' ');
            int day = Int32.Parse(s[0]);
            int month = Int32.Parse(s[1]);
            int year = Int32.Parse(s[2]);
            DateTime d = new DateTime(year, month, day);
            return d;
        }
        private Date readDate(ref StreamReader input)
        {
            string[] s = input.ReadLine().Split(' ');
            int day = Int32.Parse(s[0]);
            int month = Int32.Parse(s[1]);
            int year = Int32.Parse(s[2]);
            Date d = new Date(year, month, day);
            return d;
        }
        public void writeToFile(ref StreamWriter output) 
        {
            output.WriteLine(name);
            output.WriteLine(surname);
            output.WriteLine(patronymic);
            output.WriteLine(maidenName);
            output.WriteLine(man);
            output.WriteLine(alive);
            output.WriteLine(contacts);
            output.WriteLine(birthPlace);
            output.WriteLine(burialPlace);
            output.WriteLine(string.Format("{0} {1} {2}", birthDate.Day, birthDate.Month, birthDate.Year));
            output.WriteLine(string.Format("{0} {1} {2}", deathDate.Day, deathDate.Month, deathDate.Year));
            output.WriteLine(additionalInfo.Length);
            for (int i = 0; i < additionalInfo.Length; ++i)
            {
                output.WriteLine(additionalInfo[i]);
            }
            output.WriteLine(fileAvatar);
            output.WriteLine(mother);
            output.WriteLine(father);
            output.WriteLine(partner);
            output.WriteLine(siblings.Count);
            for (int i = 0; i < siblings.Count; ++i)
            {
                output.WriteLine(siblings[i]);
            }
            output.WriteLine(children.Count);
            for (int i = 0; i < children.Count; ++i)
            {
                output.WriteLine(children[i]);
            }
        }
        public void readFromFile(ref StreamReader input) 
        {
            name = input.ReadLine();
            surname = input.ReadLine();
            patronymic = input.ReadLine();
            maidenName = input.ReadLine();
            man = bool.Parse(input.ReadLine());
            alive = bool.Parse(input.ReadLine());
            contacts = input.ReadLine();
            birthPlace = input.ReadLine();
            burialPlace = input.ReadLine();
            birthDate = readDate(ref input);
            deathDate = readDateTime(ref input);
            int n = Int32.Parse(input.ReadLine());
            additionalInfo = new string[n];
            for (int i = 0; i < n; ++i)
            {
                additionalInfo[i] = input.ReadLine();
            }
            fileAvatar = input.ReadLine();
            mother = Int32.Parse(input.ReadLine());
            father = Int32.Parse(input.ReadLine());
            partner = Int32.Parse(input.ReadLine());
            n = Int32.Parse(input.ReadLine());
            siblings = new List<int> ();
            for (int i = 0; i < n; ++i)
            {
                siblings.Add(Int32.Parse(input.ReadLine()));
            }
            n = Int32.Parse(input.ReadLine());
            children = new List<int>();
            for (int i = 0; i < n; ++i)
            {
                children.Add(Int32.Parse(input.ReadLine()));
            }
        }
    }
}
