using static HBooking.Model.Guest;

namespace HBooking.Interface
{
    public interface IBooking
    {
        Task<IEnumerable<HGuest>> GetHGuestsAsync();
        Task<HGuest> PostHGuestAsync(HGuest hGuest);
        Task<HGuest> GetHGuestByIdAsync(int guestId);
        Task UpdateHGuestAsync(HGuest hGuest);
        IEnumerable<HGuest> GetConfirmedHGuests();
    }
}
