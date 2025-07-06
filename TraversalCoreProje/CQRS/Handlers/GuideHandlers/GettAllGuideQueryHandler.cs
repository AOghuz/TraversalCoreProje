using DataAccessLayer.Concrete;
using MediatR;
using TraversalCoreProje.CQRS.Queries.GuideQueries;
using TraversalCoreProje.CQRS.Results.GuideResults;
using Microsoft.EntityFrameworkCore;

namespace TraversalCoreProje.CQRS.Handlers.GuideHandlers
{
    public class GettAllGuideQueryHandler:IRequestHandler<GetAllGuideQuery,List<GetAllGuideQueryResult>>
    {
        private readonly Context _context;
        public GettAllGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult
            {
                Id = (int)x.Id!, // Eğer dönüştürme mümkünse.

                Description = x.Description,
                Image = x.Image,
                Name = x.Name
            }).AsNoTracking().ToListAsync();

        }
    }
}
