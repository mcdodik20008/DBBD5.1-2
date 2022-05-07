using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBBD51
{
    public class Book : DefultForm
    {
        static HeadDataGrid inBaseConstructor = EBook.HeadDataGrid;

        public Book() : base(inBaseConstructor) => InitializeComponent();


        private void InitializeComponent()
        {
            TextAndComboBox.Add(InicialItem.TextBox());
            TextAndComboBox.Add(InicialItem.TextBox());
            TextAndComboBox.Add(new ComboBox());
            AddControls();
        }

        internal override void Form_Load(object sender, EventArgs e)
        {
            DataSourse = new DSBook(TextAndComboBox);
            dataGrid.FillingDatagrid(DataSourse.GetRows());
        }

        internal override IEitem NewIEitem()
        {
            var outt = GetValuesFromTextAndComboBox();
            if (outt.Count == 0) return new EBook();
            return new EBook(int.Parse(outt[0]), outt[1], int.Parse(outt[2]), int.Parse(outt[3]), outt[4]);
        }

        internal override bool IsInputDontHaveErrors(List<Control> list)
        {
            List<Tuple<bool, string>> tupl = new List<Tuple<bool, string>>();

            if (int.TryParse(list[1].Text, out int z))
                tupl.Add(Tuple.Create(false, "Введите год выпуска"));

            foreach (var t in tupl)
                MessageBox.Show(t.Item2, "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return tupl.Count == 0;
        }
    }
}
