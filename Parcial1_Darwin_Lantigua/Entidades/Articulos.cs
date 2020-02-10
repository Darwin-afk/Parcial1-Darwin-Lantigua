using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Parcial1_Darwin_Lantigua.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public int Existencia { get; set; }
        public int Costo { get; set; }
        public int ValorInventario { get; set; }

        public Articulos()
        {
            ArticuloId = 0;
            Descripcion = string.Empty;
            Existencia = 0;
            Costo = 0;
            ValorInventario = 0;
        }
    }
}
