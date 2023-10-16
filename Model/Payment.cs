using static HBooking.Model.Guest;
using System.ComponentModel.DataAnnotations;

namespace HBooking.Model
{
    public class Payment
    {

        [Key]
        public int PaymentId { get; set; }

        [Required]
        public string BookingId { get; set; }

        [Required]
        public string CardNumber { get; set; }

        [Required]
        public int ExpiryMonth { get; set; }

        [Required]
        public int ExpiryYear { get; set; }

        [Required]
        public string NameOnCard { get; set; }

        [Required]
        [Range(100, 999)]
        public int CVVNumber { get; set; }

        public HGuest? HGuest { get; set; }
    }
}
