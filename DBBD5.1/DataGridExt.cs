using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBBD51
{
    public static class DataGridExt
    {
        public static void FillingDatagrid<T>(this DataGridView dataGrid ,IEnumerable<T> collection)
                where T : IEitem
        {
            dataGrid.Rows.Clear();
            var i = 0;
            foreach (var item in collection)
            {
                var n = 0;
                dataGrid.Rows.Add();
                foreach (var valueProperty in item.GetListValForDataGrid())
                    dataGrid.Rows[i].Cells[n++].Value = valueProperty != null ? valueProperty : null;
                i += 1;
            }
            if (dataGrid.Rows.Count != 0)
                dataGrid.Rows[0].Selected = true;
        }
    }
}
