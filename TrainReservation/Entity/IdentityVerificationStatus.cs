namespace ReservationLib.Entity
{
    public class VerificationStatus
    {
        public bool Passed { get; }

        private VerificationStatus() { }

        public VerificationStatus(bool identityVerified)
        {
            Passed = identityVerified;
        }
    }
}