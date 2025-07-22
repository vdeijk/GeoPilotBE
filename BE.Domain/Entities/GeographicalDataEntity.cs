namespace BE.Domain.Entities
{
    /// <summary>
    /// Entity model for geographical data representing Dutch address and building information.
    /// </summary>
    public class GeographicalDataEntity
    {
        public int Id { get; set; }

        /// <summary>Street name or public space.</summary>
        public string Openbareruimte { get; set; } = string.Empty;

        public int Huisnummer { get; set; }

        /// <summary>House letter (e.g., 'A' in '123A').</summary>
        public string? Huisletter { get; set; }

        /// <summary>House number addition (e.g., 1 in '123-1').</summary>
        public int? Huisnummertoevoeging { get; set; }

        public string Postcode { get; set; } = string.Empty;
        public string Woonplaats { get; set; } = string.Empty;
        public string Gemeente { get; set; } = string.Empty;
        public string Provincie { get; set; } = string.Empty;

        /// <summary>BAG address indication number (Dutch address registry identifier).</summary>
        public string Nummeraanduiding { get; set; } = string.Empty;

        /// <summary>Usage purpose (e.g., residential, commercial, mixed-use).</summary>
        public string Verblijfsobjectgebruiksdoel { get; set; } = string.Empty;

        /// <summary>Surface area in square meters.</summary>
        public int Oppervlakteverblijfsobject { get; set; }

        /// <summary>Status of the residence (e.g., active, inactive, planned).</summary>
        public string Verblijfsobjectstatus { get; set; } = string.Empty;

        /// <summary>BAG object identifier.</summary>
        public string ObjectId { get; set; } = string.Empty;

        /// <summary>BAG object type (e.g., Pand, Verblijfsobject).</summary>
        public string ObjectType { get; set; } = string.Empty;

        /// <summary>Secondary address (optional).</summary>
        public string? Nevenadres { get; set; }

        /// <summary>BAG building identifier.</summary>
        public string Pandid { get; set; } = string.Empty;

        /// <summary>Building status (e.g., existing, under construction, demolished).</summary>
        public string Pandstatus { get; set; } = string.Empty;

        public int Pandbouwjaar { get; set; }

        /// <summary>X coordinate (RD New coordinate system).</summary>
        public int X { get; set; }

        /// <summary>Y coordinate (RD New coordinate system).</summary>
        public int Y { get; set; }

        /// <summary>Longitude (WGS84 decimal degrees).</summary>
        public double Lon { get; set; }

        /// <summary>Latitude (WGS84 decimal degrees).</summary>
        public double Lat { get; set; }
    }
}
