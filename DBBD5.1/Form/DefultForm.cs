using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DBBD51
{
    public abstract class DefultForm : Form
    {
        internal List<Button> Buttons = new List<Button>();
        internal List<Control> TextAndComboBox = new List<Control>();
        internal List<Label> Labels = new List<Label>();
        internal HeadDataGrid headDataGrid;
        internal DataGridView dataGrid;
        internal List<string> aboutCurrent = new List<string>();
        internal int nVisible;
        internal int currentId = 1;
        internal Stack<ICommand> Commands = new Stack<ICommand>();
        internal IDataSourse DataSourse;

        internal abstract void Form_Load(object sender, EventArgs e);
        internal abstract IEitem NewIEitem();
        internal abstract bool IsInputDontHaveErrors(List<Control> TextAndComboBox); //наверное завтра уберу

        public DefultForm(HeadDataGrid headDataGrid)
        {
            //действия с формой
            Width = 800;
            Height = 600;
            MinimumSize = new Size(400, 380);
            MaximumSize = new Size(1600, 900);
            StartPosition = FormStartPosition.CenterScreen;

            //Стандартные кнопки
            InitializeDefoultButtons();
            InitializeComponent(headDataGrid);
        }

        private void InitializeComponent(HeadDataGrid headDataGrid)
        {
            //Делаю датагрид
            this.headDataGrid = headDataGrid;
            nVisible = headDataGrid.IsVisible.FindAll(x => x == true).Count;
            dataGrid = InicialItem.DaraGrid(headDataGrid);
            dataGrid.Location = new Point(10, 10);
            dataGrid.SelectionChanged += (sender, args) => RelationDataGridAndControls(sender, args);
            dataGrid.ReadOnly = true;
            dataGrid.AllowUserToAddRows = false;
            Load += (sender, args) => { Form_Load(sender, EventArgs.Empty); OnSizeChanged(EventArgs.Empty); };
            SizeChanged += (sender, args) => Resizer.ResizeAll(this, nVisible, Width, Height);
            Buttons[1].Enabled = false; //кнопка отменить
        }


        private void InitializeDefoultButtons()
        {
            var name = new[] { "Удалить", "Отменть", "Очистить", "Новый", "Изменить", "Сохранить" };
            foreach (var item in name)
                Buttons.Add(InicialItem.Button(item));
            DefoultButtonsClcikInitialize();
        }

        private void DefoultButtonsClcikInitialize()
        {
            //удалить 
            Buttons[0].Click += (sender, args) =>
            {
                var n = dataGrid.CurrentRow.Index;
                var x = new Remove(dataGrid, n, NewIEitem());
                Commands.Push(x);
                x.Command(dataGrid);
                Buttons[1].Enabled = Buttons[5].Enabled = true;
            };
            //отменить
            Buttons[1].Click += (sender, args) =>
            {
                Commands.Pop().UnCommand(dataGrid);
                if (Commands.Count() == 0)
                    Buttons[1].Enabled = Buttons[5].Enabled = false;
            };
            //очистить
            Buttons[2].Click += (sender, args) =>
            {
                var x = new Сancel(TextAndComboBox);
                x.Command(dataGrid);
                Commands.Push(x);
                Buttons[1].Enabled = true;
            };
            //новый
            Buttons[3].Click += (sender, args) =>
            {
                var n = 0;
                if (dataGrid.CurrentRow != null)
                    n = dataGrid.CurrentRow.Index;

                var x = new NewLine();
                x.Command(dataGrid);
                Commands.Push(x);
                Buttons[1].Enabled = true;
                Buttons[5].Enabled = false;

                //вернуть выбор ячейки

                RelationDataGridAndControls(dataGrid, EventArgs.Empty);
                // чищу TextAndComboBox
                foreach (var item in TextAndComboBox)
                {
                    if (item is TextBox tB)
                        tB.Clear();
                    if (item is ComboBox cB)
                    {
                        cB.SelectedIndex = 0;
                        cB.Text = "";
                    }
                }

            };
            //изменить
            Buttons[4].Click += (sender, args) =>
            {
                var t = NewIEitem();
                if (t.IsGood())
                {
                    var x = new Chanje(dataGrid, dataGrid.CurrentRow.Index, t);
                    x.Command(dataGrid);
                    Commands.Push(x);
                    Buttons[1].Enabled = Buttons[5].Enabled = true;
                }
            };
            //сохранить
            Buttons[5].Click += (sender, args) =>
            {
                foreach (var item in Commands)
                    item.SqveInSql();
                Commands.Clear();
                Buttons[1].Enabled = Buttons[5].Enabled = false;
            };
        }

        //сзязываение текс и кб с дадагридом
        internal void RelationDataGridAndControls(object sender, EventArgs args)
        {
            if (dataGrid.CurrentRow == null)
                return;
            var x = dataGrid.CurrentRow.Index;
            if (dataGrid.Rows[x].Cells[0].Value != null)
            {
                int j = 0;
                for (int i = 0; i < dataGrid.Rows[x].Cells.Count; i++)
                {
                    string value = "";
                    if (dataGrid.Rows[x].Cells[i].Value != null)
                        value = dataGrid.Rows[x].Cells[i].Value.ToString();
                    aboutCurrent.Add(value);
                    if (headDataGrid.IsVisible[i] && TextAndComboBox[j] is TextBox tb)
                        tb.Text = value;
                    if (headDataGrid.IsVisible[i] && TextAndComboBox[j] is ComboBox cb)
                        cb.Text = value;
                    if (headDataGrid.IsVisible[i])
                        j++;
                }
                if (int.TryParse(dataGrid.Rows[x].Cells[0].Value.ToString(), out int intt))
                    currentId = intt;
                else
                    currentId = 1;
            }
        }


        // нужно для создания нового итема, получаю список сток из комбобоксов. В дочерних формах станет понятно
        public List<string> GetValuesFromTextAndComboBox()
        {
            if (!IsInputDontHaveErrors(TextAndComboBox))
                return new List<string>();
            // если добавили объект, то у него должен быть максимальный индекс
            var outt = new List<string>();
            if (dataGrid.Rows[dataGrid.CurrentRow.Index].Cells[0].Value == null)
                outt.Add((DataSourse.GetMaxId() + 1).ToString());
            else
                outt.Add(dataGrid.Rows[dataGrid.CurrentRow.Index].Cells[0].Value.ToString());
            // пробегаемся по массиву "control-ов" и вытаскиваем из них значения
            int n = 0;
            foreach (var item in TextAndComboBox)
            {
                if (item is ComboBox cB)
                    foreach (var val in DataSourse.GetDataComboBoxs()[n++][cB.SelectedIndex].GetValue())
                        outt.Add(val);
                if (item is TextBox tB)
                    outt.Add(tB.Text != "" ? tB.Text : "0");
            }
            return outt;
        }

        internal void AddControls()
        {
            Controls.Add(dataGrid);
            foreach (var x in Buttons)
                Controls.Add(x);
            foreach (var x in TextAndComboBox)
                Controls.Add(x);
            foreach (var x in Labels)
                Controls.Add(x);
        }
    }
}
