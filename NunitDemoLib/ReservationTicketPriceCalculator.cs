namespace NunitDemoLib
{
    public class ReservationTicketPriceCalculator
    {
        public decimal CalculateTicketPrice(decimal price,int term,decimal rate)
        {
            return price / term * (1+rate);
        }
    }
}
