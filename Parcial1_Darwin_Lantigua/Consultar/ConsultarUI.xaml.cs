using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Parcial1_Darwin_Lantigua.Entidades;
using Parcial1_Darwin_Lantigua.BLL;

namespace Parcial1_Darwin_Lantigua.Consultar
{
    /// <summary>
    /// Interaction logic for ConsultarUI.xaml
    /// </summary>
    public partial class ConsultarUI : Window
    {
        public ConsultarUI()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            List<Articulos> lista = new List<Articulos>();

            lista = ArticulosBLL.GetList(a => true);

            ArticulosDataGrid.ItemsSource = lista;
        }
    }
}
