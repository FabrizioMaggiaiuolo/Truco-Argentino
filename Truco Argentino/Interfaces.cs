using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truco_Argentino
{
    public interface ILimpiarForms
    {
        ADO ADO { get; set; }
        ADOPartidas ADOPartidas { get; set; }

        public void LimpiarLabels();
    }
}
