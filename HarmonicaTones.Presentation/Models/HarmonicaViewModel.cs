#pragma warning disable CS8618

using System.ComponentModel.DataAnnotations;

namespace HT.Presentation.Models
{
    public class HarmonicaViewModel
    {
        private const string NoteErrorMessage = "Please enter a valid note [C-D-E-F-G-A-B], optiional accidental [# or b] and optional number [integer]";
        private const string NoteFormat = @"[A-G][b|#]?[\d]?"; //Ex: C#4, A5, Db6 ...

        [Required]
        [RegularExpression(NoteFormat, ErrorMessage = NoteErrorMessage)]
        public string Tone { get; set; }

        [Required]
        [RegularExpression(NoteFormat, ErrorMessage = NoteErrorMessage)]
        public List<(string, bool)> BlowNotes { get; set; }

        [Required]
        [RegularExpression(NoteFormat, ErrorMessage = NoteErrorMessage)]
        public List<(string, bool)> DrawNotes { get; set; }

        [RegularExpression(NoteFormat, ErrorMessage = NoteErrorMessage)]
        public List<(string, bool)> Bend1Notes { get; set; }

        [RegularExpression(NoteFormat, ErrorMessage = NoteErrorMessage)]
        public List<(string, bool)> Bend2Notes { get; set; }

        [RegularExpression(NoteFormat, ErrorMessage = NoteErrorMessage)]
        public List<(string, bool)> Bend3Notes { get; set; }
    }
}