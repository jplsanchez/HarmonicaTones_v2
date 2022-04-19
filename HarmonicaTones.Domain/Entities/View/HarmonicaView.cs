#pragma warning disable CS8618

using HT.Domain.Entities.Model;
using System.ComponentModel.DataAnnotations;

namespace HT.Domain.Entities.View
{
    public class HarmonicaView
    {
        private const string NoteErrorMessage = "Please enter a valid note [C-D-E-F-G-A-B], optiional accidental [# or b] and number [integer]";
        private const string NoteFormat = @"[A-G][b|#]?[\d]"; //Ex: C#4, A5, Db6 ...

        [Required]
        [RegularExpression(NoteFormat, ErrorMessage = NoteErrorMessage)]
        public string Tone { get; init; }

        [Required]
        [RegularExpression(NoteFormat, ErrorMessage = NoteErrorMessage)]
        public List<string> BlowNotes { get; init; } = new();

        [Required]
        [RegularExpression(NoteFormat, ErrorMessage = NoteErrorMessage)]
        public List<string> DrawNotes { get; init; } = new();

        [RegularExpression(NoteFormat, ErrorMessage = NoteErrorMessage)]
        public List<string?> Bend1Notes { get; init; } = new();

        [RegularExpression(NoteFormat, ErrorMessage = NoteErrorMessage)]
        public List<string?> Bend2Notes { get; init; } = new();

        [RegularExpression(NoteFormat, ErrorMessage = NoteErrorMessage)]
        public List<string?> Bend3Notes { get; init; } = new();

        public HarmonicaView(Harmonica harmonica)
        {
            Tone = harmonica.Tone.ToString();

            foreach (var hole in harmonica.HarmonicaHoles)
            {
                BlowNotes.Add(hole.Blow.ToString());
                DrawNotes.Add(hole.Draw.ToString());

                bool hasOneBend = hole.Bend.Length > 0;
                Bend1Notes.Add(hasOneBend ? hole.Bend[0].ToString() : null);

                bool hasTwoBend = hole.Bend.Length > 1;
                Bend2Notes.Add(hasTwoBend ? hole.Bend[1].ToString() : null);

                bool hasThreeBend = hole.Bend.Length > 2;
                Bend3Notes.Add(hasThreeBend ? hole.Bend[2].ToString() : null);
            }
        }
    }
}