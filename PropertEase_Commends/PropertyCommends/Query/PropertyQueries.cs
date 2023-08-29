using MediatR;

namespace PropertEase_Commends.PropertyCommends.Query;

public record GetAllAreasQuery() : IRequest<List<string>>;
public record GetAllQualitiesQuery() : IRequest<List<string>>;
