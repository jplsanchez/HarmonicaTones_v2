using HT.Service.Services;
using System.Collections.Generic;
using Xunit;

namespace HT.Tests.Service
{
    public class ScaleServiceTest
    {
        private readonly ScaleService _service = new();

        [Fact]
        public void GetListOfScales_ValidValue()
        {
            var expectedList = new List<string> {
                "Major",
                "MajorBlues",
                "MajorPentatonic",
                "MinorNatural",
                "MinorHarmonic",
                "MinorMelodic",
                "MinorBlues",
                "MinorPentatonic",
                "WholeTone",
                "DiminishedHalfWhole",
                "DiminishedWholeHalf",
                "Chromatic"
            };

            var outputList = _service.GetListOfScales();

            Assert.Equal(expectedList, outputList);
        }

        [Fact]
        public void GetListOfScales_InvalidValue()
        {
            var expectedList = new List<string> {
                "Major",
            };

            var outputList = _service.GetListOfScales();

            Assert.NotEqual(expectedList, outputList);
        }
    }
}