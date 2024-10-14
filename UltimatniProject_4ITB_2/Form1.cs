using System.Reflection;

namespace UltimatniProject_4ITB_2
{
    public partial class Form1 : Form
    {
        SaveLoadManager saveLoadManager = new SaveLoadManager();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ass = Assembly.GetExecutingAssembly();
            var types = ass.GetTypes();
            var filtered = types.Where(t => t.IsSubclassOf(typeof(Shape))).ToList();

            comboBox1.Items.AddRange(filtered.ToArray());
            if (filtered.Count > 0)
                comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e) // add shape
        {
            var typ = comboBox1.SelectedItem as Type;

            var newShape = Activator.CreateInstance(
                typ,
                button2.BackColor,
                canvas1.Width / 2,
                canvas1.Height / 2,
                checkBox1.Checked
                ) as Shape;

            canvas1.AddShape(newShape);
        }

        private void addMoreShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Shapes JSON object (*.json)|*.json";
            if(sfd.ShowDialog() == DialogResult.OK)
            {
                var path = sfd.FileName;
                saveLoadManager.SaveShapes(canvas1.Shapes, path);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Shapes JSON object (*.json)|*.json";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var path = ofd.FileName;
                var newShapes = saveLoadManager.LoadShapes(path);
                canvas1.ClearShapes();

                newShapes.ForEach(s => canvas1.AddShape(s));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button2.BackColor = colorDialog1.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            canvas1.ClearShapes();
        }
    }
}
