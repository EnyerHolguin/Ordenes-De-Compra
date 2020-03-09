﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistroCompra.Entidades
{
    public class Ordenes
    {
        [Key]
        public int OrdenId { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }

        [ForeignKey("OrdenId")]
        public virtual List<OrdenesDetalle> Detalle { get; set; }


        public Ordenes()
        {
            OrdenId = 0;
            ClienteId = 0;
            Fecha = DateTime.Now;
            Monto = 0;
            Detalle = new List<OrdenesDetalle>();
        }
    }

}
