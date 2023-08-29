using MediatR;
using PropertEase_DTO.Property;

namespace PropertEase_Commends.PropertyCommends.Commend;

public record PropertyPredictionCommend(PropertyFormDto formDto) : IRequest<int>;
public record AddPropertyCommend(PropertyFormDto formDto) : IRequest<PropertyFormDto>;
public record UpdatePropertyCommend(PropertyUpdateFormDto formDto) : IRequest<PropertyUpdateFormDto>;
public record RemovePropertyCommend(int id) : IRequest;
