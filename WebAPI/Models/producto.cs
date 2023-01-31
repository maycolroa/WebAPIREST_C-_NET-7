using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class producto
    {
        public int Id { get; set; }

        public string Nombre { get; set; }= string.Empty;

        public string Precio { get; set; }= string.Empty;

        public DateTime FechaDeAlta { get; set; }
    }
}