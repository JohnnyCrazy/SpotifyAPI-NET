using Newtonsoft.Json;

namespace SpotifyAPI.Web.Models
{
  public class AnalysisMeta
  {
    [JsonProperty("analyzer_platform")]
    public string AnalyzerVersion { get; set; }

    [JsonProperty("platform")]
    public string Platform { get; set; }

    [JsonProperty("status_code")]
    public int StatusCode { get; set; }

    [JsonProperty("detailed_status")]
    public string DetailedStatus { get; set; }

    [JsonProperty("timestamp")]
    public long Timestamp { get; set; }

    [JsonProperty("analysis_time")]
    public double AnalysisTime { get; set; }

    [JsonProperty("input_process")]
    public string InputProcess { get; set; }
  }
}