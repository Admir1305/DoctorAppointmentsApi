namespace DoctorAppointmentApi.Models
{
    public class Doctors
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName {  get; set; } = string.Empty;

        public int? SpecialtyId { get; set; }

        public string Phone { get; set; }

        public bool IsActive {  get; set; }

        public string IsActiveTemp => IsActive ? "Да" : "Не";
    }
}
