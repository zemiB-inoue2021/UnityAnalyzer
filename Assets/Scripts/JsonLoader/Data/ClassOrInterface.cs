using System.Text.Json.Serialization;

namespace Assets.Scripts.JsonLoader.Data
{
    /// <summary>
    /// クラスまたはインターフェースの情報
    /// </summary>
    public class ClassOrInterface
    {
        /// <summary>
        /// 名前
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        [JsonPropertyName("constructors")]
        public Constructor[] Constructors { get; set; }

        /// <summary>
        /// メソッド
        /// </summary>
        [JsonPropertyName("methods")]
        public Method[] Methods { get; set; }
    }
}
