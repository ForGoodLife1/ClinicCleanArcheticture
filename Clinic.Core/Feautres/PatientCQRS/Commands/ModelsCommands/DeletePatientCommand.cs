using Clinic.Core.Bases;
using MediatR;

namespace Clinic.Core.Feautres.PatientCQRS.Commands.ModelsCommands
{
    public class DeletePatientCommand : IRequest<Response<string>>
    {
        public DeletePatientCommand(int id)
        {
            Id=id;
        }

        public int Id { get; set; }
    }
}
