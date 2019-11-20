using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_ArmandoSarrionGonzalez.Entidades
{
    class DTODocumento
    {
        public int identificador { get; set; }

        public String tipo { get; set; }

        public String contenido { get; set; }

        public String remitente { get; set; }

        public DateTime fechaLlegada { get; set; }

        public DateTime fechaSalida { get; set; }

        public String juzgado { get; set; }
    }
}
