using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//--------------------------------------------------------------------------------------------------------------------------
// Armando Sarrión González
// Clase entidad con los datos del usuario
//--------------------------------------------------------------------------------------------------------------------------

namespace Proyecto_ArmandoSarrionGonzalez.Entidades
{
    class DTOUsuario
    {
        public string nombre { get; set; }
        public string contraseña { get; set; }
        public DateTime fechaRegistro { get; set; }
    }
}
