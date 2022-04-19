using HT.Domain.Entities.Enums.Scales;
using System.Text.RegularExpressions;

namespace HT.Domain.Entities
{
    public class Note
    {
        public Chromatic NoteAndAccidental { get; private set; }
        public short Pitch { get; private set; }

        public Note(Chromatic note, short pitch)
        {
            NoteAndAccidental = note;
            Pitch = pitch;
        }

        public void TransposeNote(short semitonShift)
        {
            var note = (short)NoteAndAccidental;
            var pitch = Pitch;

            note += semitonShift;
            while (note >= 12)
            {
                note -= 12;
                pitch++;
            }
            while (note < 0)
            {
                note += 12;
                pitch--;
            }

            NoteAndAccidental = (Chromatic)note;
            Pitch = pitch;
        }

        public static Note GetTransposedNote(Note noteObject, short semitonShift)
        {
            var note = (short)noteObject.NoteAndAccidental;
            var pitch = noteObject.Pitch;

            note += semitonShift;
            while (note >= 12)
            {
                note -= 12;
                pitch++;
            }
            while (note < 0)
            {
                note += 12;
                pitch--;
            }

            return new Note((Chromatic)note, pitch);
        }

        public static Note NoteFromNoteSharpPitchNotation(string noteWithPitch)
        {
            try
            {
                string noteString = Regex.Match(noteWithPitch, @"[A-G]+[s]?").Value;
                _ = Enum.TryParse(noteString, out Chromatic note);

                string pitchString = Regex.Match(noteWithPitch, @"\d+").Value;
                _ = Int16.TryParse(pitchString, out short pitch);

                return new Note(note, pitch);
            }
            catch (Exception)
            {
                throw new ArgumentException("String is not in format 'Cs4': C sharp(optional) 4");
            }
        }

        public static Note FromString(string noteWithPitch)
        {
            if (!Regex.IsMatch(noteWithPitch, @"[A-G]{1}[b|#]?[\d]+"))
                throw new ArgumentException("Invalid format: note [C-D-E-F-G-A-B], accidental [# or b optional] and pitch [Integer]");

            var noteString = Regex.Match(noteWithPitch, @"[A-G]").Value;
            _ = Enum.TryParse(noteString, out Chromatic note);

            short pitch = short.Parse(Regex.Match(noteWithPitch, @"[\d]+").Value);

            var outputNote = new Note(note, pitch);

            var accidentalString = Regex.Match(noteWithPitch, @"[b|#]").Value;
            if (accidentalString != string.Empty)
                outputNote.AddAccidental(accidentalString);

            return outputNote;
        }

        public override string ToString()
        {
            string output = NoteAndAccidental.ToString();

            output = Regex.Replace(output, "[s]", "#");

            output += Pitch.ToString();

            return output;
        }

        public void AddAccidental(string accidental)
        {
            if (!Regex.IsMatch(accidental, @"[b|#]"))
                throw new ArgumentException("Not an accidental [# or b]");

            var accidentalString = Regex.Match(accidental, @"[b|#]").Value;

            if (accidentalString.Equals("#")) TransposeNote(+1);
            if (accidentalString.Equals("b")) TransposeNote(-1);
        }

        public static short GetShift(Note source, Note target)
        {
            var pitchShift = (target.Pitch - source.Pitch) * 12;
            var notesShift = (int)target.NoteAndAccidental - (int)source.NoteAndAccidental;

            return (short)(notesShift + pitchShift);
        }
    }
}