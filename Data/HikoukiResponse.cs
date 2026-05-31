using HikoukiApi.Dtos;
using HikoukiApi.Models;

namespace HikoukiApi.Data
{
    public static class HikoukiResponse
    {
        public static AircraftResponse ToResponse(Aircraft aircraft)
        {
            AircraftResponse response = new()
            {
                Id = aircraft.Id,
                Registration = aircraft.Registration,
                TypeCode = aircraft.TypeCode == null ? null : ToResponse(aircraft.TypeCode),
                TypeCodeVariant = aircraft.TypeCodeVariant == null ? null : ToResponse(aircraft.TypeCodeVariant),
                SerialNumber = aircraft.SerialNumber,
                LineNumber = aircraft.LineNumber,
                Airline = aircraft.Airline == null ? null : ToResponse(aircraft.Airline),
                AlternateOperatorName = aircraft.AlternateOperatorName,
                IsGovOrMilitary = aircraft.IsGovOrMilitary,
                IsSpecialLivery = aircraft.IsSpecialLivery,
                SpecialLiveryName = aircraft.SpecialLiveryName,
                Remarks = aircraft.Remarks
            };

            return response;
        }

        public static AircraftSpotResponse ToResponse(AircraftSpot spot)
        {
            return new AircraftSpotResponse
            {
                Id = spot.Id,
                Date = spot.Date,
                Aircraft = spot.Aircraft == null ? null : ToResponse(spot.Aircraft),
                TypeCodeVariant = spot.TypeCodeVariant == null ? null : ToResponse(spot.TypeCodeVariant),
                Airline = spot.Airline == null ? null : ToResponse(spot.Airline),
                Airport = spot.Airport == null ? null : ToResponse(spot.Airport),
                AirportLocation = spot.AirportLocation,
                Camera = spot.Camera,
                Lens = spot.Lens,
                Remarks = spot.Remarks
            };
        }

        public static AircraftTypeCodeResponse ToResponse(AircraftTypeCode typeCode)
        {
            return new AircraftTypeCodeResponse
            {
                Id = typeCode.Id,
                Icao = typeCode.Icao,
                Manufacturer = typeCode.Manufacturer
            };
        }

        public static AirlineResponse ToResponse(Airline airline)
        {
            return new AirlineResponse
            {
                Id = airline.Id,
                Iata = airline.Iata,
                Icao = airline.Icao,
                Name = airline.Name,
                Country = airline.Country,
                IsActive = airline.IsActive
            };
        }

        public static AirportResponse ToResponse(Airport airport)
        {
            return new AirportResponse
            {
                Id = airport.Id,
                Iata = airport.Iata,
                Icao = airport.Icao,
                Name = airport.Name,
                AlternateName = airport.AlternateName,
                Country = airport.Country
            };
        }

        public static TypeCodeVariantResponse ToResponse(TypeCodeVariant variant)
        {
            return new TypeCodeVariantResponse
            {
                Id = variant.Id,
                VariantName = variant.VariantName
            };
        }
    }
}
