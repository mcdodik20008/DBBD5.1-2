using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBBD51
{
    public class LibrarianForm : DefultForm
    {
        static HeadDataGrid inBaseConstructor = ELibrarian.HeadDataGrid;

        public LibrarianForm() : base(inBaseConstructor) => InitializeComponent();

        private void InitializeComponent()
        {
            TextAndComboBox.Add(InicialItem.TextBox());
            TextAndComboBox.Add(InicialItem.TextBox());
            AddControls();
        }

        internal override void Form_Load(object sender, EventArgs e)
        {
            DataSourse = new DSLibrarian(TextAndComboBox);
            dataGrid.FillingDatagrid(DataSourse.GetRows());
        }

        internal override IEitem NewIEitem()
        {
            var outt = GetValuesFromTextAndComboBox();
            if (outt.Count == 0) return new ELibrarian();
            return new ELibrarian(int.Parse(outt[0]), outt[1], DateTime.Parse(outt[2]));
        }

        internal override bool IsInputDontHaveErrors(List<Control> list)
        {
            List<Tuple<bool, string>> tupl = new List<Tuple<bool, string>>();

            if (!DateTime.TryParse(list[1].Text, out DateTime dT))
                tupl.Add(Tuple.Create(false, "Не правильно ввели дату рождения"));

            foreach (var t in tupl)
                MessageBox.Show(t.Item2, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return tupl.Count == 0;
        }
    }
}
