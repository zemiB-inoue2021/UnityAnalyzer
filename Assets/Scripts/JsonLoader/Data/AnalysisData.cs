using System.Text.Json.Serialization;

namespace Assets.Scripts.JsonLoader.Data
{
    /// <summary>
    /// 解析データ
    /// </summary>
    public class AnalysisData
    {
        /// <summary>
        /// パッケージのリスト
        /// </summary>
        [JsonPropertyName("packages")]
        public Package[] Packages { get; set; }
    }
}
