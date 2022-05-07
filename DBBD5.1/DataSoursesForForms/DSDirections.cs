using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DBBD51
{
    public class DSDirections : IDataSourse
    {
        private List<ComboBoxItems> ComboBoxOnForm = new List<ComboBoxItems>();
        private IEnumerable<IEitem> dataSourse;
        private List<Control> textAndComboBox;
        public int GetMaxId() => SQL.maxIndex("SELECT MAx(id_napr) + 1 From InSy.dbo.Directions");

        public IDataSourse Update() => new DSDirections(textAndComboBox);

        public DSDirections(List<Control> textAndComboBox)
        {
            this.textAndComboBox = textAndComboBox;
            dataSourse = TransformData(getDataFromSql());
        }

        public IEnumerable<IEitem> GetRows()
        {
            foreach (var x in dataSourse)
                yield return x;
        }

        private IEnumerable<IEnumerable<string>> getDataFromSql() => SQL.ReadSql(@"select * from InSy.dbo.Directions");

        private static IEnumerable<IEitem> TransformData(IEnumerable<IEnumerable<string>> data) => data
            .Select(x => new EDirections(int.Parse(x.First()), x.Last()));

        public List<ComboBoxItems> GetDataComboBoxs() => ComboBoxOnForm;
    }
}
