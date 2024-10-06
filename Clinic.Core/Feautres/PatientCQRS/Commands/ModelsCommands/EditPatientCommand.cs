﻿using Clinic.Core.Bases;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Clinic.Core.Feautres.PatientCQRS.Commands.ModelsCommands
{
    public class EditPatientCommand : IRequest<Response<String>>
    {
        public int Id { get; set; }
        [Required]
        public string NameAr { get; set; }
        [Required]
        public string NameEn { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

    }
}
