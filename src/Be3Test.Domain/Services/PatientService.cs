using Be3Test.Domain.Entities;
using Be3Test.Domain.Interfaces.Services;
using Be3Test.Domain.Repositories;
using System;
using System.Linq;

namespace Be3Test.Domain.Services
{
    public class PatientService : Service<Patient>, IPatientService
    {
        private readonly IPatientRepository _repository;
        private readonly IInsuranceRepository _insuranceRepository;
        private readonly IInsuranceCardRepository _insuranceCardRepository;

        public PatientService(IPatientRepository repository,
                              IInsuranceRepository insuranceRepository,
                              IInsuranceCardRepository insuranceCardRepository) : base(repository)
        {
            _repository = repository;
            _insuranceRepository = insuranceRepository;
            _insuranceCardRepository = insuranceCardRepository;
        }

        public new void Add(Patient patient)
        {
            if (patient == null || !patient.IsValid)
                throw new ArgumentNullException(nameof(patient));

            if (_repository.Get().FirstOrDefault(p => p.CPF == patient.CPF) != null)
                throw new ArgumentException("patient already exists");

            _repository.Add(patient);
        }

        public new Patient Find(Guid id)
        {
            return _repository.GetComplete(id);
        }

        public void Update(Patient patient, Guid id, Guid? insuranceId)
        {
            var dbPatient = _repository.GetComplete(id);

            if (dbPatient == null)
                return;

            if (insuranceId != null && patient.InsuranceCards != null)
            {
                var dbInsurance = _insuranceRepository.Get().FirstOrDefault(i => i.Id == insuranceId);

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

                _insuranceCardRepository.Add(insuranceCard);
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

            _repository.Update(dbPatient);
        }

    }
}
