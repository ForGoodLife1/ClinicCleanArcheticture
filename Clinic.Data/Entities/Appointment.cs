namespace Clinic.Data.Entities;

public partial class Appointment
{
    public int AppointmentId { get; set; }
    public DateTime AppointmentDateTime { get; set; }
    public byte AppointmentStatus { get; set; }

    public int DoctorId { get; set; }
    public virtual Doctor Doctor { get; set; } = null!;

    public int? MedicalRecordId { get; set; }
    public virtual MedicalRecord? MedicalRecord { get; set; }

    public int PatientId { get; set; }
    public virtual Patient Patient { get; set; } = null!;

    public int? PaymentId { get; set; }
    public virtual Payment? Payment { get; set; }
}
