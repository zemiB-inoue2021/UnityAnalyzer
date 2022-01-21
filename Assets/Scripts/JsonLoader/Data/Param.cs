using System.Text.Json.Serialization;

namespace Assets.Scripts.JsonLoader.Data
{
    /// <summary>
    /// パラメーター情報
    /// </summary>
    public class Param
    {
        /// <summary>
        /// 名前
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// 型
        /// </summary>
        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
