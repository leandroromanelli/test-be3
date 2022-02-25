using Be3Test.Domain.Entities;
using System;

namespace Be3Test.Domain.Interfaces.Services
{
    public interface IPatientService : IService<Patient>
    {
        void Update(Patient patient, Guid id, Guid? insuranceCardId);
    }
}
