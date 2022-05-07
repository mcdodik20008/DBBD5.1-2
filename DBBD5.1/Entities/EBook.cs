using System;
using System.Collections.Generic;

namespace DBBD51
{
    public class EBook : IEitem
    {
        public int Pk;
        public string NameBook;
        public int DateRelise;
        public int FkAuthor;
        public string NameAuthor;
        public bool isGood = true;

        public EBook() => isGood = false;

        public static HeadDataGrid HeadDataGrid = new HeadDataGrid(
            new List<string> { "id_Book", "Название", "Год печати", "fk_author", "Автор" },
            new List<bool> { false, true, true, false, true },
            new List<string> { "id_book", "bookName", "dateRelease", "fk_author", "" }
            );

        public string GetNameTable() => "InSy.dbo.Book";

        public EBook(int pk, string nameBook, int dateRelise, int fkAuthor, string nameAuthor)
        {
            Pk = pk;
            NameBook = nameBook;            
            DateRelise = dateRelise;
            FkAuthor = fkAuthor;
            NameAuthor = nameAuthor;
        }

        public List<string> GetListValForDataGrid() =>
            new List<string>() { Pk.ToString(), NameBook, DateRelise.ToString(), FkAuthor.ToString(), NameAuthor };

        public HeadDataGrid GetHeadDataGrid() => HeadDataGrid;

        public string GetValueForSql() => $"'{NameBook}', '{DateRelise}', {FkAuthor}";

        public List<string> GetListValForSql() => new List<string>() { $"'{NameBook}'", $"'{DateRelise}'", $"{FkAuthor}" };

        public bool IsGood() => isGood;
    }
}
