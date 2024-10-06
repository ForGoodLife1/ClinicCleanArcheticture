namespace Clinic.Core.Feautres.PatientCQRS.Queries.ResponseQueries
{
    public class GetPatientByIDResponse
    {
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } = null!;
        public string Gender { get; set; } = null!;

    }

}
