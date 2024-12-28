namespace ContactApp.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }

        public Contact()
        {
            Id = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $@"
Id: {Id}, 
FirstName: {FirstName}
LastName: {LastName}
Email: {Email}
Phone: {PhoneNumber}
Address: {Address}, {PostalCode}, {City}";
        }
    }
}
