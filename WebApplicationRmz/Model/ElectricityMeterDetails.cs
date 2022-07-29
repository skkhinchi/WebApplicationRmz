using System;

namespace WebApplicationRmz.Model
{
    public class ElectricityMeterDetails
    {
        public Guid MeterId { get; set; }

        public string MeterReading { get; set; }

        public string ZoneName{ get; set; }

        public string BuildingName { get; set; }

        public string FacilityName { get; set; }

    }
}
