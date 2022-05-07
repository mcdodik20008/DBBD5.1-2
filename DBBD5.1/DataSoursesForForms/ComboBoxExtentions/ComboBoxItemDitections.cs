namespace DBBD51
{
    class ComboBoxItemDitections : IComboBoxItem
    {
        public int Pk;
        public string Name;

        public ComboBoxItemDitections(int pk, string name)
        {
            Pk = pk;
            Name = name;
        }

        public string[] GetValue() => new[] { Pk.ToString() };
    }
}
