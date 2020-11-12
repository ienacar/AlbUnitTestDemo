using NunitDemoLib.Entity;
using ReservationLib.Entity;
using System;

namespace ReservationLib.Services
{
    public interface ISeatValidator
    {
        void Initialize();

        bool Validate(string vehicleId,string country, Seat seat, DateTime date);

        void Validate(string vehicleId, string country, Seat seats, DateTime date,out bool isValid);

        void Validate(string vehicleId, string country, Seat seats, DateTime date,ref VerificationStatus status);
    }
}