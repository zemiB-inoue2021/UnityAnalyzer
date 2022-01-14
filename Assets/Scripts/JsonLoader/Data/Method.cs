using System.Text.Json.Serialization;

namespace Assets.Scripts.JsonLoader.Data
{
    /// <summary>
    /// メソッドの情報
    /// </summary>
    public class Method
    {
        /// <summary>
        /// メソッド名
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

        /// <summary>
        /// パラメーターのリスト
        /// </summary>
        [JsonPropertyName("params")]
        public Param[] Params { get; set; }

        /// <summary>
        /// 戻り値の型
        /// </summary>
        [JsonPropertyName("returnType")]
        public string ReturnType { get; set; }

        /// <summary>
        /// LOC
        /// </summary>
        [JsonPropertyName("loc")]
        public int LOC { get; set; }

        /// <summary>
        /// 循環的複雑度
        /// </summary>
        [JsonPropertyName("cyclo")]
        public int CyclomaticComplexity { get; set; }
    }

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
