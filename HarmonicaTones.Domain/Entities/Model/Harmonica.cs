using HT.Domain.Entities.Enums.DiatonicHarmonica;
using HT.Domain.Utils;

namespace HT.Domain.Entities.Model
{
    public class Harmonica
    {
        public Note Tone { get; private set; }
        public byte NumberOfHoles { get; private set; }
        public HarmonicaHole[] HarmonicaHoles { get; private set; }

        public Harmonica(Note tone, byte numberOfHoles)
        {
            Tone = tone;
            NumberOfHoles = numberOfHoles;
            HarmonicaHoles = new HarmonicaHole[numberOfHoles];

            LoadHarmonica();
            SetTone();
        }

        private void LoadHarmonica()
        {
            for (int i = 0; i < NumberOfHoles; i++)
            {
                var blowNote = GetNoteFromEnum<BlowHoles>(i);
                var drawNote = GetNoteFromEnum<DrawHoles>(i);

                var numberOfBends = GetNumberOfBendsFromHole(i);

                HarmonicaHoles[i] = new HarmonicaHole(blowNote, drawNote, numberOfBends);
            }
        }

        private static Note GetNoteFromEnum<T>(int hole) where T : Enum
        {
            T enumValue = EnumUtils.IntToEnum<T>(hole);
            string stringValue = enumValue.ToString();

            return Note.NoteFromNoteSharpPitchNotation(stringValue);
        }

        private byte GetNumberOfBendsFromHole(int hole)
        {
            string enumMember = "H" + (hole + 1).ToString();

            var valid = Enum.TryParse(enumMember, out HoleHasDrawBend numberOfBends);
            if (!valid) throw new Exception($"Not posible to find value at Enum {nameof(HoleHasDrawBend)}");

            return (byte)numberOfBends;
        }

        private void SetTone()
        {
            var shift = Note.GetShift(HarmonicaHoles[0].Blow, Tone);

            for (int i = 0; i < NumberOfHoles; i++)
            {
                HarmonicaHoles[i].ShiftNotes(shift);
            }
        }

        public void ChangeTone(Note newTone)
        {
            var shift = Note.GetShift(Tone, newTone);

            for (int i = 0; i < NumberOfHoles; i++)
            {
                HarmonicaHoles[i].ShiftNotes(shift);
            }

            Tone = newTone;
        }
    }
}