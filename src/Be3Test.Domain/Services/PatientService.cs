using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Be3Test.Domain.Interfaces.UnitOfWork;
using Be3Test.Domain.Repositories;
using Be3Test.Domain.Specifications;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Be3Test.Domain.Services
{
    public class PatientService : Service<Patient>, IPatientService
    {
        private readonly IPatientRepository _repository;

        public PatientService(IUnitOfWork unitOfWork) : base(unitOfWork, unitOfWork.PatientRepository)
        {
            _repository = unitOfWork.PatientRepository;
        }

        public new async Task Add(Patient patient, CancellationToken cancellationToken)
        {
            if (patient == null || !patient.IsValid)
                throw new ArgumentNullException(nameof(patient));

            if (await _repository.Find(new PatientSpecification(p => p.CPF == patient.CPF), cancellationToken) != null)
                throw new ArgumentException("patient already exists");

            await _unitOfWork.PatientRepository.Add(patient, cancellationToken);
            await _unitOfWork.Save(cancellationToken);
        }

        public new async Task<Patient> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _repository.GetComplete(id, cancellationToken);
        }

        public async Task Update(Patient patient, Guid id, Guid? insuranceId, CancellationToken cancellationToken)
        {
            var dbPatient = await _unitOfWork.PatientRepository.GetComplete(id, cancellationToken);

            if (dbPatient == null)
                return;

            if (insuranceId != null && patient.InsuranceCards != null)
            {
                var dbInsurance = await _unitOfWork.InsuranceRepository.FindMany(new InsuranceSpecification(i => i.Id == insuranceId), cancellationToken);

                if (dbInsurance == null)
                    throw new ArgumentNullException(nameof(insuranceId));

                dbPatient.InsuranceCards.ForEach(ic => ic.Deactivate());

                var insuranceCard = new InsuranceCard()
                {
                    Id = patient.InsuranceCards.FirstOrDefault().Id,
                    InsuranceId = insuranceId.Value,
                    PatientId = dbPatient.Id,
                    Number = patient.InsuranceCards.FirstOrDefault().Number,
                    Validity = patient.InsuranceCards.FirstOrDefault().Validity
                };

                await _unitOfWork.InsuranceCardRepository.Add(insuranceCard, cancellationToken);
            }

            if (patient.BirthDate != new DateTime())
                dbPatient.BirthDate = patient.BirthDate;

            if (!string.IsNullOrWhiteSpace(patient.CellPhone))
                dbPatient.CellPhone = patient.CellPhone;

            if (!string.IsNullOrWhiteSpace(patient.CPF))
                dbPatient.CPF = patient.CPF;

            if (!string.IsNullOrWhiteSpace(patient.Email))
                dbPatient.Email = patient.Email;

            if (!string.IsNullOrWhiteSpace(patient.FirstName))
                dbPatient.FirstName = patient.FirstName;

            if (!string.IsNullOrWhiteSpace(patient.LastName))
                dbPatient.LastName = patient.LastName;

            if (!string.IsNullOrWhiteSpace(patient.Genre))
                dbPatient.Genre = patient.Genre;

            if (!string.IsNullOrWhiteSpace(patient.MedicalRecord))
                dbPatient.MedicalRecord = patient.MedicalRecord;

            if (!string.IsNullOrWhiteSpace(patient.Phone))
                dbPatient.Phone = patient.Phone;

            if (!string.IsNullOrWhiteSpace(patient.RG))
                dbPatient.RG = patient.RG;

            if (!string.IsNullOrWhiteSpace(patient.UfRG))
                dbPatient.UfRG = patient.UfRG;

            await _unitOfWork.PatientRepository.Update(dbPatient, cancellationToken);

            await _unitOfWork.Save(cancellationToken);
        }

    }
}
