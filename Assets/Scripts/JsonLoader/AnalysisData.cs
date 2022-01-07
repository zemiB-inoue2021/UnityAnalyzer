using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Assets.Scripts.JsonLoader
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

    }

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
    }
}
