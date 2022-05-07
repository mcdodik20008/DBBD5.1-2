using System.Collections.Generic;

namespace DBBD51
{
    public class EDirections : IEitem
    {        
        public static HeadDataGrid HeadDataGrid = new HeadDataGrid(
            new List<string> { "Номер", "Название" },
            new List<bool> { false, true },
            new List<string> { "id_napr", "name" }
            );

        public int PK;
        public string Name;
        public bool isGood = true;

        public EDirections() => isGood = false;

        public EDirections(int pK, string name)
        {
            PK = pK;
            Name = name;
        }

        public string GetNameTable() => "InSy.dbo.Directions";

        public List<string> GetListValForDataGrid() => new List<string>() { PK.ToString(), Name };

        public HeadDataGrid GetHeadDataGrid() => HeadDataGrid;

        public string GetValueForSql() => $"'{Name}'";

        public List<string> GetListValForSql() => new List<string>() { $"'{Name}'" };

        public bool IsGood() => isGood;
    }
}
