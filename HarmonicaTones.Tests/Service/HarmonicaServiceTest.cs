using HT.Service.Services;
using Xunit;

namespace HT.Tests.Service
{
    public class HarmonicaServiceTest
    {
        [Fact]
        public void GetAllHolesNotes_ValidView()
        {
            //Arrange
            var harmonicaService = new HarmonicaService();
            var numberOfHoles = 10;
            var tone = "C4";

            //Act
            var outputView = harmonicaService.GetAllHolesNotes();

            //Assert
            Assert.NotNull(outputView);
            Assert.Equal(tone, outputView.Tone);
            Assert.Equal(tone, outputView.BlowNotes[0]);

            Assert.Equal(numberOfHoles, outputView.BlowNotes.Count);
            Assert.Equal(numberOfHoles, outputView.DrawNotes.Count);
            Assert.Equal(numberOfHoles, outputView.Bend1Notes.Count);
            Assert.Equal(numberOfHoles, outputView.Bend2Notes.Count);
            Assert.Equal(numberOfHoles, outputView.Bend3Notes.Count);
        }
    }
}