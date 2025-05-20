using Wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain;

public class Consultation : AggregateRoot
{
    public DateTime StartedAt { get; init; }
    public DateTime? EndedAt { get; private set; }
    public Text Diagnosis { get; private set; }
    public Text Treatment { get; private set; }

    public PaitentId PaitentId { get; init; }

    public Weight CurrentWeight { get; private set; }

    public ConsultationStatus Status { get; private set; }

    public Consultation(PaitentId paitentId)
    {
        Id = Guid.NewGuid();
        PaitentId = paitentId;
        Status = ConsultationStatus.Open;
        StartedAt = DateTime.UtcNow;
    }

    public void End()
    {
        ValidateConsultationStatus();

        if (Diagnosis == null || Treatment == null || CurrentWeight == null)
            throw new InvalidOperationException("Cannot close a consultation due to missing data.");
        
        Status = ConsultationStatus.Closed;
        EndedAt = DateTime.UtcNow;
    }
    public void SetWeight(Weight weight)
    {
        ValidateConsultationStatus();
        CurrentWeight = weight;
    }

    public void SetDiagnosis(Text diagnosis)
    {
        ValidateConsultationStatus();
        Diagnosis = diagnosis;
    }

    public void SetTreatment(Text treatment)
    {
        ValidateConsultationStatus();
        Treatment = treatment;
    }

    private void ValidateConsultationStatus()
    {
        if(Status != ConsultationStatus.Open)
            throw new InvalidOperationException("Cannot change a closed or canceled consultation.");
    }
}

public enum ConsultationStatus
{
    Open,
    Closed,
    Canceled
}
