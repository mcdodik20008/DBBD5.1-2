using System.Windows.Forms;

namespace DBBD51
{
    //патерн команда, с добавлением отсебятины в виде сохранения в скул
    interface ICommand
    {
        void Command(DataGridView x);
        void UnCommand(DataGridView x);
        void SqveInSql();
    }
}