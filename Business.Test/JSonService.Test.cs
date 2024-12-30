using Xunit;
using Business.Services;

namespace Business.Test
{
    public class JSonServiceTests : IDisposable
    {
        private readonly string _testFilePath;

        public JSonServiceTests()
        {
            _testFilePath = Path.GetTempFileName();
        }

        [Fact]
        public void LoadData_ShouldReturnEmptyList_WhenFileIsEmpty()
        {
            // Arr
            var jsonService = new JsonService(_testFilePath);

            // Act
            var result = jsonService.LoadData<string>();

            // Ass
            Assert.Empty(result);
        }

        [Fact]
        public void SaveData_ShouldWriteDataToFile()
        {
            // Arr
            var jsonService = new JsonService(_testFilePath);
            var data = new List<string> { "Test1", "Test2" };

            // Act 
            jsonService.SaveData(data);

            // Ass
            var result = jsonService.LoadData<string>();
            Assert.Equal(2, result.Count);
            Assert.Contains("Test1", result);
            Assert.Contains("Test2", result);
        }

        public void Dispose() // Kod generad av chat GPT
        {
            // Detta tar bort testfilerna efter testet.
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }
    }
}
