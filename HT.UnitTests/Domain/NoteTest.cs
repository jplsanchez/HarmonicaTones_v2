using HT.Domain.Entities;
using HT.Domain.Entities.Enums.Scales;
using Xunit;

namespace HT.UnitTests.Domain
{
    public class NoteTest
    {
        private readonly Note _systemUnderTest;

        public NoteTest()
        {
            _systemUnderTest = new Note(Chromatic.C, 4);
        }

        [Fact]
        public void FromString_HappyPath()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}