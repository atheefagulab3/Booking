using HBooking.Context;
using HBooking.Interface;
using HBooking.Model;
using static HBooking.Model.Guest;

namespace HBooking.Service
{
    public class PaymentRepo :IPayment
    {
        private readonly BookingContext _bookingContext;

        public PaymentRepo(BookingContext bookingContext)
        {
            _bookingContext = bookingContext;
        }

        public IEnumerable<Payment> GetPayment()
        {
            return _bookingContext.Payments.ToList();
        }

        public Payment PostPayment(Payment payment)
        {
            try
            {
                // Save the payment details
                _bookingContext.Payments.Add(payment);
                _bookingContext.SaveChanges();

                HGuest associatedGuest = _bookingContext.HGuests.FirstOrDefault(g => g.BookingId == payment.BookingId);
                if (associatedGuest != null)
                {
                    associatedGuest.IsConfirmed = ConfirmationStatus.Confirmed;
                    _bookingContext.SaveChanges();
                }

                return payment;
            }
            catch (Exception ex)
            {
                // Log or print the complete exception details
                Console.WriteLine("An error occurred while saving changes: " + ex.ToString());
                throw; // Re-throw the exception to allow it to be handled at a higher level
            }
        }
    }
}
