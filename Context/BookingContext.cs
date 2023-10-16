using static HBooking.Model.Guest;
using Microsoft.EntityFrameworkCore;
using HBooking.Model;

namespace HBooking.Context
{
    public class BookingContext:DbContext
    {
        public DbSet<HGuest> HGuests { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public BookingContext(DbContextOptions<BookingContext> options) : base(options)
        {

        }
    }
}
