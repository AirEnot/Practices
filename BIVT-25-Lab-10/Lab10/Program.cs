namespace Lab10.Purple
{
    public class Program
    {
        public static void Main()
        {
            var simpleSerializator = new PurpleTxtFileManager("Example");
            simpleSerializator.Serialize(Lab9.Purple.Purple());
        }
    }
}