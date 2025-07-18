using System.Text.Json.Serialization;

/// <summary>
/// Represents the root structure of the USGS earthquake GeoJSON data.
/// This follows the GeoJSON FeatureCollection format.
/// </summary>
public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    
    /// <summary>
    /// The type of GeoJSON object (should be "FeatureCollection")
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    /// <summary>
    /// Metadata about the earthquake data
    /// </summary>
    [JsonPropertyName("metadata")]
    public Metadata Metadata { get; set; }
    
    /// <summary>
    /// Array of earthquake features
    /// </summary>
    [JsonPropertyName("features")]
    public Feature[] Features { get; set; }
    
    /// <summary>
    /// Additional properties that might be present
    /// </summary>
    [JsonPropertyName("bbox")]
    public double[] BoundingBox { get; set; }
}

/// <summary>
/// Represents metadata about the earthquake dataset
/// </summary>
public class Metadata
{
    /// <summary>
    /// When the data was generated
    /// </summary>
    [JsonPropertyName("generated")]
    public long Generated { get; set; }
    
    /// <summary>
    /// URL to the API endpoint
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
    
    /// <summary>
    /// Title of the dataset
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }
    
    /// <summary>
    /// HTTP status code
    /// </summary>
    [JsonPropertyName("status")]
    public int Status { get; set; }
    
    /// <summary>
    /// API information
    /// </summary>
    [JsonPropertyName("api")]
    public string Api { get; set; }
    
    /// <summary>
    /// Number of earthquakes in the dataset
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }
}

/// <summary>
/// Represents a single earthquake feature in the GeoJSON format
/// </summary>
public class Feature
{
    /// <summary>
    /// The type of GeoJSON object (should be "Feature")
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    /// <summary>
    /// Properties containing earthquake details
    /// </summary>
    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }
    
    /// <summary>
    /// Geometry information (coordinates, etc.)
    /// </summary>
    [JsonPropertyName("geometry")]
    public Geometry Geometry { get; set; }
    
    /// <summary>
    /// Unique identifier for the earthquake
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; }
}

/// <summary>
/// Represents the properties of an earthquake feature
/// </summary>
public class Properties
{
    /// <summary>
    /// Magnitude of the earthquake
    /// </summary>
    [JsonPropertyName("mag")]
    public double? Mag { get; set; }
    
    /// <summary>
    /// Location description of the earthquake
    /// </summary>
    [JsonPropertyName("place")]
    public string Place { get; set; }
    
    /// <summary>
    /// Time when the earthquake occurred (Unix timestamp)
    /// </summary>
    [JsonPropertyName("time")]
    public long? Time { get; set; }
    
    /// <summary>
    /// Time when the earthquake was last updated (Unix timestamp)
    /// </summary>
    [JsonPropertyName("updated")]
    public long? Updated { get; set; }
    
    /// <summary>
    /// Timezone offset in minutes
    /// </summary>
    [JsonPropertyName("tz")]
    public int? Tz { get; set; }
    
    /// <summary>
    /// URL for more details about this earthquake
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
    
    /// <summary>
    /// URL for more details about this earthquake (alternative)
    /// </summary>
    [JsonPropertyName("detail")]
    public string Detail { get; set; }
    
    /// <summary>
    /// Indicates if the earthquake felt
    /// </summary>
    [JsonPropertyName("felt")]
    public int? Felt { get; set; }
    
    /// <summary>
    /// Community Determined Intensity
    /// </summary>
    [JsonPropertyName("cdi")]
    public double? Cdi { get; set; }
    
    /// <summary>
    /// Modified Mercalli Intensity
    /// </summary>
    [JsonPropertyName("mmi")]
    public double? Mmi { get; set; }
    
    /// <summary>
    /// Alert level (green, yellow, orange, red)
    /// </summary>
    [JsonPropertyName("alert")]
    public string Alert { get; set; }
    
    /// <summary>
    /// Status of the earthquake report
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }
    
    /// <summary>
    /// Indicates if the event is a tsunami
    /// </summary>
    [JsonPropertyName("tsunami")]
    public int? Tsunami { get; set; }
    
    /// <summary>
    /// Significance of the earthquake
    /// </summary>
    [JsonPropertyName("sig")]
    public int? Sig { get; set; }
    
    /// <summary>
    /// Network that reported the earthquake
    /// </summary>
    [JsonPropertyName("net")]
    public string Net { get; set; }
    
    /// <summary>
    /// Network code
    /// </summary>
    [JsonPropertyName("code")]
    public string Code { get; set; }
    
    /// <summary>
    /// IDs of associated events
    /// </summary>
    [JsonPropertyName("ids")]
    public string Ids { get; set; }
    
    /// <summary>
    /// IDs of associated events from other networks
    /// </summary>
    [JsonPropertyName("sources")]
    public string Sources { get; set; }
    
    /// <summary>
    /// Types of earthquake data available
    /// </summary>
    [JsonPropertyName("types")]
    public string Types { get; set; }
    
    /// <summary>
    /// Number of seismic stations that reported P- and S-arrival times
    /// </summary>
    [JsonPropertyName("nst")]
    public int? Nst { get; set; }
    
    /// <summary>
    /// Horizontal distance from the epicenter
    /// </summary>
    [JsonPropertyName("dmin")]
    public double? Dmin { get; set; }
    
    /// <summary>
    /// Root mean square of arrival time residuals
    /// </summary>
    [JsonPropertyName("rms")]
    public double? Rms { get; set; }
    
    /// <summary>
    /// Largest azimuthal gap between stations
    /// </summary>
    [JsonPropertyName("gap")]
    public double? Gap { get; set; }
    
    /// <summary>
    /// Type of magnitude
    /// </summary>
    [JsonPropertyName("magType")]
    public string MagType { get; set; }
    
    /// <summary>
    /// Event type
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    /// <summary>
    /// Event title
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }
}

/// <summary>
/// Represents the geometry of an earthquake feature
/// </summary>
public class Geometry
{
    /// <summary>
    /// The type of geometry (should be "Point")
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }
    
    /// <summary>
    /// Coordinates of the earthquake [longitude, latitude, depth]
    /// </summary>
    [JsonPropertyName("coordinates")]
    public double[] Coordinates { get; set; }
}