using System;
using System.Collections.Generic;

namespace Be3Test.Domain.Entities
{
    public class Patient : BaseEntity
    {
        public Patient() : base()
        {
        }

        public string MedicalRecord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Genre { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string UfRG { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public string Phone { get; set; }

        public List<InsuranceCard> InsuranceCards { get; set; }

        public bool IsValid { get { return validateCpf() && (!string.IsNullOrWhiteSpace(CellPhone) || !string.IsNullOrWhiteSpace(Phone)); } }

        private bool validateCpf()
        {
			var cpf = CPF;

			int[] mult1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] mult2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digit;
			int sum;
			int rest;
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;

			tempCpf = cpf.Substring(0, 9);
			sum = 0;

			for (int i = 0; i < 9; i++)
				sum += int.Parse(tempCpf[i].ToString()) * mult1[i];

			rest = sum % 11;
			
			if (rest < 2)
				rest = 0;
			else
				rest = 11 - rest;

			digit = rest.ToString();
			tempCpf = tempCpf + digit;
			sum = 0;

			for (int i = 0; i < 10; i++)
				sum += int.Parse(tempCpf[i].ToString()) * mult2[i];

			rest = sum % 11;

			if (rest < 2)
				rest = 0;
			else
				rest = 11 - rest;

			digit = digit + rest.ToString();
			return cpf.EndsWith(digit);
		}
    }
}
