namespace SmprWebAPI.Server.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public bool Status { get; set; }
    }
}