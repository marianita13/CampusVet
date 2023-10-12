using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.entities
{
    public class ClienteTelefono : BaseEntity
    {
        //public readonly object Id;

        [Required]
        public int IdCliente { get; set; }
        public Cliente Clientes { get; set; }

        [Required]
        public string Numero { get; set; }
    }
}