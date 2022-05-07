using System.Linq;
using System.Windows.Forms;

namespace DBBD51
{
    public static class ComboBoxExtention
    {
        public static void FillingAutors(this ComboBox comboBox, ComboBoxItems comboBoxItems, int currentId)
        {
            string command = @"SELECT id_book, bookName, fk_author, fullNameAuthor
	                            From InSy.dbo.Book
	                            JOIN InSy.dbo.Author ON  fk_author = id_Author";
            foreach (var item in SQL.ReadSql(command))
            {
                var t = item.ToList();
                comboBoxItems.Add(new ComboBoxItemBook(currentId, int.Parse(t[0]), t[1], int.Parse(t[2]), t[3]));
                comboBox.Items.Add(t[1]);
            }
        }

        public static void FillLibrarian(this ComboBox comboBox, ComboBoxItems comboBoxItems)
        {
            string command = @"SELECT id_Librarian, fullName
                                From InSy.dbo.Librarian";
            comboBoxItems.Add(new ComboBoxItemLibrarian(null, null));
            comboBox.Items.Add("");
            foreach (var item in SQL.ReadSql(command))
            {
                var t = item.ToList();
                comboBoxItems.Add(new ComboBoxItemLibrarian(int.Parse(t[0]), t[1]));
                comboBox.Items.Add(t[1]);
            }
        }

        public static void FillBooksDirections(this ComboBox comboBox, ComboBoxItems comboBoxItems)
        {
            string command = @"SELECT id_napr, name
                                From InSy.dbo.Directions";
            comboBox.Items.Clear();
            foreach (var item in SQL.ReadSql(command))
            {
                var t = item.ToList();
                comboBoxItems.Add(new ComboBoxItemAuthor(int.Parse(t[0]), t[1]));
                comboBox.Items.Add(t[1]);
            }
        }

        public static void FillBooksAuthors(this ComboBox comboBox, ComboBoxItems comboBoxItems)
        {
            string command = @"SELECT id_Author, fullNameAuthor
                                From InSy.dbo.Author";
            foreach (var item in SQL.ReadSql(command))
            {
                var t = item.ToList();
                comboBoxItems.Add(new ComboBoxItemAuthor(int.Parse(t[0]), t[1]));
                comboBox.Items.Add(t[1]);
            }
        }
    }
}
