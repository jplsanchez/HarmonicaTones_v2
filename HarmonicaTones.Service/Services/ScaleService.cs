using HT.Domain.Entities.Enums;
using HT.Service.Interfaces;

namespace HT.Service.Services
{
    public class ScaleService : IScalesService
    {
        public IEnumerable<string> GetListOfScales()
        {
            return Enum.GetNames(typeof(ScalesList)).ToList();
        }

        public IEnumerable<string> GetNotesFromScale(string scale)
        {
            var scaleType = ScaleTypeFromString(scale);
            if (scaleType != null)
            {
                List<string> list = new();
                foreach (var item in Enum.GetValues(scaleType))
                {
                    list.Add(item.ToString());
                }

                return list;
            }

            throw new ArgumentException($"{nameof(scale)} is not a valid Scale");
        }

        private static Type? ScaleTypeFromString(string scaleString)
        {
            var _scalesTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(t => t.GetTypes())
                .Where(t => t.IsEnum && t.Namespace == "HT.Domain.Entities.Enums.Scales")
                .ToList();

            var type = _scalesTypes.FirstOrDefault(s => s.Name.ToUpper() == scaleString.ToUpper());
            return type;
        }
    }
}