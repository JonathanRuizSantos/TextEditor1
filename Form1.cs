using System.Security;

namespace EditorTextos
{
    public partial class TextEditorMain : Form
    {
        string Ruta;
        public TextEditorMain()
        {
            InitializeComponent();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Clear();
                abrir();
                LeeArchivo();
            }
            catch
            {
                MessageBox.Show("Ocurrio un error");
            }
        }


        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)// Guarda el archivo, pestaña
        {
            try
            {
                File.Delete(Ruta);
                escribeArchivo();
                MessageBox.Show("Archivo guardado satisfactoriamente");
            }
            catch
            {
                MessageBox.Show("Ocurrio un error");
            }
        }

        private void formatoToolStripMenuItem_Click_1(object sender, EventArgs e)// Guarda el Archivo, Barra
        {
            try
            {
                File.Delete(Ruta);
                escribeArchivo();
                MessageBox.Show("Archivo guardado satisfactoriamente");
            }
            catch
            {
                MessageBox.Show("Ocurrio un error");
            }
        }

        private void edicionToolStripMenuItem_Click(object sender, EventArgs e)// Nuevo archivo, barra
        {
            System.Diagnostics.Process.Start("EditorTextos.exe");
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)// Nuevo archivo, pestaña
        {
            System.Diagnostics.Process.Start("EditorTextos.exe");
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)// Guardar como, ventana
        {
            try
            {
                guardar();
                escribeArchivo();
            }
            catch
            {
                MessageBox.Show("Ocurrio un error");
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ayudaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void fuenteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            fontDialog1.Font = richTextBox1.Font;
            fontDialog1.Color = richTextBox1.ForeColor;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                richTextBox1.Font = fontDialog1.Font;
                richTextBox1.ForeColor = fontDialog1.Color;
            }
        }

        private void fondoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = richTextBox1.ForeColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                richTextBox1.ForeColor = MyDialog.Color;
        }

        // ***************************************************************************************** FUNCIONES

        public void abrir()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // aqui va el codigo para abrir y leer el archivo
                Ruta = openFileDialog1.FileName;
                //richTextBox1.Text = "Ruta del archivo: " + Ruta;

            }
        }

        public void guardar()
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // aqui va el codigo para salvar
                Ruta = saveFileDialog1.FileName;
            }
        }

        public void LeeArchivo()
        {
            StreamReader leeArch = new StreamReader(Ruta);
            string linea2;
            try
            {
                linea2 = leeArch.ReadLine();
                while (linea2 != null)
                {
                    richTextBox1.AppendText(linea2 + "\n");
                    linea2 = leeArch.ReadLine();
                }
            }
            catch
            {
                MessageBox.Show("¡Error!    ಥ‿ಥ ");
            }
            leeArch.Close();
        }

        public void escribeArchivo()
        {
            string[] lineas = { richTextBox1.Text, };
            using (StreamWriter escribeA = new StreamWriter(Ruta, true))
            {
                foreach(string linea in lineas)
                {
                    escribeA.WriteLine(linea);
                }
            }
                
        }

        private void fondoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = richTextBox1.ForeColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                richTextBox1.BackColor = MyDialog.Color;
        }
    }
}