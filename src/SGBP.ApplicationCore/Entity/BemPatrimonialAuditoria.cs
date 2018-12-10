using System;
using System.Collections.Generic;
using System.Text;

namespace SGBP.ApplicationCore.Entity
{
    public class BemPatrimonialAuditoria
    {

        public int BemPatrimonialAuditoriaId { get; set; }

        public int BemPatrimonialId { get; set; }
        public int AuditoriaId { get; set; }

        public Auditoria Auditoria { get; set; }
        public BemPatrimonial BemPatrimonial { get; set; }
    }
}
