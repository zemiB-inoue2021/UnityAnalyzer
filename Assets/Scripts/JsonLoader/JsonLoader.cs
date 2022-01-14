using System.Text.Json;
using System.IO;
using Assets.Scripts.JsonLoader.Data;

public class JsonLoader
{
    #region メソッド
    /// <summary>
    /// JavaAnalyzerで作成したJSONをパースして解析データを作成します．
    /// </summary>
    /// <param name="path">JavaAnalyzerで作成したJSONファイルのパス</param>
    /// <returns>解析データ</returns>
    public static AnalysisData Load(string path)
    {
        // TODO ファイルの存在チェック・エラー処理

        // JSONの内容を読み取り
        using (var stream = File.OpenRead(path)) {

            // JSONをデシリアライズ
            var data = JsonSerializer.Deserialize<AnalysisData>(stream);

            // 解析データを返す
            return data;
        }
    }
    #endregion
}
