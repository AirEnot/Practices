
using System.Diagnostics.Contracts;
using System.Security.Principal;

namespace Lab10.Purple
{
    public class PurpleTxtFileManager : ISerializer
    {
        private string _name;
        private string _extension;
        public string Extention => _extension;
        public PurpleTxtFileManager(string name)
        {
            _name = name;
        }

        public PurpleTxtFileManager(string name, string something = "txt")
        {
            _name = name;
            _extension = something;
        }

        public void Serialize(Lab9.Purple.Purple obj)
        {
            var folder = Directory.GetCurrentDirectory();

            folder = Directory.GetParent(folder).Parent.Parent.FullName;
            
            folder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            var filePath = Path.Combine(folder, Name);
            filePath += "." + Extention;

            if (File.Exists(filePath)) File.Delete(filePath);

            if (!File.Exists(filePath)) File.Create(filePath).Close();

            File.WriteAllText(filePath, obj.Input);

            File.AppendAllText(filePath, obj.Input);

            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Type", obj.GetType().Name);
            dict.Add("Input", obj.Input);


            var d = dict.ToArray();
            string[] lines = new string[dict.Count];
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = d[i].Key + ":" + d[i].Value + "\n";
            }

            File.WriteAllLines(filePath, lines);

            File.ReadAllText(filePath); // неудобно

            lines = File.ReadAllLines(filePath);

            var pair = lines[0].Split(":", 2, StringSplitOptions.RemoveEmptyEntries);

            Lab9.Purple.Purple desObj;
            if(pair[0] == "Type")
            {
                switch (pair[1])
                {
                    case "Task1" : desObj = new Lab9.Purple.Purple(); break;
                    case "Task2" : desObj = new Lab9.Purple.Purple(); break;

                }
            }

        }
    }
} 