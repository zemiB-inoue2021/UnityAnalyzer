using System.Text.Json.Serialization;

namespace Assets.Scripts.JsonLoader.Data
{
    /// <summary>
    /// Javaのパッケージ情報
    /// </summary>
    public class Package
    {
        /// <summary>
        /// パッケージ名
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// パッケージに含まれるクラスのリスト
        /// </summary>
        [JsonPropertyName("classes")]
        public ClassOrInterface[] Classes { get; set; }

        /// <summary>
        /// パッケージに含まれるインターフェースのリスト
        /// </summary>
        [JsonPropertyName("interfaces")]
        public ClassOrInterface[] Interfaces { get; set; }

        /// <summary>
        /// パッケージに含まれる列挙型のリスト
        /// </summary>
        [JsonPropertyName("enums")]
        public Enum[] Enums { get; set; }
    }
}
