using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Parcial1_Darwin_Lantigua.Entidades;
using Parcial1_Darwin_Lantigua.BLL;
using Parcial1_Darwin_Lantigua.Consultar;

namespace Parcial1_Darwin_Lantigua
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;
            Articulos articulos = new Articulos();

            if (!validar())
                return;

            articulos = llenaClase();

            if (Convert.ToInt32(ArticuloIdTextBox.Text) == 0)
                paso = ArticulosBLL.Guardar(articulos);
            else
            {
                if (existeEnLaBaseDeDatos())
                    paso = ArticulosBLL.Modificar(articulos);
                else
                {
                    MessageBox.Show("No existe ese articulo");
                }
            }

            if (paso)
            {
                MessageBox.Show("Guardado exitoso");
                limpiar();
            }
            else
                MessageBox.Show("No se pudo guardar");
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            Articulos articulos = new Articulos();
            int.TryParse(ArticuloIdTextBox.Text, out id);

            limpiar();

            articulos = ArticulosBLL.Buscar(id);

            if (articulos != null)
            {
                MessageBox.Show("Articulo encontrado");
                llenaCampo(articulos);
            } 
            else
                MessageBox.Show("Articulo no encontrado");
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            int.TryParse(ArticuloIdTextBox.Text, out id);

            limpiar();

            if (ArticulosBLL.Eliminar(id))
                MessageBox.Show("Articulo eliminado");
            else
                MessageBox.Show("Articulo no eliminado");
        }

        private void limpiar()
        {
            ArticuloIdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            ExistenciaTextBox.Text = "0";
            CostoTextBox.Text = "0";
            ValorInventiarioTextBox.Text = "0";
        }

        private bool validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(ArticuloIdTextBox.Text))
                paso = false;
            else
            {
                for(int i = 0; i < ArticuloIdTextBox.Text.Length; i++)
                {
                    if (!char.IsDigit(ArticuloIdTextBox.Text[i]) || Convert.ToInt32(ArticuloIdTextBox.Text[i]) < 0)
                        paso = false;
                }
            }


            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
                paso = false;

            if (string.IsNullOrWhiteSpace(ExistenciaTextBox.Text))
                paso = false;
            else
            {
                for (int i = 0; i < ExistenciaTextBox.Text.Length; i++)
                {
                    if (!char.IsDigit(ExistenciaTextBox.Text[i]) || Convert.ToInt32(ExistenciaTextBox.Text[i]) < 0)
                        paso = false;
                }
            }

            if (string.IsNullOrWhiteSpace(CostoTextBox.Text))
                paso = false;
            else
            {
                for (int i = 0; i < CostoTextBox.Text.Length; i++)
                {
                    if (!char.IsDigit(CostoTextBox.Text[i]) || Convert.ToInt32(CostoTextBox.Text[i]) < 0)
                        paso = false;
                }
            }

            if (string.IsNullOrWhiteSpace(ValorInventiarioTextBox.Text))
                paso = false;
            else
            {
                for (int i = 0; i < ValorInventiarioTextBox.Text.Length; i++)
                {
                    if (!char.IsDigit(ValorInventiarioTextBox.Text[i]) || Convert.ToInt32(ValorInventiarioTextBox.Text[i]) < 0)
                        paso = false;
                }
            }

            if (paso == false)
                MessageBox.Show("Datos invalidos");

            return paso;
        }

        private Articulos llenaClase()
        {
            Articulos articulos = new Articulos();
            articulos.ArticuloId = Convert.ToInt32(ArticuloIdTextBox.Text);
            articulos.Descripcion = DescripcionTextBox.Text;
            articulos.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
            articulos.Costo = Convert.ToInt32(CostoTextBox.Text);
            articulos.ValorInventario = Convert.ToInt32(ValorInventiarioTextBox.Text);

            return articulos;
        }

        private bool existeEnLaBaseDeDatos()
        {
            Articulos articulos = ArticulosBLL.Buscar(Convert.ToInt32(ArticuloIdTextBox.Text));
            return articulos != null;
        }

        private void llenaCampo(Articulos articulos)
        {
            ArticuloIdTextBox.Text = Convert.ToString(articulos.ArticuloId);
            DescripcionTextBox.Text = articulos.Descripcion;
            ExistenciaTextBox.Text = Convert.ToString(articulos.Existencia);
            CostoTextBox.Text = Convert.ToString(articulos.Costo);
            ValorInventiarioTextBox.Text = Convert.ToString(articulos.ValorInventario);
        }

        private void ExistenciaTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ExistenciaTextBox != null && CostoTextBox != null)
            {
                if(ValorInventiarioTextBox!= null)
                {
                    if (ExistenciaTextBox.Text != string.Empty && CostoTextBox.Text != string.Empty)
                    {
                        int existencia = Convert.ToInt32(ExistenciaTextBox.Text);
                        int costo = Convert.ToInt32(CostoTextBox.Text);
                        int valor = existencia * costo;
                        ValorInventiarioTextBox.Text = Convert.ToString(valor);
                    }
                    else
                        ValorInventiarioTextBox.Text = "0";
                }
            }
        }

        private void CostoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ExistenciaTextBox != null && CostoTextBox != null)
            {
                if (ValorInventiarioTextBox != null)
                {
                    if (ExistenciaTextBox.Text != string.Empty && CostoTextBox.Text != string.Empty)
                    {
                        int existencia = Convert.ToInt32(ExistenciaTextBox.Text);
                        int costo = Convert.ToInt32(CostoTextBox.Text);
                        int valor = existencia * costo;
                        ValorInventiarioTextBox.Text = Convert.ToString(valor);
                    }
                    else
                        ValorInventiarioTextBox.Text = "0";
                }
            }
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            ConsultarUI c = new ConsultarUI();
            c.Show();
        }
    }
}
