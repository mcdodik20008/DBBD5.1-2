using System.Collections.Generic;
using System.Text;

namespace DBBD51
{
    public class HeadDataGrid
    {
        public List<string> HeaderTest;
        public List<bool> IsVisible;
        public List<string> NameInSql;

        public HeadDataGrid(List<string> headerTest, List<bool> isVisible, List<string> nameInSql)
        {
            HeaderTest = headerTest;
            IsVisible = isVisible;
            NameInSql = nameInSql;
        }

        public override string ToString()
        {
            var x = new StringBuilder();
            for (int i = 1; i < NameInSql.Count; i++)
            {
                if (NameInSql[i] != "")
                {
                    x.Append(NameInSql[i] + ", ");
                }
            }
            x.Remove(x.Length - 2, 2);
            return x.ToString();
        }
    }
}
