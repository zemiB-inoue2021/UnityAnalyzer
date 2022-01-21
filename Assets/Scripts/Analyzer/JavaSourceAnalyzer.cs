using Assets.Scripts.JsonLoader.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using UnityEngine;

namespace Assets.Scripts.Analyzer
{
    public static class JavaSourceAnalyzer
    {
        /// <summary>
        /// JavaParserのjarファイル名
        /// </summary>
        private const string JAVA_PARSER_JAR_NAME = "javasourceanalyzer.jar";

        /// <summary>
        /// JavaParserのjarファイルのパス
        /// </summary>
        private static readonly string _javaParserPath = Path.Combine(Application.streamingAssetsPath, JAVA_PARSER_JAR_NAME);

        /// <summary>
        /// 指定したディレクトリ以下の.javaファイルを解析して，解析データを作成します．
        /// </summary>
        /// <param name="srcDir"></param>
        /// <returns></returns>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static AnalysisData Analyze(string srcDir)
        {
            // ディレクトリの存在確認
            if (!Directory.Exists(srcDir)) {
                throw new DirectoryNotFoundException();
            }

            // JavaParserの実行情報を作成
            var info = new ProcessStartInfo()
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                FileName = "java",
                Arguments = $"-jar \"{_javaParserPath}\" \"{srcDir}\""
            };

            // JavaParserを実行
            var process = Process.Start(info);
            var json = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // 実行に失敗すればnullを返す
            if (process.ExitCode != 0) {
                return null;
            }

            // JSONを解析
            var data = JsonSerializer.Deserialize<AnalysisData>(json);

            // 解析データを返す
            return data;
        }
    }
}
