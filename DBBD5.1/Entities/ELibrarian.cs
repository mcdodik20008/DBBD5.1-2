using System;
using System.Collections.Generic;

namespace DBBD51
{
    public class ELibrarian : IEitem
    {        
        public static HeadDataGrid HeadDataGrid = new HeadDataGrid(
            new List<string> { "id_lib", "Библиотекарь", "Дата рождения" },
            new List<bool> { false, true, true },
            new List<string> { "id_Librarian", "fullName", "dateBirth" }
           );

        public int PK;
        public string FIO;
        public DateTime DateBirth;
        public bool isGood = true;

        public ELibrarian() => isGood = false;

        public ELibrarian(int pK, string fIO, DateTime dateBirth)
        {
            PK = pK;
            FIO = fIO;
            DateBirth = dateBirth;
        }

        public string GetNameTable() => "InSy.dbo.Librarian";

        public List<string> GetListValForDataGrid() =>
            new List<string>() { PK.ToString(), FIO, DateBirth.ToShortDateString() };

        public HeadDataGrid GetHeadDataGrid() => HeadDataGrid;

        public string GetValueForSql() => $"'{FIO}', '{DateBirth.ToShortDateString()}'";

        public List<string> GetListValForSql() =>
            new List<string>() { $"'{FIO}'", $"'{DateBirth.ToShortDateString()}'" };

        public bool IsGood() => isGood;
    }
}
