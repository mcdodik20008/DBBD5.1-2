using System.Collections.Generic;
using System.Windows.Forms;

namespace DBBD51
{
    public class Сancel : ICommand
    {
        List<string> values = new List<string>();
        List<Control> textAndCb;
        
        public Сancel(List<Control> textAndCb) => this.textAndCb = textAndCb;

        public void Command(DataGridView x)
        {
            for (int i = 0; i < textAndCb.Count; i++)
            {
                if (textAndCb[i] is TextBox tb)
                {
                    values.Add(tb.Text);
                    tb.Clear();
                    continue;
                }
                if (textAndCb[i] is ComboBox cb)
                {
                    values.Add(cb.SelectedIndex.ToString());
                    cb.Text = "";
                    continue;
                }
            }
        }

        public void UnCommand(DataGridView x)
        {
            for (int i = 0; i < textAndCb.Count; i++)
            {
                if (textAndCb[i] is TextBox tb)
                    tb.Text = values[i];
                if (textAndCb[i] is ComboBox cb)
                {
                    cb.SelectedItem = int.Parse(values[i]);
                    cb.Text = cb.SelectedItem.ToString();
                }
            }
        }

        public void SqveInSql() { }
    }
}
