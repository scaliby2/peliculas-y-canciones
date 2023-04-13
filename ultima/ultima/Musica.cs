using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ultima
{
    public partial class Musica : Form
    {
        public Form1 Musicas;
        Dictionary<string, Cancion> canciones;
        public Musica()
        {
            InitializeComponent();
            canciones = new Dictionary<string, Cancion>();
        }

        private void Musica_Load(object sender, EventArgs e)
        {

        }
        public void Escribir(Cancion c)
        {
            StreamWriter n = new StreamWriter("canciones.txt", true);
            n.WriteLine(c.nombre + ", " + c.año + "," + c.genero + "," + c.artista);
            n.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string artista = textBox1.Text;
            string Genero = comboBox1.Text;
            string nombre = textBox2.Text;
            string año = textBox3.Text;
            if (nombre.Length == 0 || artista.Length == 0 || Genero.Length == 0|| año.Length== 0)
            {
                MessageBox.Show("Nombre o artista vacio");
            }
           else {
                int Año = Convert.ToInt32(textBox3.Text);
                if (Año > 0 && Año <= 2019)
                {
                    StreamReader nuevo = new StreamReader("canciones.txt");
                    while (nuevo.EndOfStream)
                    {
                        var line = nuevo.ReadToEnd().Split(',');
                        string Artista = line[0];
                        string Nombre = line[1];
                        string genero = line[2];
                        int anio = Convert.ToInt32(line[3]);
                        Cancion n = new Cancion(Nombre,anio,genero,Artista);
                        canciones.Add(artista, n);

                    }
                    nuevo.Close();
                    foreach (var item in canciones.Values)
                    {
                        if ( item.nombre == nombre && item.artista ==artista && item.año == Año)
                        {
                            MessageBox.Show("Ya existe una cancion asi");
                            break;
                        }
                    }
                    Cancion c = new Cancion(nombre, Año, Genero, artista);
                    canciones.Add(nombre, c);
                    Task.Factory.StartNew(() => Escribir(c));
                    this.Hide();
                    Musicas.Show();
                    MessageBox.Show(c.MostrarDescripcion());

                }
                else
                {
                    MessageBox.Show("años no validos");
                }
            }
        }
    }
}
