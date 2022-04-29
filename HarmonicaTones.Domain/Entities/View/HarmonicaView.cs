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
        public List<(string, bool)> BlowNotes { get; init; } = new();

        [Required]
        [RegularExpression(NoteFormat, ErrorMessage = NoteErrorMessage)]
        public List<(string, bool)> DrawNotes { get; init; } = new();

        [RegularExpression(NoteFormat, ErrorMessage = NoteErrorMessage)]
        public List<(string, bool)> Bend1Notes { get; init; } = new();

        [RegularExpression(NoteFormat, ErrorMessage = NoteErrorMessage)]
        public List<(string, bool)> Bend2Notes { get; init; } = new();

        [RegularExpression(NoteFormat, ErrorMessage = NoteErrorMessage)]
        public List<(string, bool)> Bend3Notes { get; init; } = new();

        public HarmonicaView(Harmonica harmonica)
        {
            Tone = harmonica.Tone.ToString();

            foreach (var hole in harmonica.HarmonicaHoles)
            {
                BlowNotes.Add((hole.Blow.ToString(), false));
                DrawNotes.Add((hole.Draw.ToString(), false));

                bool hasOneBend = hole.Bend.Length > 0;
                Bend1Notes.Add(hasOneBend ? (hole.Bend[0].ToString(), false) : ("", false));

                bool hasTwoBend = hole.Bend.Length > 1;
                Bend2Notes.Add(hasTwoBend ? (hole.Bend[1].ToString(), false) : ("", false));

                bool hasThreeBend = hole.Bend.Length > 2;
                Bend3Notes.Add(hasThreeBend ? (hole.Bend[2].ToString(), false) : ("", false));
            }
        }
    }
}