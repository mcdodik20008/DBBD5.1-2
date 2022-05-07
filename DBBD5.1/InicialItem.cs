using System.Collections.Generic;
using System.Windows.Forms;

namespace DBBD51
{
    public static class InicialItem
    {
        // под себя переделываю конструкторы
        public static DataGridView DaraGrid(HeadDataGrid headDG)
        {
            int n = headDG.HeaderTest.Count;
            if (headDG.IsVisible == null)
            {
                headDG.IsVisible = new List<bool>(n);
                for (var i = 0; i < n; i++)
                    headDG.IsVisible.Add(true);
            }
            var nVisible = headDG.IsVisible.FindAll(x => x == true).Count;
            var dataGrid = new DataGridView();
            DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[n];
            for (int i = 0; i < n; i++)
            {
                column[i] = new DataGridViewTextBoxColumn();
                column[i].HeaderText = headDG.HeaderTest[i];
                column[i].Name = headDG.NameInSql[i];
                column[i].Visible = headDG.IsVisible[i];
            }
            dataGrid.Columns.AddRange(column);
            return dataGrid;
        }
        public static Button Button(string text, DockStyle Ds = DockStyle.None)
        {
            return new Button
            {
                Text = text,
                Dock = Ds
            };
        }
        public static TextBox TextBox(DockStyle Ds = DockStyle.None, bool flag = false)
        {
            return new TextBox
            {
                Dock = Ds,
                ReadOnly = flag
            };
        }

        public static ComboBox ComboBox(DockStyle Ds = DockStyle.None, bool flag = true)
        {
            return new ComboBox
            {
                Dock = Ds
            };
        }
    }
}
