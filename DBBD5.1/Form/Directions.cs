using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DBBD51
{
    public class Directions : DefultForm
    {
        static HeadDataGrid inBaseConstructor = EDirections.HeadDataGrid;

        public Directions() : base(inBaseConstructor) => InitializeComponent();


        internal override void Form_Load(object sender, EventArgs e)
        {
            DataSourse = new DSDirections(TextAndComboBox);
            dataGrid.FillingDatagrid(DataSourse.GetRows());
        }

        private void InitializeComponent()
        {
            TextAndComboBox.Add(InicialItem.TextBox());
            AddControls();
        }

        internal override IEitem NewIEitem()
        {
            var outt = GetValuesFromTextAndComboBox();
            if (outt.Count == 0) return new EDirections();
            return new EDirections(int.Parse(outt[0]), outt[1]);
        }

        internal override bool IsInputDontHaveErrors(List<Control> list) => true;
    }
}
