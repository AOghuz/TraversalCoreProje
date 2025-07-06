using DataAccessLayer.Concrete;
using TraversalCoreProje.CQRS.Queries.DestinationQueries;
using TraversalCoreProje.CQRS.Results.DestinationResults;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;
        public GetDestinationByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIDQueryResult Handle(GetDestinationByIDQuery query)
        {
            var value = _context.Destinations.Find(query.Id);
            return new GetDestinationByIDQueryResult
            {
                DestinationId = value.DestinationId,
                City = value.City,
                DayNight = value.DayNight,
                Price = value.Price != null ? Convert.ToInt32(value.Price) : 0

            };
        }
    }
}
