using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using TraversalCoreProje.CQRS.Queries.DestinationQueries;
using TraversalCoreProje.CQRS.Results.DestinationResults;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }
      public  List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                Id = x.DestinationId,
                Capacity = x.Capacity != null ? Convert.ToInt32(x.Capacity) : 0, // Null ise varsayılan değer
                City = x.City,
                Daynight = x.DayNight,
                Price = x.Price != null ? Convert.ToInt32(x.Price) : 0
            }).AsNoTracking().ToList();
            return values;
        }
    }
}
