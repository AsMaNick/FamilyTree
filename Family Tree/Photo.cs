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
        public const string Filter = "Все изображения|*.jpg;*.bmp;*.gif;*.png;*.tif;*tiff";
        public List<Rectangle> zones;
        public List<int> peopleIds;
        public string pathToFile, pathToLightFile;
        public List<string> additionalInfo;
        public int id;
        public bool deleted;
        public int width, height;

        public Photo()
        {
            zones = new List<Rectangle>();
            peopleIds = new List<int>();
            additionalInfo = new List<string>();
            deleted = false;
            width = height = 0;
        }

        public Photo(Photo p)
        {
            //img = (Image)new Bitmap(p.img);
            zones = new List<Rectangle>(p.zones);
            peopleIds = new List<int>(p.peopleIds);
            pathToFile = p.pathToFile;
            pathToLightFile = p.pathToLightFile;
            additionalInfo = new List<string> (p.additionalInfo);
            id = p.id;
            deleted = p.deleted;
            width = p.width;
            height = p.height;
        }

        /*public static Image Scale(Image img, double k) //not recomended to use!!! High memery using
        {
            int w = Convert.ToInt32(img.Width * k);
            int h = Convert.ToInt32(img.Height * k);
            return (Image)(new Bitmap(img, w, h));
        }*/

        public static Image Resize(Image img, int w, int h)
        {
            Image res = (Image)(new Bitmap(img, w, h));
            Photo.Dispose(img);
            return res;
        }

        public static void Dispose(Image img) {
            if (img != null)
            {
                img.Dispose();
            }
        }

        public void readFromFile(ref StreamReader file)
        {
            width = int.Parse(file.ReadLine());
            height = int.Parse(file.ReadLine());
            pathToFile = file.ReadLine();
            pathToLightFile = file.ReadLine();
            if (pathToFile.Length < DataBase.pathToGroupPhotos.Length || pathToFile.Substring(0, DataBase.pathToGroupPhotos.Length) != DataBase.pathToGroupPhotos)
            {
                pathToFile = DataBase.pathToGroupPhotos + pathToFile;
            }
            int n = int.Parse(file.ReadLine());
            additionalInfo = new List<string>();
            for (int i = 0; i < n; ++i)
            {
                additionalInfo.Add(file.ReadLine());
            }
            deleted = Convert.ToBoolean(file.ReadLine());
            n = int.Parse(file.ReadLine());
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
            if (!deleted)
            {
                //img = (Image)(new Bitmap(DataBase.pathToGroupPhotos + pathToFile));
            }
            else
            {
                //img = null;
            }
        }

        public void writeToFile(ref StreamWriter file)
        {
            file.WriteLine(width);
            file.WriteLine(height);
            file.WriteLine(pathToFile);
            file.WriteLine(pathToLightFile);
            file.WriteLine(additionalInfo.Count);
            for (int i = 0; i < additionalInfo.Count; ++i)
            {
                file.WriteLine(additionalInfo[i]);
            }
            file.WriteLine(deleted);
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

        public void delete()
        {
            this.deleted = true;
            //this.img = null;
            this.peopleIds.Clear();
            this.zones.Clear();
        }
    }
}
