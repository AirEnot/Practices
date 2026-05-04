using System.Xml.Serialization;

namespace Serialization
{
    public class MyXmlSeializator : MySerializer
    {
        string  _desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string _path = Path.Combine(_desktopPath, "example2.xml");
        public new void Serialize()
        {
            var ser = new XmlSerializer(typeof(DTOStudent[]));

            using (FileStream fs = new StreamWriter(_path))
            {
                var dtoObjects = new List<DTOStudent>(_studetns.Count);
                foreach(var st in _students)
                {
                    dtoObjects.Add(new DTOStudent(st));
                }
                ser.Serialize(fs, _students);
            }
        }

        public new void Deserialize()
        {
            
        }

        public class DTOStudent
        {
            private static int _counter = 0;
            public int Id { get; private set; }
            public string Name { get; private set; }
            public string Surname { get; private set; }
            public DTOSubject[] Subjects { get; private set; }

            public DTOStudent()
            {
                
            }

            public DTOStudent(Student student)
            {
                Id = student.Id;
                Name = student.Name;
                Surname = student.Surname;

                var dtoObjects = new List<DTOSubject>(Subjects.Count);
                foreach (var sb in _subjects)
                Subjects = student.Subjects;
            }

            public Stuednt FormStudent()
            {
                return new Student(Id, Name, Surname, Subjects);
            }
        }

        public class DTOSubject
        {
            private List<int> _marks;
            public string Name { get; private set; }
            public int[] Marks => _marks.ToArray();

            public DTOSubject()
            {

            }

            public DTOSubject(Subject subject)
            {
                Name = subject.Name;
                Marks = subject.Marks;
            }
        }
    }
}