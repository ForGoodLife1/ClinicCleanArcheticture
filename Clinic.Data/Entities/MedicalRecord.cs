using System;
using System.Collections.Generic;

namespace Clinic.Data.Entities;


public partial class MedicalRecord
{
    public int MedicalRecordId { get; set; }

    public string? VisitDescription { get; set; }

    public string? Diagnosis { get; set; }

    public string? AdditionalNotes { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
}
