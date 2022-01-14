using System.Text.Json.Serialization;

namespace Assets.Scripts.JsonLoader.Data
{
    /// <summary>
    /// 列挙型の情報
    /// </summary>
    public class Enum
    {
        /// <summary>
        /// 名前
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// メソッド
        /// </summary>
        [JsonPropertyName("methods")]
        public Method[] Methods { get; set; }

        /// <summary>
        /// 列挙値のリスト
        /// </summary>
        [JsonPropertyName("values")]
        public string[] Values { get; set; }
    }
}
