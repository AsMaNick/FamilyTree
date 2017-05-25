using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Family_Tree
{
    public class DataBase
    {
        public const string pathToAvatars = "../../images/avatars/";
        public List<Person> allPeople;
        public List<string> allAvatars;
        public DataBase()
        {
            allPeople = new List<Person>();
            readFromFile("data.txt");
        }
        public void AddPerson(Person p)
        {
            allPeople.Add(p);
            Debug.WriteLine(p.BasicInfo());
        }
        private void updateLink(ref int cur, int id) 
        {
            if (cur == id) 
            {
                cur = -1;
            } else if (cur > id) 
            {
                cur -= 1;
            }
        }
        public void DeletePerson(int id)
        {
            if (0 <= id && id < allPeople.Count)
            {
                allPeople.RemoveAt(id);
                for (int i = 0; i < allPeople.Count; ++i)
                {
                    updateLink(ref allPeople[i].mother, id);
                    updateLink(ref allPeople[i].father, id);
                    updateLink(ref allPeople[i].partner, id);
                    for (int j = 0; j < allPeople[i].siblings.Length; ++i)
                    {
                        updateLink(ref allPeople[i].siblings[j], id);
                    }
                }
            }
            else
            {
                Debug.WriteLine(string.Format("Cann't delete unexisting Person, id = {}", id));
            }
        }
        public string AddAvatar(Image im)
        {
            string fileName = Convert.ToString(allAvatars.Count) + ".jpg";
            im.Save(pathToAvatars + fileName);
            allAvatars.Add(fileName);
            return fileName;
        }
        public void readFromFile(string file)
        {
            StreamReader input = new StreamReader(file);
            int n = Convert.ToInt32(input.ReadLine());
            for (int i = 0; i < n; ++i)
            {
                Person p = new Person();
                p.readFromFile(ref input);
                p.id = i;
                allPeople.Add(p);
                Debug.WriteLine(p.BasicInfo());
            }
            n = Convert.ToInt32(input.ReadLine());
            allAvatars = new List<string>();
            for (int i = 0; i < n; ++i)
            {
                allAvatars.Add(input.ReadLine());
            }
            input.Close();
        }
        public void writeToFile(string file)
        {
            StreamWriter output = new StreamWriter(file);
            Debug.WriteLine(allPeople.Count);
            output.WriteLine(allPeople.Count);
            for (int i = 0; i < allPeople.Count; ++i)
            {
                Debug.WriteLine(string.Format("writing person #{0}", i));
                allPeople[i].writeToFile(ref output);
            }
            output.WriteLine(allAvatars.Count);
            for (int i = 0; i < allAvatars.Count; ++i)
            {
                output.WriteLine(allAvatars[i]);
            }
            output.Close();
        }
    }
}
