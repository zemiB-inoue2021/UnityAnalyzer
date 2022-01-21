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
        /// JavaParser��jar�t�@�C����
        /// </summary>
        private const string JAVA_PARSER_JAR_NAME = "javasourceanalyzer.jar";

        /// <summary>
        /// JavaParser��jar�t�@�C���̃p�X
        /// </summary>
        private static readonly string _javaParserPath = Path.Combine(Application.streamingAssetsPath, JAVA_PARSER_JAR_NAME);

        /// <summary>
        /// �w�肵���f�B���N�g���ȉ���.java�t�@�C������͂��āC��̓f�[�^���쐬���܂��D
        /// </summary>
        /// <param name="srcDir"></param>
        /// <returns></returns>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static AnalysisData Analyze(string srcDir)
        {
            // �f�B���N�g���̑��݊m�F
            if (!Directory.Exists(srcDir)) {
                throw new DirectoryNotFoundException();
            }

            // JavaParser�̎��s�����쐬
            var info = new ProcessStartInfo()
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                FileName = "java",
                Arguments = $"-jar \"{_javaParserPath}\" \"{srcDir}\""
            };

            // JavaParser�����s
            var process = Process.Start(info);
            var json = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            // ���s�Ɏ��s�����null��Ԃ�
            if (process.ExitCode != 0) {
                return null;
            }

            // JSON�����
            var data = JsonSerializer.Deserialize<AnalysisData>(json);

            // ��̓f�[�^��Ԃ�
            return data;
        }
    }
}
