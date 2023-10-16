using HBooking.Model;

namespace HBooking.Interface
{
    public interface IPayment
    {
        public IEnumerable<Payment> GetPayment();

        public Payment PostPayment(Payment payment);
    }
}
