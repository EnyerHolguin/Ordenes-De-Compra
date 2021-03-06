﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistroCompra.Entidades
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }

        [ForeignKey("ProductoId")]
        public virtual List<OrdenesDetalle> OrdenesDetalles { get; set; }

        public Producto()
        {
            ProductoId = 0;
            NombreProducto = string.Empty;
            Precio = 0;

            OrdenesDetalles = new List<OrdenesDetalle>();
        }
    }
}
