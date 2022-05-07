
using System;
using System.Collections.Generic;

namespace DBBD51
{
    public class EReaders : IEitem
    {
        public static HeadDataGrid HeadDataGrid = new HeadDataGrid(
            new List<string> { "id_Lk", "ФИО", "Дата рождения", "Телефонный номер", "Домашний адрес", "fkDir", "Направление", "Выдали всего", "Долг" },
            new List<bool> { false, true, true, true, true, false, true, true, true},
            new List<string> { "id_Lk", "fullName", "dateBirth", "phoneNumber", "homeAdres", "fk_dir", "", "", ""});

        public int Pk;
        public string FIO;
        public DateTime DateB;
        public string PhoneNumber;
        public string HomeAdres;
        public int FkDir;
        public string Dir;
        public int TookEverything;
        public int Debt;
        public bool isGood = true;

        public EReaders() => isGood = false;
      
        public EReaders(int pk, string fIO, DateTime dateB, string phoneNumber, string homeAdres, int fkDir, string dir, int tookEverything, int debt)
        {
            Pk = pk;
            FIO = fIO;
            DateB = dateB;
            PhoneNumber = phoneNumber;
            HomeAdres = homeAdres;
            FkDir = fkDir;
            Dir = dir;
            TookEverything = tookEverything;
            Debt = debt;
        }

        public string GetNameTable() => "InSy.dbo.LibraryCard";

        public List<string> GetListValForDataGrid() => 
            new List<string>() { Pk.ToString(), FIO, DateB.ToShortDateString(), PhoneNumber, HomeAdres, FkDir.ToString(), Dir, TookEverything.ToString(), Debt.ToString() }; 

        public HeadDataGrid GetHeadDataGrid() => HeadDataGrid;

        public string GetValueForSql() =>
            $"'{FIO}', '{DateB.ToShortDateString()}', '{PhoneNumber}', '{HomeAdres}', {FkDir}";

        public List<string> GetListValForSql() =>
            new List<string>() {$"'{FIO}'", $"'{DateB.ToShortDateString()}'", $"'{PhoneNumber}'", $"'{HomeAdres}'", $"{FkDir}"};

        public bool IsGood() => isGood;
    }
}
