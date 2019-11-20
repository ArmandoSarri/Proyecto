using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_ArmandoSarrionGonzalez.Entidades
{
    class DTOOrganismo
    {
        public int identificador { get; set; }

        public String nombre { get; set; }

        public int telefono1 { get; set; }

        public int telefono2 { get; set; }

        public int fax { get; set; }

        public String direccion { get; set; }

        public String correo { get; set; }
    }
}
