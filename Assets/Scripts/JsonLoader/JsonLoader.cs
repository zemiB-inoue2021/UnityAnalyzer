using Assets.Scripts.JsonLoader;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.Json;
using System.IO;

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
        // JSON�̓��e��ǂݎ��
        // TODO �t�@�C���̑��݊m�F�E�G���[����
        var json = File.ReadAllText(path);

        // JSON���f�V���A���C�Y
        var data = JsonSerializer.Deserialize<AnalysisData>(json);

        // ��̓f�[�^��Ԃ�
        return data;
    }
    #endregion
}
