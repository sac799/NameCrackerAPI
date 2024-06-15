using NameCrackerAPI.Services;

namespace StringParcerServiceTests
{
    [TestFixture]
    public class StringParcerServiceTests
    {
        private StringParserService _stringParserService;

        [SetUp]
        public void Setup()
        {
            _stringParserService = new StringParserService();
        }

        [Test]
        public void ParseFullString_ValidInput_ShouldReturnParsedName()
        {
            // Arrange
            string fullName = "Mr Sachin Patil";

            // Act
            var parsedName = _stringParserService.ParseFullString(fullName);

            // Assert
            Assert.AreEqual("Mr", parsedName.Title);
            Assert.AreEqual("Sachin", parsedName.Forename);
            Assert.IsNull(parsedName.MiddleName);
            Assert.AreEqual("Patil", parsedName.Surname);
        }

        [Test]
        public void ParseFullString_InputWithMiddleName_ShouldReturnParsedName()
        {
            // Arrange
            string fullName = "Mr Sachin James Patil";

            // Act
            var parsedName = _stringParserService.ParseFullString(fullName);

            // Assert
            Assert.AreEqual("Mr", parsedName.Title);
            Assert.AreEqual("Sachin", parsedName.Forename);
            Assert.AreEqual("James", parsedName.MiddleName);
            Assert.AreEqual("Patil", parsedName.Surname);
        }

        [Test]
        public void ParseFullString_InputWithoutTitle_ShouldReturnParsedName()
        {
            // Arrange
            string fullName = "Sachin Patil";

            // Act
            var parsedName = _stringParserService.ParseFullString(fullName);

            // Assert
            Assert.IsNull(parsedName.Title);
            Assert.AreEqual("Sachin", parsedName.Forename);
            Assert.IsNull(parsedName.MiddleName);
            Assert.AreEqual("Patil", parsedName.Surname);
        }

        [Test]
        public void ParseFullString_InputWithMultipleMiddleNames_ShouldReturnParsedName()
        {
            // Arrange
            string fullName = "Mr John Michael Scott Doe";

            // Act
            var parsedName = _stringParserService.ParseFullString(fullName);

            // Assert
            Assert.AreEqual("Mr", parsedName.Title);
            Assert.AreEqual("John", parsedName.Forename);
            Assert.AreEqual("Michael Scott", parsedName.MiddleName);
            Assert.AreEqual("Doe", parsedName.Surname);
        }
        [Test]
        public void ParseFullString_InputWithoutTitleAndWithMultipleMiddleNames_ShouldReturnParsedName()
        {
            // Arrange
            string fullName = "John Michael Scott Doe";

            // Act
            var parsedName = _stringParserService.ParseFullString(fullName);

            // Assert
            Assert.IsNull(parsedName.Title);
            Assert.AreEqual("John", parsedName.Forename);
            Assert.AreEqual("Michael Scott", parsedName.MiddleName);
            Assert.AreEqual("Doe", parsedName.Surname);
        }

        [Test]
        public void ParseFullString_EmptyFullName_ShouldThrowException()
        {
            // Arrange
            string fullName = "";

            // Act and Assert
            Assert.Throws<ArgumentException>(() => _stringParserService.ParseFullString(fullName));
        }

        [Test]
        public void ParseFullString_NullFullName_ShouldThrowException()
        {
            // Arrange
            string fullName = null;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => _stringParserService.ParseFullString(fullName));
        }

        [Test]
        public void ParseFullString_OnlyOneName_ShouldThrowException()
        {
            // Arrange
            string fullName = "John";

            // Act and Assert
            Assert.Throws<ArgumentException>(() => _stringParserService.ParseFullString(fullName));
        }
    }
}
