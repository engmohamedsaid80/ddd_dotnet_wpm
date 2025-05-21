using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain
{
    public class DrugAdministration :Entity
    {
        public DrugId DrugId { get; init; }
        public Dose Dose { get; init; }
        public DrugAdministration(DrugId drugId, Dose dose)
        {
            Id = Guid.NewGuid();
            DrugId = drugId;
            Dose = dose;
        }
    }
}
