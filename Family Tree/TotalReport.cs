using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Family_Tree
{
    public partial class TotalReport : Form
    {
        private int CountMan(DataBase data) {
            int res = 0;
            foreach (Person p in data.allPeople) {
                if (p.man) {
                    res += 1;
                }
            }
            return res;
        }

        private int CountWoman(DataBase data)
        {
            return data.allPeople.Count - CountMan(data);
        }

        private int CountConnections(DataBase data)
        {
            int res = 0;
            foreach (Person p in data.allPeople)
            {
                res += p.siblings.Count;
                res += p.children.Count;
                res += p.allPartners.Count;
                if (p.mother != -1)
                {
                    ++res;
                }
                if (p.father != -1)
                {
                    ++res;
                }
                if (p.partner != -1)
                {
                    ++res;
                }
            }
            return res;
        }

        private int CountPhotos(DataBase data)
        {
            int res = 0;
            foreach (Photo p in data.allPhotos)
            {
                if (!p.deleted)
                {
                    ++res;
                }
            }
            return res;
        }

        private int CountLabeledPeople(DataBase data)
        {
            int res = 0;
            foreach (Photo p in data.allPhotos) {
                if (!p.deleted)
                {
                    res += p.peopleIds.Count;
                }
            }
            return res;
        }

        public TotalReport(DataBase data)
        {
            InitializeComponent();
            int total = data.allPeople.Count;
            TotalCount.Text += " " + Convert.ToString(total) + " персон";
            ManCount.Text += ": " + Convert.ToString(Convert.ToInt32(10000.0 * CountMan(data) / total) / 100.0) + "%";
            WomanCount.Text += ": " + Convert.ToString(Convert.ToInt32(10000.0 * CountWoman(data) / total) / 100.0) + "%";
            ConnectionsCount.Text += ": " + Convert.ToString(CountConnections(data));
            PhotoCount.Text += ": " + Convert.ToString(CountPhotos(data));
            LabeledPeopleCount.Text += ": " + Convert.ToString(CountLabeledPeople(data));
        }

        private void OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void TotalCount_Click(object sender, EventArgs e)
        {

        }

        private void ManCount_Click(object sender, EventArgs e)
        {

        }

        private void WomanCount_Click(object sender, EventArgs e)
        {

        }

        private void ConnectionsCount_Click(object sender, EventArgs e)
        {

        }

        private void PhotoCount_Click(object sender, EventArgs e)
        {

        }
    }
}
