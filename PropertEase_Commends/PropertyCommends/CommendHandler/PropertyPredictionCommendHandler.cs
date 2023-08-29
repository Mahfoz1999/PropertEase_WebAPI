using MediatR;
using PropertEase_Commends.PropertyCommends.Commend;

namespace PropertEase_Commends.PropertyCommends.CommendHandler;

public class PropertyPredictionCommendHandler : IRequestHandler<PropertyPredictionCommend, int>
{
    public async Task<int> Handle(PropertyPredictionCommend request, CancellationToken cancellationToken)
    {
        try
        {
            var sampleData = new PropertyValuePrediction.ModelInput()
            {
                Area = request.formDto.Area,
                Quality = request.formDto.Quality,
                Latitude = (float)request.formDto.Latitude,
                Longitude = (float)request.formDto.Longitude,
                SizeInSqft = request.formDto.SizeInSqft,
                PricePerSqft = (float)request.formDto.PricePerSqft,
                NoOfBedrooms = request.formDto.NoOfBedrooms,
                NoOfBathrooms = request.formDto.NoOfBathrooms,
                MaidRoom = request.formDto.MaidRoom,
                UnFurnished = request.formDto.UnFurnished,
                Balcony = request.formDto.Balcony,
                BarbecueArea = request.formDto.BarbecueArea,
                BuiltInWardrobes = request.formDto.BuiltInWardrobes,
                CentralAc = request.formDto.CentralAc,
                ChildrensPlayArea = request.formDto.ChildrensPlayArea,
                ChildrensPool = request.formDto.ChildrensPool,
                Concierge = request.formDto.Concierge,
                CoveredParking = request.formDto.CoveredParking,
                KitchenAppliances = request.formDto.KitchenAppliances,
                LobbyInBuilding = request.formDto.LobbyInBuilding,
                MaidService = request.formDto.MaidService,
                Networked = request.formDto.Networked,
                PetsAllowed = request.formDto.PetsAllowed,
                PrivateGarden = request.formDto.PrivateGarden,
                PrivateGym = request.formDto.PrivateGym,
                PrivateJacuzzi = request.formDto.PrivateJacuzzi,
                PrivatePool = request.formDto.PrivatePool,
                Security = request.formDto.Security,
                SharedGym = request.formDto.SharedGym,
                Study = request.formDto.Study,
                SharedPool = request.formDto.SharedPool,
                SharedSpa = request.formDto.SharedSpa,
                VastuCompliant = request.formDto.VastuCompliant,
                ViewOfLandmark = request.formDto.ViewOfLandmark,
                ViewOfWater = request.formDto.ViewOfWater,
                WalkInCloset = request.formDto.WalkInCloset,
            };
            int result = Convert.ToInt32(PropertyValuePrediction.Predict(sampleData).Score);
            return result;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
