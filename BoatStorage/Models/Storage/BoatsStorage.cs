namespace BoatStorage.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Boatstorage.Data;
    using BoatStorage.Data;
    using BoatStorage.Services;

    public class BoatsStorage
    {
        public List<FloatingCrafts> Boats { get; set; }

        public List<JournalEntryAboutCurrentState> CurrentParametersJournal { get; set; }

        public List<TechnicalInspection> TechnicalInspectionJournal { get; set; }

        public List<FloatingCrafts> GetAListOfBoatForRent()
        {
            var boatContext = from t in this.TechnicalInspectionJournal
                              join c in this.CurrentParametersJournal on t.Id
                              equals c.Id
                              join b in this.Boats on t.Id equals b.Id
                              select new BoatStrategyContext
                              {
                                  Id = t.Id,
                                  BoatStateParameters = t.BoatStateParameters,
                                  CurrentParameters = c.CurrentParameters,
                                  Strategy = BoatStrategyContext.ChooseStrategy(b),
                              };

            var boats = from b in this.Boats
                        join s in boatContext.Where(s => s.GetQualityStatus() == BoatStatus.Ok)
                        on b.Id equals s.Id
                        select new FloatingCrafts { Id = b.Id, Name = b.Name };
            return boats.ToList();
        }
    }
}