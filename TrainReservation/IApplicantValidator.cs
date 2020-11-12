using ReservationLib.Entity;
using System;

namespace ReservationLib.Services
{
    public interface IApplicantValidator
    {
        bool IsValid { get; }
        void Validate(string applicantName, string Tckn);

        ValidateResult ValidateResult { get; }

        int Count { get; set; }
    }
}