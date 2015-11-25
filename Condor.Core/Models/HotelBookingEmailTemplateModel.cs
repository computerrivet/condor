namespace TheDrillBookCloud.Lib.Email.Models
{
    public class HotelBookingEmailTemplateModel
    {
        public string FullName { get; set; }
        public string EventName { get; set; }
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        public string DateOfBooking { get; set; }
        public string HotelName { get; set; }
        public string HotelAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string BookingAgent { get; set; }
        public string SavedUnder { get; set; }
        public string AdditionalInfo { get; set; }
    }
}