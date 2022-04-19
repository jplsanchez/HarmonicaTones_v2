using HT.Domain.Entities;
using HT.Domain.Entities.Enums.Scales;
using System;
using Xunit;

namespace HT.Tests.Domain
{
    public class NoteTest
    {
        #region FromString

        [Fact]
        public void FromString_ValidSharpNoteString()
        {
            //Arrange
            var inputData = "C#4";
            var expectedResult = new Note(Chromatic.Cs, 4);

            //Act
            Note resultObject = Note.FromString(inputData);

            //Assert
            Assert.Equal(expectedResult.NoteAndAccidental, resultObject.NoteAndAccidental);
            Assert.Equal(expectedResult.Pitch, resultObject.Pitch);
        }

        [Fact]
        public void FromString_ValidFlatNoteString()
        {
            //Arrange
            var inputData = "Db4";
            var expectedResult = new Note(Chromatic.Cs, 4);

            //Act
            Note resultObject = Note.FromString(inputData);

            //Assert
            Assert.Equal(expectedResult.NoteAndAccidental, resultObject.NoteAndAccidental);
            Assert.Equal(expectedResult.Pitch, resultObject.Pitch);
        }

        [Fact]
        public void FromString_ValidPureNoteString()
        {
            //Arrange
            var inputData = "C4";
            var expectedResult = new Note(Chromatic.C, 4);

            //Act
            Note resultObject = Note.FromString(inputData);

            //Assert
            Assert.Equal(expectedResult.NoteAndAccidental, resultObject.NoteAndAccidental);
            Assert.Equal(expectedResult.Pitch, resultObject.Pitch);
        }

        [Fact]
        public void FromString_InvalidNote()
        {
            //Arrange
            var inputData = "H4";
            var expectedResult = new Note(Chromatic.C, 4);

            //Act
            var act = () => Note.FromString(inputData);

            //Assert
            var ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Invalid format: note [C-D-E-F-G-A-B], accidental [# or b optional] and pitch [Integer]", ex.Message);
        }

        [Fact]
        public void FromString_WithoutPitch()
        {
            //Arrange
            var inputData = "C#";
            var expectedResult = new Note(Chromatic.C, 4);

            //Act
            var act = () => Note.FromString(inputData);

            //Assert
            var ex = Assert.Throws<ArgumentException>(act);
            Assert.Equal("Invalid format: note [C-D-E-F-G-A-B], accidental [# or b optional] and pitch [Integer]", ex.Message);
        }

        #endregion FromString

        #region ToString

        public void ToString_ValidSharpNote()
        {
            //Arrange
            var inputData = new Note(Chromatic.Cs, 4);
            var expectedResult = "C#4";

            //Act
            string resultObject = inputData.ToString();

            //Assert
            Assert.Equal(expectedResult, resultObject);
        }

        [Fact]
        public void ToString_ValidPureNoteString()
        {
            //Arrange
            var inputData = new Note(Chromatic.C, 4);
            var expectedResult = "C4";

            //Act
            string resultObject = inputData.ToString();

            //Assert
            Assert.Equal(expectedResult, resultObject);
        }

        #endregion ToString
    }
}