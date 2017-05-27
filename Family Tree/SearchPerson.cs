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

namespace Family_Tree
{
    public partial class SearchPerson : Form
    {
        private MainPage parent;
        private bool man;
        public int resId;

        public SearchPerson()
        {
            InitializeComponent();
        }
        public SearchPerson(MainPage Parent, bool Man)
        {
            InitializeComponent();
            parent = Parent;
            man = Man;
            DrawGridView();
        }
        private void DrawGridView()
        {
            dataGridView.Rows.Clear();
            for (int i = 0; i < parent.data.allPeople.Count; ++i)
            {
                if (parent.data.allPeople[i].man != man)
                {
                    continue;
                }
                dataGridView.Rows.Add(new DataGridViewRow());
                int num = dataGridView.Rows.Count - 1;
                dataGridView.Rows[num].Cells[0].Value = parent.data.allPeople[i].FullName;
                dataGridView.Rows[num].Cells[1].Value = parent.data.allPeople[i].birthPlace;
                dataGridView.Rows[num].Cells[0].Tag = new ID(i);
                dataGridView.Rows[num].ReadOnly = true;
            }
        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.WriteLine(string.Format("Double Click {0} {1}", e.RowIndex, e.ColumnIndex));
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && e.ColumnIndex < 2)
            {
                resId = e.RowIndex;
                this.DialogResult = DialogResult.OK;
            }
        }

    }
}
