namespace HT.Domain.Entities.Model
{
    public class HarmonicaHole
    {
        public Note Blow { get; private set; }
        public Note Draw { get; private set; }
        public Note[] Bend { get; private set; }

        private readonly byte _numberOfBends;

        public HarmonicaHole(Note blowNote, Note drawNote, byte numberOfBends)
        {
            Blow = blowNote;
            Draw = drawNote;
            _numberOfBends = numberOfBends;

            Bend = new Note[numberOfBends];
            SetDrawBendsNotes();
        }

        private void SetDrawBendsNotes()
        {
            if (Draw == null) throw new ArgumentNullException(nameof(Draw));

            var baseNote = Draw;
            for (var i = 0; i < _numberOfBends; i++)
            {
                Bend[i] = Note.GetTransposedNote(baseNote, -1);
                baseNote = Bend[i];
            }
        }

        public void ShiftNotes(short semitonShift)
        {
            Blow.TransposeNote(semitonShift);
            Draw.TransposeNote(semitonShift);

            for (var i = 0; i < _numberOfBends; i++)
            {
                Bend[i].TransposeNote(semitonShift);
            }
        }
    }
}