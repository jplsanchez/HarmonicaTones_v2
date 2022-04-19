using HT.Domain.Entities.View;

namespace HT.Service.Interfaces
{
    public interface IHarmonicaService
    {
        HarmonicaView GetAllHolesNotes();

        HarmonicaView GetAllHolesNotesOnly();

        void SetTone(string tone, int pitch = 4);
    }
}