    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    namespace WindowsFormsApp1
    {
        public partial class JuegoAleatorio : Form
        {
        // Declarar numeroAleatorio como una variable de instancia
        private int numeroAleatorio, contador;
        private List<int> numerosIngresados = new List<int>(); // Lista para almacenar los números ingresados
        public JuegoAleatorio()
            {
                InitializeComponent();
            contador = 0;
            }


        private void InicializarFormulario()
        {
            // Ocultar todos los labels de la lista al iniciar
            Label[] labels = { label4, label5, label6, label7, label8, label9, label10, label11, label12, label13 };
            foreach (var label in labels)
            {
                label.Visible = false;

            }

            // Deshabilitar el button2 al iniciar
            button2.Enabled = false;
            button2.Visible = false;
            label2.Visible = false;
            labelResultado.Visible = false;
            textBox2.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
            {

            }

            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                

            }

            private void button2_Click(object sender, EventArgs e)
            {
            contador++;
            if (int.TryParse(textBox2.Text, out int datoIngresado))
            {
                // Comparar el dato ingresado con el número aleatorio
                if (datoIngresado == numeroAleatorio)
                {
                    label3.Text = "FELICIDADES GANASTE" + numeroAleatorio.ToString();
                    labelResultado.Text = "¡El número es correcto!";
                    labelResultado.ForeColor = System.Drawing.Color.Green;
                    label3.Visible = true;
                    labelResultado.Visible = true;
                    button1.Enabled = true;
                }
                else if (datoIngresado < numeroAleatorio)
                {
                    labelResultado.Text = "El número ingresado es menor.";
                    labelResultado.ForeColor = System.Drawing.Color.Red;
                    labelResultado.Visible = true;
                }
                else
                {
                    labelResultado.Text = "El número ingresado es mayor.";
                    labelResultado.ForeColor = System.Drawing.Color.Red;
                    labelResultado.Visible = true;
                }

                // Agregar el número ingresado a la lista
                numerosIngresados.Add(datoIngresado);
                ActualizarLabels();

                if (contador >= 10){
                    labelResultado.Text = "Lo Siento Perdiste";
                    labelResultado.ForeColor= System.Drawing.Color.Red;
                    labelResultado.Visible = true;
                    button2.Enabled = false;
                    button1.Enabled = true;
                   // Ocultar todos los labels para el caso de pérdida
                    foreach (var label in new[] { label4, label5, label6, label7, label8, label9, label10, label11, label12, label13 })
                    {
                        label.Visible = false;
                    }
                    contador = 0;
                }
                // Limpiar textBox2 para el siguiente ingreso
                textBox2.Clear();

            }
                    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            // Generar un número aleatorio entre 100 y 999
             numeroAleatorio = random.Next(100, 1000);

            // Mostrar el número en la caja de texto
            // 
            button1.Enabled = false;
                button2.Enabled = true;
            button2.Visible = true;
            label2.Visible = true;
            textBox2.Visible = true;
            // Limpiar textBox2 para el siguiente ingreso
            textBox2.Clear();
            foreach (var label in new[] { label4, label5, label6, label7, label8, label9, label10, label11, label12, label13 })
            {
                label.Visible = false;
            }
            // Limpiar la lista de números ingresados
            numerosIngresados.Clear();

            // Actualizar los labels para reflejar que no hay números
            ActualizarLabels();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Inicializar la configuración de los controles
            InicializarFormulario();
        }

        private void labelResultado_Click(object sender, EventArgs e)
        {

        }

        private void ActualizarLabels()
        {
            // Suponiendo que tienes 5 labels para mostrar los números
            Label[] labels = { label4, label5, label6, label7, label8, label9, label10, label11, label12, label13 };

            // Ocultar todos los labels
            foreach (var label in labels)
            {
                label.Visible = false;
            }

            // Mostrar los números en los labels en el orden en que se ingresaron
            for (int i = 0; i < numerosIngresados.Count && i < labels.Length; i++)
            {
                labels[i].Text = numerosIngresados[i].ToString();
                labels[i].Visible = true;
            }
        }
    }
    }
