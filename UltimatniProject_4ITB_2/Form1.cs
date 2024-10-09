namespace UltimatniProject_4ITB_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // add shape
        {
            canvas1.AddShape(new Circle(
                button2.BackColor,
                canvas1.Width / 2,
                canvas1.Height / 2,
                checkBox1.Checked
                ));
        }

        private void addMoreShapesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                button2.BackColor = colorDialog1.Color;
            }
        }
    }
}
