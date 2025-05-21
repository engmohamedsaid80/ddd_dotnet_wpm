using Wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain;

public class Consultation : AggregateRoot
{
    private readonly List<DrugAdministration> _administeredDrugs = new();
    private readonly List<VitalSigns> _vitalSignsReadings = new();

    public IReadOnlyCollection<DrugAdministration> AdministeredDrugs => _administeredDrugs.AsReadOnly();
    public IReadOnlyCollection<VitalSigns> VitalSignsReadings => _vitalSignsReadings.AsReadOnly();

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

    public void RegisterVitalSigns(IEnumerable<VitalSigns> vitalSigns)
    {
        ValidateConsultationStatus();

        _vitalSignsReadings.AddRange(vitalSigns);
    }
    public void AdministerDrug(DrugId drugId, Dose dose)
    {
        ValidateConsultationStatus();
        // Logic to administer the drug
        // This could involve creating a DrugAdministration entity and saving it to the database
        var drugAdministration = new DrugAdministration(drugId, dose);
        _administeredDrugs.Add(drugAdministration);
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
