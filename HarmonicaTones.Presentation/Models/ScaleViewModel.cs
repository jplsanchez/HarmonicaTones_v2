using System.ComponentModel.DataAnnotations;

namespace HT.Presentation.Models
{
    public class ScaleViewModel
    {
        [RegularExpression(@"[A-G][b|#]?", ErrorMessage = "Must be a note")]
        public string Tone { get; set; } = "C";

        public int Pitch { get; set; } = 4;

        public string Scale { get; set; } = "Major";

        public ScaleViewModel(string tone, int pitch = 4, string scale = "")
        {
            Tone = tone;
            Pitch = pitch;
            Scale = scale;
        }
        public ScaleViewModel()
        {

        }
    }
}