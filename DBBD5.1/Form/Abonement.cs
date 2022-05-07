using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DBBD51
{
    class Abonement : DefultForm
    {
        List<string> aboutReader;
        static HeadDataGrid inBaseConstructor = EAbonement.HeadDataGrid;

        public Abonement(int currentId, List<string> aboutReader) : base(inBaseConstructor) => InitializeComponent(currentId, aboutReader);

        private void InitializeComponent(int currentId, List<string> aboutReader)
        {
            this.aboutReader = aboutReader;
            this.currentId = currentId;
            for (int i = 0; i < 3; i++)
            {
                TextAndComboBox.Add(InicialItem.ComboBox());
                TextAndComboBox.Add(InicialItem.TextBox(DockStyle.None, true));
            }
            Labels.Add(new Label() { Text = "ФИО:", Width = 40 });
            Labels.Add(new Label() { Text = aboutReader[1], Width = 100 }); // фио
            Labels.Add(new Label() { Text = "Дата рождения:", Width = 100 });
            Labels.Add(new Label() { Text = aboutReader[2], Width = 70 }); // дата р
            Labels.Add(new Label() { Text = "Номер телефона:", Width = 100 });
            Labels.Add(new Label() { Text = aboutReader[3], Width = 80 }); // телефон номер 
            Labels.Add(new Label() { Text = "Домашний адрес:", Width = 100 });
            Labels.Add(new Label() { Text = aboutReader[4], Width = 100 }); // адрес
            Labels.Add(new Label() { Text = "Направление:", Width = 80 });
            Labels.Add(new Label() { Text = aboutReader[6], Width = 50 }); // направление
            dataGrid.Location = new Point(10, 70);
            InicializeChangeCB();
            OnSizeChanged(EventArgs.Empty);
        }

        internal override void Form_Load(object sender, EventArgs e)
        {
            DataSourse = new DSAbonement(currentId, TextAndComboBox);
            dataGrid.FillingDatagrid(DataSourse.GetRows());
            AddControls();
        }

        internal void InicializeChangeCB()
        {
            var c1 = TextAndComboBox[0] as ComboBox;
            c1.SelectedIndexChanged += (sender, Empty) =>
            {
                if (TextAndComboBox[1] is TextBox tB
                    && DataSourse.GetDataComboBoxs()[0][c1.SelectedIndex] is ComboBoxItemBook cBB)
                    tB.Text = cBB.NameAut;
            };
            var c2 = TextAndComboBox[2] as ComboBox;
            c2.SelectedIndexChanged += (sender, Empty) =>
            {
                if (TextAndComboBox[3] is TextBox tB &&
                DataSourse.GetDataComboBoxs()[1][c2.SelectedIndex] is ComboBoxItemLibrarian cBB)
                    if (tB.Text == "" || tB.Text == null)
                        tB.Text = DateTime.Now.ToString().Substring(0, 10);
            };
            var c3 = TextAndComboBox[4] as ComboBox;
            c3.SelectedIndexChanged += (sender, Empty) =>
            {
                if (TextAndComboBox[5] is TextBox tB &&
                DataSourse.GetDataComboBoxs()[2][c3.SelectedIndex] is ComboBoxItemLibrarian cBB)
                {
                    if (tB.Text == "" || tB.Text == null)
                        tB.Text = DateTime.Now.ToString().Substring(0, 10);
                    if (c3.SelectedIndex == 0) tB.Text = "";
                }
            };
        }

        internal override IEitem NewIEitem()
        {
            var outt = GetValuesFromTextAndComboBox();
            int? fk = null;
            DateTime? dT = null;
            if (outt[9] != null && outt[9] != "")
                fk = int.Parse(outt[9]);

            if (outt[9] != null && outt[9] != "")
                dT = DateTime.Parse(outt[11]);

            if (outt.Count == 0) return new EAbonement();
            return new EAbonement(int.Parse(outt[0]), int.Parse(outt[1]), int.Parse(outt[2]), outt[3],
                int.Parse(outt[4]), outt[5], int.Parse(outt[6]), outt[7], DateTime.Parse(outt[8]), fk, outt[10], dT);
        }

        internal override bool IsInputDontHaveErrors(List<Control> list) => true;
    }
}
