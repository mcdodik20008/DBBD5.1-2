using System.Collections.Generic;

namespace DBBD51
{
    public interface IDataSourse
    {
        IEnumerable<IEitem> GetRows();
        int GetMaxId();
        IDataSourse Update();
        List<ComboBoxItems> GetDataComboBoxs();
    }
}
