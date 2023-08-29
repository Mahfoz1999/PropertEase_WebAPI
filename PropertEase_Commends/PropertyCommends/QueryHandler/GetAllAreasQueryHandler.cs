using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertEase_Commends.PropertyCommends.Query;
using PropertEase_Database.SQLConnection;

namespace PropertEase_Commends.PropertyCommends.QueryHandler;

public class GetAllAreasQueryHandler : IRequestHandler<GetAllAreasQuery, List<string>>
{
    private readonly PropertEaseDbContext Context;
    public GetAllAreasQueryHandler(PropertEaseDbContext Context)
    {
        this.Context = Context;
    }
    public async Task<List<string>> Handle(GetAllAreasQuery request, CancellationToken cancellationToken)
    {
        List<string> result = await Context.Properties.Select(x => x.Area).Distinct().ToListAsync();
        return result;
    }
}
