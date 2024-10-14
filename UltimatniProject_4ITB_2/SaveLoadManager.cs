using Newtonsoft.Json;

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
    }
}
