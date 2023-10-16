using HBooking.Context;
using HBooking.Interface;
using Microsoft.EntityFrameworkCore;
using static HBooking.Model.Guest;

namespace HBooking.Service
{
    public class BookingRepo:IBooking
    {
        private readonly BookingContext _hotelContext;

        public BookingRepo(BookingContext context)
        {
            _hotelContext = context;
        }

        public async Task<IEnumerable<HGuest>> GetHGuestsAsync()
        {
            return await _hotelContext.HGuests.ToListAsync();
        }

        public async Task<HGuest> PostHGuestAsync(HGuest hGuest)
        {
            _hotelContext.HGuests.Add(hGuest);
            await _hotelContext.SaveChangesAsync();
            return hGuest;
        }

        public async Task<HGuest> GetHGuestByIdAsync(int guestId)
        {
            return await _hotelContext.HGuests.FirstOrDefaultAsync(g => g.GuestId == guestId);
        }

        public async Task UpdateHGuestAsync(HGuest hGuest)
        {
            _hotelContext.Entry(hGuest).State = EntityState.Modified;
            await _hotelContext.SaveChangesAsync();
        }

        public IEnumerable<HGuest> GetConfirmedHGuests()
        {
            return _hotelContext.HGuests.Where(guest => guest.IsConfirmed == ConfirmationStatus.Confirmed).ToList();
        }
    }
}
