namespace HT.Domain.Entities.Enums
{
    public enum ScalesList
    {
        Major,
        MajorBlues,
        MajorPentatonic,
        MinorNatural,
        MinorHarmonic,
        MinorMelodic,
        MinorBlues,
        MinorPentatonic,
        WholeTone,
        DiminishedHalfWhole,
        DiminishedWholeHalf,
        Chromatic
    }

    public class ScalesHelper
    {
        public readonly List<Type> _scalesTypes;

        public ScalesHelper()
        {
        }


    }
}