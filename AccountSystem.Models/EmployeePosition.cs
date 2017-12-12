using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountSystem.Data.models
{
    public class EmployeePosition
    {
        public long Id { get; set; }

        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public long PositionId { get; set; }
        public Position Position { get; set; }

        public long ProjectId { get; set; }
        public Project Project { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
