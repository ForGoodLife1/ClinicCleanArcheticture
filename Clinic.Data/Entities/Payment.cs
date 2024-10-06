using System;
using System.Collections.Generic;

namespace Clinic.Data.Entities;

public partial class Payment
{
    public int PaymentId { get; set; }

    public DateOnly PaymentDate { get; set; }

    public string? PaymentMethod { get; set; }

    public decimal AmountPaid { get; set; }

    public string? AdditionalNotes { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
}
