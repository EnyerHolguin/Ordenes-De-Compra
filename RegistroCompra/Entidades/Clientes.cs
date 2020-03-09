using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RegistroCompra.Entidades
{
   public class Clientes
    {
        
        [Key]
        public int ClienteId { get; set; }
        public string Nombre { get; set; }

        public Clientes()
        {
            ClienteId = 0;
            Nombre = string.Empty;
        }
    }
}

