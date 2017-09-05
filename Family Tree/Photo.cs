using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace Family_Tree
{
    public class Photo
    {
        public Image img;
        public List<Rectangle> zones;
        public List<int> peopleIds;
        public string pathToFile, additionalInfo;
        public int id;

        public Photo()
        {
            zones = new List<Rectangle>();
            peopleIds = new List<int>();
        }

        public static Image Scale(Image img, double k)
        {
            int w = Convert.ToInt32(img.Width * k);
            int h = Convert.ToInt32(img.Height * k);
            return (Image)(new Bitmap(img, w, h));
        }

        public void readFromFile(ref StreamReader file)
        {
            pathToFile = file.ReadLine();
            additionalInfo = file.ReadLine();
            id = int.Parse(file.ReadLine());
            int n = int.Parse(file.ReadLine());
            for (int i = 0; i < n; ++i)
            {
                int x, y, w, h, personId;
                x = int.Parse(file.ReadLine());
                y = int.Parse(file.ReadLine());
                w = int.Parse(file.ReadLine());
                h = int.Parse(file.ReadLine());
                personId = int.Parse(file.ReadLine());
                zones.Add(new Rectangle(x, y, w, h));
                peopleIds.Add(personId);
            }
            img = (Image)(new Bitmap(DataBase.pathToAvatars + pathToFile));
        }

        public void writeToFile(ref StreamWriter file)
        {
            file.WriteLine(pathToFile);
            file.WriteLine(additionalInfo);
            file.WriteLine(id);
            int n = zones.Count;
            file.WriteLine(n);
            for (int i = 0; i < n; ++i)
            {
                int x, y, w, h, personId;
                x = zones[i].Left;
                y = zones[i].Top;
                w = zones[i].Width;
                h = zones[i].Height;
                personId = peopleIds[i];
                file.WriteLine(x);
                file.WriteLine(y);
                file.WriteLine(w);
                file.WriteLine(h);
                file.WriteLine(personId);
            }
        }
    }
}
