namespace Company.TestTask.Model
{
    public class Item
    {
        public Config.ItemType Type { get; private set; }

        public Item(Config.ItemType type)
        {
            Type = type;
        }
    }
}
