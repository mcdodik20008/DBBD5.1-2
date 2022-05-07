
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DBBD51
{
    public class DSAuthor : IDataSourse
    {
        private List<ComboBoxItems> ComboBoxOnForm = new List<ComboBoxItems>();
        private IEnumerable<IEitem> dataSourse;
        private List<Control> textAndComboBox;

        public int GetMaxId() => SQL.maxIndex("SELECT MAx(id_Author) From InSy.dbo.Author");

        public IDataSourse Update() => new DSAuthor(textAndComboBox);

        public DSAuthor(List<Control> textAndComboBox)
        {
            this.textAndComboBox = textAndComboBox;
            dataSourse = TransformData(getDataFromSql());
        }

        public IEnumerable<IEitem> GetRows()
        {
            foreach (var x in dataSourse)
                yield return x;
        }

        private IEnumerable<IEnumerable<string>> getDataFromSql() => SQL.ReadSql(@"select * from InSy.dbo.Author");

        private static IEnumerable<IEitem> TransformData(IEnumerable<IEnumerable<string>> data) => data
            .Select(x => new EAuthor(int.Parse(x.ElementAt(0)), x.ElementAt(1), DateTime.Parse(x.ElementAt(2))));

        public List<ComboBoxItems> GetDataComboBoxs() => ComboBoxOnForm;
    }
}
