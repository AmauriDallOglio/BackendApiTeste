using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApiTeste
{
    public class AtivoLocalDto
    {
        public Guid Id_Tenant { get; set; } // Tipo: uniqueidentifier
        public string Referencia { get; set; } = string.Empty;  // Tipo: varchar(50)
        public string Area { get; set; } = string.Empty; // Tipo: varchar(50)
        public string Setor { get; set; } = string.Empty; // Tipo: varchar(50)
        public string Descricao { get; set; } = string.Empty; // Tipo: varchar(300)
    }
}
