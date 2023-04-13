using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ultima
{
    
    public partial class Peliculas : Form
    {
        public Form1 PeliculaS;
        Dictionary<string, Pelicula>PeliculasA;
        public Peliculas()
        {
            InitializeComponent();
            PeliculasA = new Dictionary<string, Pelicula>();
           
        }
        public void Escribir(Pelicula p)
        {
            StreamWriter n = new StreamWriter("peliculas.txt", true);
            n.WriteLine(p.nombre + ", " + p.año + "," + p.genero + "," + p.calificacion);
            n.Close();
        }
        
       
        private void button1_Click(object sender, EventArgs e)
        {
            string Nombre = textBox1.Text;
            string año = textBox2.Text;
            string Genero = comboBox1.Text;
            string calificacion = textBox3.Text;

            if (Nombre.Length == 0 || año.Length == 0 || Genero.Length == 0 || calificacion.Length == 0)
            {
                MessageBox.Show("llene los campos");

            }
            else
            {
                int Calificacion = Convert.ToInt32(textBox3.Text);
                int Año = Convert.ToInt32(textBox2.Text);
                if (Calificacion > 1 && Calificacion < 10 && Año <= 1900 || Año >= 2019)
                {
                    MessageBox.Show("Calificacion no puede ser menor a 1 o mayor a 10,  el año no puede ser menor a 1900 o mayor a 2019");

                }
                else
                {
                    Pelicula p = new Pelicula(Nombre, Año, Genero, Calificacion);
                    PeliculasA.Add(Nombre, p);
                    Task.Factory.StartNew(() => Escribir(p));
                    this.Hide();
                    PeliculaS.Show();
                    MessageBox.Show(p.MostrarDescripcion());

                }
            }
        }
    }
}




