using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpm.Clinic.Domain.ValueObjects
{
    public record VitalSigns
    {
        public VitalSigns(decimal temperature,
                          int hearRate,
                          int respiratoryRate)
        {
            ReadingDateTime = DateTime.UtcNow;
            Temperature = temperature;
            HeartRate = hearRate;
            RespiratoryRate = respiratoryRate;
        }
        public DateTime ReadingDateTime { get; init; }
        public decimal Temperature { get; init; }
        public int HeartRate { get; init; }
        public int RespiratoryRate { get; init; }
    }
}
