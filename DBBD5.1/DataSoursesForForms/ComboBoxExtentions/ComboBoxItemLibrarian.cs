namespace DBBD51
{
    class ComboBoxItemLibrarian : IComboBoxItem
    {
        public int? Pk;
        public string Name;

        public ComboBoxItemLibrarian(int? pk, string name)
        {
            Pk = pk;
            Name = name;
        }

        public string[] GetValue() => new[] { Pk.ToString(), Name };
    }
}
