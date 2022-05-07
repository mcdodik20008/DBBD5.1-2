using System.Collections.Generic;

namespace DBBD51
{
    public class ComboBoxItems
    {
        List<IComboBoxItem> cBItems = new List<IComboBoxItem>();

        public IComboBoxItem this[int x]
        {
            get { return cBItems[x]; }
            set { cBItems[x] = value; }
        }

        public void Add(IComboBoxItem item) => cBItems.Add(item);
    }
}
