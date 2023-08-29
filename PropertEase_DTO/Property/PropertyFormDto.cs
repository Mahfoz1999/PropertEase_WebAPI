namespace PropertEase_DTO.Property;

public record PropertyFormDto
{
    public required string Area { get; set; }
    public required string Quality { get; set; }
    public required double Latitude { get; set; }
    public required double Longitude { get; set; }
    public required int SizeInSqft { get; set; }
    public required double PricePerSqft { get; set; }
    public required int NoOfBedrooms { get; set; }
    public required int NoOfBathrooms { get; set; }
    public required bool MaidRoom { get; set; }
    public required bool UnFurnished { get; set; }
    public required bool Balcony { get; set; }
    public required bool BarbecueArea { get; set; }
    public required bool BuiltInWardrobes { get; set; }
    public required bool CentralAc { get; set; }
    public required bool ChildrensPlayArea { get; set; }
    public required bool ChildrensPool { get; set; }
    public required bool Concierge { get; set; }
    public required bool CoveredParking { get; set; }
    public required bool KitchenAppliances { get; set; }
    public required bool LobbyInBuilding { get; set; }
    public required bool MaidService { get; set; }
    public required bool Networked { get; set; }
    public required bool PetsAllowed { get; set; }
    public required bool PrivateGarden { get; set; }
    public required bool PrivateGym { get; set; }
    public required bool PrivateJacuzzi { get; set; }
    public required bool PrivatePool { get; set; }
    public required bool Security { get; set; }
    public required bool SharedGym { get; set; }
    public required bool Study { get; set; }
    public required bool SharedPool { get; set; }
    public required bool SharedSpa { get; set; }
    public required bool VastuCompliant { get; set; }
    public required bool ViewOfLandmark { get; set; }
    public required bool ViewOfWater { get; set; }
    public required bool WalkInCloset { get; set; }
}
