using System.Collections.Generic;
using System.Windows.Forms;

namespace DBBD51
{
    public class Remove : ICommand
    {
        private int position;
        private List<string> values;
        private IEitem item;
        public Remove(DataGridView value, int pos, IEitem item)
        {
            values = new List<string>();
            foreach (DataGridViewCell cell in value.Rows[pos].Cells)
                values.Add(cell.Value != null ? cell.Value.ToString() : null);          
            position = pos;
            this.item = item;
        }

        public void Command(DataGridView dataGrid) =>
            dataGrid.Rows.RemoveAt(position);

        public void UnCommand(DataGridView dataGrid) =>
            dataGrid.Rows.Insert(position, values.ToArray());

        public void SqveInSql() => 
            SQL.InteractingSql($"DELETE FROM {item.GetNameTable()} WHERE {item.GetHeadDataGrid().NameInSql[0]} = {values[0]}");
    }
}
