using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DBBD51
{
    public class DSBook : IDataSourse
    {
        private List<ComboBoxItems> ComboBoxOnForm = new List<ComboBoxItems>();
        private IEnumerable<IEitem> dataSourse;
        private List<Control> textAndComboBox;
        public int GetMaxId() => SQL.maxIndex("SELECT MAx(id_book) From InSy.dbo.Book");

        public IDataSourse Update() => new DSReaders(textAndComboBox);

        public DSBook(List<Control> textAndComboBox)
        {
            this.textAndComboBox = textAndComboBox;
            dataSourse = TransformData(getDataFromSql());

            ComboBoxOnForm.Add(new ComboBoxItems());
            (textAndComboBox[2] as ComboBox).FillBooksAuthors(ComboBoxOnForm[0]);
        }

        public IEnumerable<IEitem> GetRows()
        {
            foreach (var x in dataSourse)
                yield return x;
        }

        private IEnumerable<IEnumerable<string>> getDataFromSql()
        {
            string book = @"select id_book, bookName, dateRelease, fk_author, fullNameAuthor
                            from InSy.dbo.Book
                            join InSy.dbo.Author ON  fk_author = id_Author";
            return SQL.ReadSql(book);
        }

        private static IEnumerable<IEitem> TransformData(IEnumerable<IEnumerable<string>> data) => data
            .Select(x => new EBook(int.Parse(x.ElementAt(0)), x.ElementAt(1),
                   int.Parse(x.ElementAt(2)), int.Parse(x.ElementAt(3)), x.ElementAt(4)));

        public List<ComboBoxItems> GetDataComboBoxs() => ComboBoxOnForm;
    }
}
