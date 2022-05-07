using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DBBD51
{
    public static class Resizer
    {
        // все методы связаны
        // Выставляем кнопки, относительно кнопок выставляем техтбохы,
        // относительно них из позиции (10, 10) расчитываю высоту датагрида,
        // расчитываю ширину техт бохов(по этому из датагрида вызвается техтбох)
        public static void ResizeAll(DefultForm form, int nVisible, int width, int heigth)
        {
            PlaseResizeButtons(form, width, heigth);
            PlaseResizeTextBox(form, nVisible);
            ResizeDataGrid(form, nVisible, width, heigth);
            PlaseResizeLabels(form);
        }

        internal static void ResizeDataGrid(DefultForm form, int nVisible, int width, int heigth)
        {
            form.dataGrid.Width = width - 35;
            form.dataGrid.Height = heigth - (heigth - form.TextAndComboBox[0].Top + 10) - form.dataGrid.Location.Y;
            var n = 60 / nVisible;
            foreach (DataGridViewTextBoxColumn col in form.dataGrid.Columns)
                col.Width = form.dataGrid.Width / nVisible - n;
            PlaseResizeTextBox(form, nVisible);
        }

        internal static void PlaseResizeTextBox(DefultForm form, int nVisible)
        {
            var n = 65 / form.TextAndComboBox.Count();
            for (int i = 0; i < form.TextAndComboBox.Count(); i++)
            {
                form.TextAndComboBox[i].Width = form.dataGrid.Width / nVisible - n;
                form.TextAndComboBox[i].Height = 20;
                if (i == 0)
                    form.TextAndComboBox[i].Location = new Point(47, form.Buttons[0].Top - 30);
                else
                    form.TextAndComboBox[i].Location = new Point(form.TextAndComboBox[i - 1].Right + 5, form.Buttons[0].Top - 30);
            }
        }

        internal static void PlaseResizeButtons(DefultForm form, int width, int heigth)
        {
            var n = 10;
            var bntWidth = width / form.Buttons.Count - n;
            var btnHeigth = heigth / 10;
            for (int i = 0; i < form.Buttons.Count(); i++)
            {
                form.Buttons[i].Size = new Size(bntWidth, btnHeigth);
                if (i == 0)
                    form.Buttons[i].Location = new Point(10, heigth - btnHeigth - 40);
                else
                    form.Buttons[i].Location = new Point(form.Buttons[i - 1].Right + 5, heigth - btnHeigth - 40);
            }
        }

        internal static void PlaseResizeLabels(DefultForm form)
        {
            if (form.Labels.Count > 0)
            {
                form.Labels[0].Location = new Point(form.dataGrid.Left, form.dataGrid.Top - 60);
                form.Labels[1].Location = new Point(form.Labels[0].Right, form.dataGrid.Top - 60);
                form.Labels[2].Location = new Point(form.Labels[1].Right, form.dataGrid.Top - 60);
                form.Labels[3].Location = new Point(form.Labels[2].Right, form.dataGrid.Top - 60);
                form.Labels[4].Location = new Point(form.Labels[3].Right, form.dataGrid.Top - 60);
                form.Labels[5].Location = new Point(form.Labels[4].Right, form.dataGrid.Top - 60);
                form.Labels[6].Location = new Point(form.dataGrid.Left, form.dataGrid.Top - 30);
                form.Labels[7].Location = new Point(form.Labels[6].Right, form.dataGrid.Top - 30);
                form.Labels[8].Location = new Point(form.Labels[7].Right, form.dataGrid.Top - 30);
                form.Labels[9].Location = new Point(form.Labels[8].Right, form.dataGrid.Top - 30);
            }
        }
    }
}
