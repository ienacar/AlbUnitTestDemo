using NunitDemoLib.Entity;

namespace ReservationLib.Entity
{
    public class TrainSeat : Seat
    {
        public string Coach { get; private set; }

        public override int MinNumber => base.MinNumber;

        public override int MaxNumber { get { return 50; } }

        public TrainSeat(string coach, int seatNumber) : base(seatNumber)
        {
            Coach = coach;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            TrainSeat other = obj as TrainSeat;

            return this.Coach == other.Coach && this.SeatNumber == other.SeatNumber;
        }
    }
}
