using DataAccessLayer.Concrete;
using TraversalCoreProje.CQRS.Commands.DestinationCommands;

namespace TraversalCoreProje.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand commandHandler)
        {
            var value = _context.Destinations.Find(commandHandler.Id);
            value.City = commandHandler.City;
            value.DayNight = commandHandler.DayNight;
            value.Price = commandHandler.Price;
            value.Capacity = commandHandler.Capacity;

            _context.SaveChanges();
        }
    }
}
