using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HBooking.Model
{
    public class Guest
    {
        public enum ConfirmationStatus
        {
            [Display(Name = "Requested")]
            Requested,

            [Display(Name = "Confirmed")]
            Confirmed,

            [Display(Name = "Cancelled")]
            Cancelled = 0
        }

        public class HGuest
        {
            [Key]
            public int GuestId { get; set; }

            [RegularExpression("^[0-9]{8}$")]
            public string? BookingId { get; set; }

            public int CustomerId { get; set; }

            public int HotelId { get; set; }

            public int RoomId { get; set; }

            public string FirstName { get; set; }

            public string LastName { get; set; }

            public string Email { get; set; }

            public long PhoneNumber { get; set; }

            public DateTime Checkin { get; set; }

            public DateTime Checkout { get; set; }

            public int Duration { get; set; }

            public ConfirmationStatus IsConfirmed { get; set; }

            public HGuest()
            {
                IsConfirmed = ConfirmationStatus.Requested;
                Checkin = DateTime.Now;
            }
        }
    }
}
