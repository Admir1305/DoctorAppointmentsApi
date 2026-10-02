namespace DoctorAppointmentApi.Models
{
    public class Appointments
    {
        public int Id { get; set; }

        public int DoctorId{  get; set; }

        public int PatientId {  get; set; }
        public DateTime AppointmentTime {  get; set; }

        public string Status_name { get; set; }
        public int? Status_id { get; set; }

        public string Notes { get; set; }

    }
}
