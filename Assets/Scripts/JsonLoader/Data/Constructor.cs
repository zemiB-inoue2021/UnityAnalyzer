using System.Text.Json.Serialization;

namespace Assets.Scripts.JsonLoader.Data
{
    /// <summary>
    /// コンストラクタ情報
    /// </summary>
    public class Constructor
    {
        /// <summary>
        /// パラメーターのリスト
        /// </summary>
        [JsonPropertyName("params")]
        public Param[] Params { get; set; }

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
}
