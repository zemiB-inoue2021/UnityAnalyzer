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
        // JSONの内容を読み取り
        // TODO ファイルの存在確認・エラー処理
        var json = File.ReadAllText(path);

        // JSONをデシリアライズ
        var data = JsonSerializer.Deserialize<AnalysisData>(json);

        // 解析データを返す
        return data;
    }
    #endregion
}
