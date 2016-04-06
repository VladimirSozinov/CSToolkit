namespace CSToolkit.Model
{
    public class SubCommand
    {
        public SubCommand(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }
}
