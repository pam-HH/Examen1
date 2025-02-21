using System.Windows.Forms;

namespace Examen1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos CSV (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                  string[] lineas = File.ReadAllLines(openFileDialog.FileName);
                    
                    string[] encabezados = lineas[0].Split(',');
                    string nuevosEncabezados = lineas[0] + ",Edad, Sexo";



                    dgvDatos.ColumnCount = lineas[0].Split(',').Length;
                   
                    string[] headerFinal = nuevosEncabezados.Split(',');
                    for (int i = 0; i < headerFinal.Length; i++)
                    {
                        dgvDatos.Columns.Add(headerFinal[i], headerFinal[i]);
                    }

                  

                    for (int i = 0; i < lineas.Length; i++)
                    {
                        string[] valores = lineas[i].Split(',');
                      
                        string[] filaNueva = new string[headerFinal.Length];

                       
                        for (int j = 0; j < valores.Length; j++)
                        {
                            filaNueva[j] = valores[j];
                        }


                        
                        filaNueva[valores.Length] = " "; 
                        filaNueva[valores.Length + 1] = " "; 

                        dgvDatos.Rows.Add(filaNueva);
                    }


                    MessageBox.Show("El archivo abrio, no me repruebe profe ");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en archivo: " + ex.Message);
                }
            }

        }



        

        private void btnCerrar_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("Deseas salir?", "Sistema", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                this.Close();
            }

        }
    }
}
