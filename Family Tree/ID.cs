using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family_Tree
{
    public class ID
    {
        public string id;
        public ID(int Id)
        {
            id = Convert.ToString(Id);
        }
        public ID(string Id)
        {
            id = Id;
        }
        public override string ToString()
        {
            return id;
        }
    }
}
