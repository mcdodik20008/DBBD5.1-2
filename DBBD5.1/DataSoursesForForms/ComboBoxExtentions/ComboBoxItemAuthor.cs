namespace DBBD51
{
    public class ComboBoxItemAuthor : IComboBoxItem
    {
        int Pk;
        string Name;

        public ComboBoxItemAuthor(int pk, string name)
        {
            Pk = pk;
            Name = name;
        }

        public string[] GetValue() => new[] { Pk.ToString(), Name };
    }
}
