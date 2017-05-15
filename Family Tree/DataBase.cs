using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Family_Tree
{
    public class DataBase
    {
        public List<Person> allPeople;
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
        public void DeletePerson(int id)
        {
            if (0 <= id && id < allPeople.Count)
            {
                allPeople.RemoveAt(id);
            }
            else
            {
                Debug.WriteLine(string.Format("Cann't delete unexisting Person, id = {}", id));
            }
        }
        public void readFromFile(string file)
        {
            StreamReader input = new StreamReader(file);
            int n = Convert.ToInt32(input.ReadLine());
            for (int i = 0; i < n; ++i)
            {
                Person p = new Person();
                p.readFromFile(ref input);
                allPeople.Add(p);
                Debug.WriteLine(p.BasicInfo());
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
                allPeople[i].writeToFile(ref output);
            }
            output.Close();
        }
    }
}
