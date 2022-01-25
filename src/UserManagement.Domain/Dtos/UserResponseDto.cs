namespace UserManagement.Domain.Dtos
{
    public class UserResponseDto
    {
        public int UserId { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string CityName { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
    }
}
