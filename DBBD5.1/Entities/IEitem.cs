using System;
using System.Collections.Generic;

namespace DBBD51
{
    //якобы сущности Базы данных с "Удобными" методами для получения данных
    public interface IEitem
    { 
        string GetNameTable();
        HeadDataGrid GetHeadDataGrid();
        List<string> GetListValForDataGrid();
        string GetValueForSql();
        List<string> GetListValForSql();
        bool IsGood();
    }
}
