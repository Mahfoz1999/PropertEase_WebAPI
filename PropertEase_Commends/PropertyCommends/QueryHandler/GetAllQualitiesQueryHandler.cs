using MediatR;
using Microsoft.EntityFrameworkCore;
using PropertEase_Commends.PropertyCommends.Query;
using PropertEase_Database.SQLConnection;

namespace PropertEase_Commends.PropertyCommends.QueryHandler;

public class GetAllQualitiesQueryHandler : IRequestHandler<GetAllQualitiesQuery, List<string>>
{
    private readonly PropertEaseDbContext Context;
    public GetAllQualitiesQueryHandler(PropertEaseDbContext Context)
    {
        this.Context = Context;
    }
    public async Task<List<string>> Handle(GetAllQualitiesQuery request, CancellationToken cancellationToken)
    {
        List<string> result = await Context.Properties.Select(x => x.Quality).Distinct().ToListAsync();
        return result;
    }
}
