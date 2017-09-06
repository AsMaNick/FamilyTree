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
        const string pathToDataBase = "data.txt";
        const string pathToPhotoDataBase = "photoData.txt";

        public const string pathToAvatarss = "../../images/avatars/";
        public const string pathToGroupPhotos = "../../images/group_photos/";
        public List<Person> allPeople;
        public List<string> allAvatars;
        public List<Photo> allPhotos;

        public DataBase()
        {
            allPeople = new List<Person>();
            allPhotos = new List<Photo>();
            readFromFile(pathToDataBase);
            readPhotosFromFile(pathToPhotoDataBase);
            addPhotosToPeople();
        }

        private void addPhotosToPeople()
        {
            for (int i = 0; i < allPhotos.Count; ++i)
            {
                Photo p = allPhotos[i];
                for (int j = 0; j < p.peopleIds.Count; ++j)
                {
                    allPeople[p.peopleIds[j]].allPhotosIds.Add(i);
                }
            }
        }

        public void AddPerson(Person p)
        {
            allPeople.Add(p);
            Debug.WriteLine(p.BasicInfo());
        }

        public string AddAvatar(Image im)
        {
            string fileName = Convert.ToString(allAvatars.Count) + ".jpg";
            im.Save(pathToAvatarss + fileName);
            allAvatars.Add(fileName);
            return fileName;
        }

        public void addPhoto(Photo p)
        {
            string fileName = "GroupPhoto" + Convert.ToString(allPhotos.Count) + ".jpg";
            p.img.Save(pathToGroupPhotos + fileName);
            p.pathToFile = fileName;
            p.id = allPhotos.Count;
            for (int i = 0; i < p.peopleIds.Count; ++i)
            {
                allPeople[p.peopleIds[i]].allPhotosIds.Add(p.id);
            }
            allPhotos.Add(p);
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
            updateConnections();
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

        public void readPhotosFromFile(string file)
        {
            StreamReader input = new StreamReader(file);
            int n = Convert.ToInt32(input.ReadLine());
            for (int i = 0; i < n; ++i)
            {
                Photo p = new Photo();
                p.readFromFile(ref input);
                p.id = i;
                allPhotos.Add(p);
            }
            input.Close();
        }

        public void writePhotosToFile(string file)
        {
            StreamWriter output = new StreamWriter(file);
            Debug.WriteLine(allPhotos.Count);
            output.WriteLine(allPhotos.Count);
            for (int i = 0; i < allPhotos.Count; ++i)
            {
                Debug.WriteLine(string.Format("writing photo #{0}", i));
                allPhotos[i].writeToFile(ref output);
            }
            output.Close();
        }
        
        public void save()
        {
            writeToFile(pathToDataBase);
            writePhotosToFile(pathToPhotoDataBase);
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
        private int updateLink(int cur, int id)
        {
            if (cur == id)
            {
                cur = -1;
            }
            else if (cur > id)
            {
                cur -= 1;
            }
            return cur;
        }

        public void DeletePerson(int id)
        {
            if (0 <= id && id < allPeople.Count)
            {
                allPeople.RemoveAt(id);
                for (int i = 0; i < allPeople.Count; ++i)
                {
                    updateLink(ref allPeople[i].id, id);
                    updateLink(ref allPeople[i].mother, id);
                    updateLink(ref allPeople[i].father, id);
                    updateLink(ref allPeople[i].partner, id);
                    for (int j = 0; j < allPeople[i].siblings.Count; ++j)
                    {
                        allPeople[i].siblings[j] = updateLink(allPeople[i].siblings[j], id);
                        if (allPeople[i].siblings[j] == -1) 
                        {
                            allPeople[i].siblings.RemoveAt(j);
                            --j;
                        }
                    }
                    for (int j = 0; j < allPeople[i].children.Count; ++j)
                    {
                        allPeople[i].children[j] = updateLink(allPeople[i].children[j], id);
                        if (allPeople[i].children[j] == -1)
                        {
                            allPeople[i].children.RemoveAt(j);
                            --j;
                        }
                    }
                }
            }
            else
            {
                Debug.WriteLine(string.Format("Cann't delete unexisting Person, id = {0}", id));
            }
        }

        public void deletePhoto(int id)
        {
            for (int i = 0; i < this.allPhotos[id].peopleIds.Count; ++i)
            {
                int personId = this.allPhotos[id].peopleIds[i];
                this.allPeople[personId].allPhotosIds.Remove(id);
            }
            this.allPhotos[id].delete();
        }

        private List<int> distinct(List<int> a)
        {
            List<int> res = new List<int>();
            IEnumerable<int> b = a.Distinct();
            foreach (int x in b)
            {
                res.Add(x);
            }
            return res;
        }
        private void updateConnections(Person p)
        {
            if (p.father != -1)
            {
                allPeople[p.father].children.Add(p.id);
            }
            if (p.mother != -1)
            {
                allPeople[p.mother].children.Add(p.id);
            }
            if (p.father != -1 && p.mother != -1)
            {
                allPeople[p.father].partner = p.mother;
                allPeople[p.mother].partner = p.father;
            }
            if (p.partner != -1)
            {
                allPeople[p.partner].partner = p.id;
            }
            for (int i = 0; i < p.children.Count; ++i)
            {
                if (p.man)
                {
                    allPeople[p.children[i]].father = p.id;
                }
                else
                {
                    allPeople[p.children[i]].mother = p.id;
                }
                if (p.partner != -1)
                {
                    allPeople[p.partner].children.Add(p.children[i]);
                }
            }
            for (int i = 0; i < p.siblings.Count; ++i)
            {
                allPeople[p.siblings[i]].siblings.Add(p.id);
                for (int j = 0; j < p.siblings.Count; ++j)
                {
                    if (p.siblings[i] != p.siblings[j])
                    {
                        allPeople[p.siblings[i]].siblings.Add(p.siblings[j]);
                    }
                }
                if (p.mother != -1)
                {
                    allPeople[p.siblings[i]].mother = p.mother;
                }
                if (p.father != -1)
                {
                    allPeople[p.siblings[i]].father = p.father;
                }
            }
        }
        public void updateConnections()
        {
            for (int i = 0; i < allPeople.Count; ++i)
            {
                updateConnections(allPeople[i]);
            }
            for (int i = 0; i < allPeople.Count; ++i)
            {
                allPeople[i].children = distinct(allPeople[i].children);
                allPeople[i].siblings = distinct(allPeople[i].siblings);
            }
        }
    }
}
