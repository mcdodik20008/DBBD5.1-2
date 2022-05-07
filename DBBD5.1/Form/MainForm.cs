using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace DBBD51
{
    class MainForm : Form
    {
        public MainForm()
        {
            Width = 400;
            Height = 300;
            MinimumSize = new Size(350, 250);
            StartPosition = FormStartPosition.CenterScreen;

            var Librarian = InicialItem.Button("Библиотекари", DockStyle.Fill);
            var BookBtn = InicialItem.Button("Книги", DockStyle.Fill);
            var Abonement = InicialItem.Button("Читательские билеты", DockStyle.Fill);
            var Directions = InicialItem.Button("Направления", DockStyle.Fill);
            var NewBook = InicialItem.Button("Добавить книгу", DockStyle.Fill);
            var Author = InicialItem.Button("Авторы", DockStyle.Fill);
            var ItogVid = InicialItem.Button("Итоги выдачи", DockStyle.Fill);
            var ItogBibl = InicialItem.Button("Итоги библиотекари", DockStyle.Fill);
            var thief = InicialItem.Button("Должники", DockStyle.Fill);

            var table = new TableLayoutPanel();
            table.RowStyles.Clear();

            int Rolumn = 3;
            for (var i = 0; i < Rolumn; i++)
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100 / Rolumn));
            for (var i = 0; i < Rolumn; i++)
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 / Rolumn));

            table.Controls.Add(Librarian, 0, 0);
            table.Controls.Add(BookBtn, 0, 1);
            table.Controls.Add(Abonement, 0, 2);

            table.Controls.Add(Directions, 1, 0);
            table.Controls.Add(NewBook, 1, 1);
            table.Controls.Add(Author, 1, 2);

            table.Controls.Add(ItogVid, 2, 0);
            table.Controls.Add(ItogBibl, 2, 1);
            table.Controls.Add(thief, 2, 2);

            table.Dock = DockStyle.Fill;
            Controls.Add(table);

            // посмотрите диаграмму классов
            Librarian.Click += (sender, args) => new LibrarianForm().ShowDialog();
            Abonement.Click += (sender, args) => new Readers().ShowDialog();
            BookBtn.Click += (sender, args) => new Book().ShowDialog();
            Author.Click += (sender, args) => new Author().ShowDialog();
            Directions.Click += (sender, args) => new Directions().ShowDialog();

            //чтобы не зависало при первом открытии форм
            string connectionString = @"Data Source=KOMPYTER-ALEKSE\SQLEXPRESS;Initial Catalog=InSy;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            connection.Close();
        }
    }
}
