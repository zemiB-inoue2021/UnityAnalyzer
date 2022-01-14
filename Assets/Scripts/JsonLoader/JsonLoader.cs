using System.Text.Json;
using System.IO;
using Assets.Scripts.JsonLoader.Data;

public class JsonLoader
{
    #region ���\�b�h
    /// <summary>
    /// JavaAnalyzer�ō쐬����JSON���p�[�X���ĉ�̓f�[�^���쐬���܂��D
    /// </summary>
    /// <param name="path">JavaAnalyzer�ō쐬����JSON�t�@�C���̃p�X</param>
    /// <returns>��̓f�[�^</returns>
    public static AnalysisData Load(string path)
    {
        // TODO �t�@�C���̑��݃`�F�b�N�E�G���[����

        // JSON�̓��e��ǂݎ��
        using (var stream = File.OpenRead(path)) {

            // JSON���f�V���A���C�Y
            var data = JsonSerializer.Deserialize<AnalysisData>(stream);

            // ��̓f�[�^��Ԃ�
            return data;
        }
    }
    #endregion
}
