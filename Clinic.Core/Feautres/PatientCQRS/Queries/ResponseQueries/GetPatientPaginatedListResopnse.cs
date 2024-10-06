namespace Clinic.Core.Feautres.PatientCQRS.Queries.ResponseQueries
{
    public class GetPatientPaginatedListResopnse
    {
        public GetPatientPaginatedListResopnse(int patientId, string name, string address, string gender)
        {
            PatientId=patientId;
            Name=name;
            Address=address;
            Gender=gender;
        }

        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; } = null!;
        public string Gender { get; set; } = null!;


    }
}
