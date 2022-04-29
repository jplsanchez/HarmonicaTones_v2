using HT.Domain.Entities;
using HT.Domain.Entities.Enums.Scales;
using HT.Domain.Entities.Model;
using HT.Domain.Entities.View;
using HT.Service.Interfaces;

namespace HT.Service.Services
{
    public class HarmonicaService : IHarmonicaService
    {
        private const byte HarmonicaHoles = 10;

        public Harmonica _harmonica;

        public HarmonicaService()
        {
            var harmonicaInitialTune = new Note(Chromatic.C, 4);

            _harmonica = new Harmonica(harmonicaInitialTune, HarmonicaHoles);
        }

        public HarmonicaView GetAllHolesNotes()
        {
            return new HarmonicaView(_harmonica);
        }

        public HarmonicaView GetAllHolesNotesOnly()
        {
            var view = new HarmonicaView(_harmonica);

            for (int i = 0; i < view.BlowNotes.Count; i++)
            {
                view.BlowNotes[i] = (view.BlowNotes[i].Item1[..^1], false);
                view.DrawNotes[i] = (view.DrawNotes[i].Item1[..^1], false);
                if (view.Bend1Notes[i].Item1 != "")
                    view.Bend1Notes[i] = (view.Bend1Notes[i].Item1[..^1], false);
                if (view.Bend2Notes[i].Item1 != "")
                    view.Bend2Notes[i] = (view.Bend2Notes[i].Item1[..^1], false);
                if (view.Bend3Notes[i].Item1 != "")
                    view.Bend3Notes[i] = (view.Bend3Notes[i].Item1[..^1], false);
            }
            return view;
        }

        public HarmonicaView GetNotesAndScale()
        {
            var view = new HarmonicaView(_harmonica);

            for (int i = 0; i < view.BlowNotes.Count; i++)
            {
                view.BlowNotes[i] = (view.BlowNotes[i].Item1[..^1], false);
                view.DrawNotes[i] = (view.DrawNotes[i].Item1[..^1], false);
                if (view.Bend1Notes[i].Item1 != "")
                    view.Bend1Notes[i] = (view.Bend1Notes[i].Item1[..^1], false);
                if (view.Bend2Notes[i].Item1 != "")
                    view.Bend2Notes[i] = (view.Bend2Notes[i].Item1[..^1], false);
                if (view.Bend3Notes[i].Item1 != "")
                    view.Bend3Notes[i] = (view.Bend3Notes[i].Item1[..^1], false);
            }
            return view;
        }

        public void SetTone(string tone, int pitch = 4)
        {
            var note = Note.FromString(tone + pitch.ToString());

            _harmonica.ChangeTone(note);
        }
    }
}