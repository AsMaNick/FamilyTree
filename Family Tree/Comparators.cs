using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_Tree
{
    public class PhotoComparerByDate : IComparer<int>
    {
        private DataBase data;

        public PhotoComparerByDate(DataBase d)
        {
            data = d;
        }

        public int Compare(int x, int y)
        {
            if (data.allPhotos[x].dateOfCreation < data.allPhotos[y].dateOfCreation)
            {
                return -1;
            }
            else if (data.allPhotos[y].dateOfCreation < data.allPhotos[x].dateOfCreation)
            {
                return 1;
            }
            return 0;
        }
    }

    public class PhotoComparerByPeopleCount : IComparer<int>
    {
        private DataBase data;

        public PhotoComparerByPeopleCount(DataBase d)
        {
            data = d;
        }

        public int Compare(int x, int y)
        {
            if (data.allPhotos[x].peopleIds.Count < data.allPhotos[y].peopleIds.Count)
            {
                return -1;
            }
            else if (data.allPhotos[y].peopleIds.Count < data.allPhotos[x].peopleIds.Count)
            {
                return 1;
            }
            return 0;
        }
    }
}
