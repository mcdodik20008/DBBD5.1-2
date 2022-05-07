using System.Windows.Forms;

namespace DBBD51
{
    public class NewLine : ICommand
    {
        int index;

        public NewLine() { }

        public void Command(DataGridView x)
        {
            x.Rows.Add();
            index = x.Rows.Count - 1;
        }

        public void UnCommand(DataGridView x) =>
            x.Rows.RemoveAt(index);

        public void SqveInSql() { }
    }
}
