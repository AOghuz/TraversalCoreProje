using MediatR;
using TraversalCoreProje.CQRS.Queries.GuideQueries;
using TraversalCoreProje.CQRS.Results.GuideResults;
using DataAccessLayer.Concrete;


namespace TraversalCoreProje.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIDQueryHandler : IRequestHandler<GetGuideByIDQuery, GetGuideByIDQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIDQueryResult> Handle(GetGuideByIDQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Guides.FindAsync(request.Id);

            if (value == null)
            {
                throw new KeyNotFoundException($"Guide with ID {request.Id} was not found.");
            }

            return new GetGuideByIDQueryResult
            {
                Id = (int)value.Id!, // Artık null olmadığından emin olabilirsiniz
                Description = value.Description,
                Name = value.Name
            };
        }

    }
}