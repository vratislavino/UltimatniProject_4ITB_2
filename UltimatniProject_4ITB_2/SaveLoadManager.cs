using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;

namespace UltimatniProject_4ITB_2
{
    public class SaveLoadManager
    {
        public void SaveShapes(IEnumerable<Shape> shapes, string path)
        {
            string toSave = JsonConvert.SerializeObject(shapes.Select(s => s.GetDTO()));
            File.WriteAllText(path, toSave);
        }

        public List<Shape> LoadShapes(string path)
        {
            string toLoad = File.ReadAllText(path);
            var dtos = JsonConvert.DeserializeObject<List<Shape.ShapeDTO>>(toLoad);

            var shapes = dtos.Select(dto =>
                Activator.CreateInstance(dto.shapeType, dto) as Shape
            );

            return shapes.ToList();
        }

        public Assembly LoadAssemblyFromFile(string path)
        {
            try
            {
                return Assembly.LoadFrom(path);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}
