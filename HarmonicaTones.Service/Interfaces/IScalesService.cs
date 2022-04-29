namespace HT.Service.Interfaces
{
    public interface IScalesService
    {
        public IEnumerable<string> GetListOfScales();

        public IEnumerable<string> GetNotesFromScale(string scale);
    }
}