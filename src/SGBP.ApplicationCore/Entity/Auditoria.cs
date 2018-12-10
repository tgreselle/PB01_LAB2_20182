using System;
using System.Collections.Generic;
using System.Text;

namespace SGBP.ApplicationCore.Entity
{
    public class Auditoria
    {

        public int AuditoriaId { get; set; }
        public DateTime Data { get; set; }
        public Boolean Aprovado { get; set; }

        public List<BemPatrimonialAuditoria> BemPatrimonialAuditoria { get; set; }
    }
}
