using HBooking.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static HBooking.Model.Guest;

namespace HBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBooking _hGuestRepo;

        public BookingController(IBooking hGuestRepo)
        {
            _hGuestRepo = hGuestRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HGuest>>> GetHGuests()
        {
            try
            {
                var hGuests = await _hGuestRepo.GetHGuestsAsync();
                return Ok(hGuests);
            }
            catch (Exception ex)
            {

                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<HGuest>> Post(HGuest hGuest)
        {
            try
            {
                // Generate BookingId and set default IsConfirmed status
                hGuest.BookingId = GenerateBookingId();
                hGuest.IsConfirmed = ConfirmationStatus.Requested;

                var createdGuest = await _hGuestRepo.PostHGuestAsync(hGuest);
                return CreatedAtAction(nameof(GetHGuestById), new { guestId = createdGuest.GuestId }, createdGuest);
            }
            catch (Exception ex)
            {
                // Properly log the exception and return an appropriate response.
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpGet("{guestId}")]
        public async Task<ActionResult<HGuest>> GetHGuestById(int guestId)
        {
            try
            {
                var hGuest = await _hGuestRepo.GetHGuestByIdAsync(guestId);

                if (hGuest == null)
                {
                    return NotFound();
                }

                return Ok(hGuest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        [HttpPut("{guestId}/cancel")]
        public async Task<ActionResult<HGuest>> CancelHGuest(int guestId)
        {
            try
            {
                var hGuest = await _hGuestRepo.GetHGuestByIdAsync(guestId);

                if (hGuest == null)
                {
                    return NotFound();
                }

                hGuest.IsConfirmed = ConfirmationStatus.Cancelled;
                await _hGuestRepo.UpdateHGuestAsync(hGuest);

                return Ok(hGuest);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("confirmed")]
        public ActionResult<IEnumerable<HGuest>> GetConfirmedHGuests()
        {
            var confirmedGuests = _hGuestRepo.GetConfirmedHGuests();
            return Ok(confirmedGuests);
        }
        private string GenerateBookingId()
        {
            var random = new Random();
            long min = 10000000;
            long max = 99999999;
            long randomNumber = (long)(random.NextDouble() * (max - min + 1)) + min;
            return randomNumber.ToString();
        }
    }
}
