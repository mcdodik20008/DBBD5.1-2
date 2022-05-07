namespace DBBD51
{
    public class ComboBoxItemBook : IComboBoxItem
    {
        public int FkLk;
        public int Pk;
        public string Name;
        public int FkAut;
        public string NameAut;

        public ComboBoxItemBook(int fkLk, int pk, string name, int fkAut, string nameAut)
        {
            Pk = pk;
            FkLk = fkLk;
            Name = name;
            FkAut = fkAut;
            NameAut = nameAut;
        }

        public string[] GetValue() => new[] { FkLk.ToString(), Pk.ToString(), Name, FkAut.ToString() };
    }
}
