using Xunit;
using Business.Services;

namespace Business.Test
{
    public class ContactServiceTests : IDisposable
    {
        private readonly string _testFilePath;

        public ContactServiceTests()
        {
            _testFilePath = Path.GetTempFileName();
        }

        [Fact]
        public void GetAllContacts_ShouldReturnEmptyList_WhenNoContactsAdded()
        {
            // Arr
            var jsonService = new JsonService(_testFilePath);
            var contactService = new ContactService(jsonService);

            // Act
            var result = contactService.GetAllContacts();

            // Ass
            Assert.Empty(result);
        }

        public void Dispose()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }
    }
}


