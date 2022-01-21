using Assets.Scripts.Analyzer;
using SFB;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// �\�[�X�R�[�h�̃f�B���N�g��
    /// </summary>
    [SerializeField] private TMPro.TMP_InputField _directoryInputField;

    /// <summary>
    /// ������z�u����e�I�u�W�F�N�g
    /// </summary>
    [SerializeField] private GameObject _buidlingContainer;

    /// <summary>
    /// ���j���[�̃{�^��
    /// </summary>
    [SerializeField] private Button[] _menuButtons;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ��͑Ώۃf�B���N�g���I����ʂ�\�����܂��D
    /// </summary>
    public void SelectDirectory()
    {
        var dir = StandaloneFileBrowser.OpenFolderPanel(string.Empty, string.Empty, false);
        if (dir == null || dir.Length == 0) { return; }

        _directoryInputField.text = dir[0];
    }

    /// <summary>
    /// ��͂����s���āC���o�����s���܂��D
    /// </summary>
    public void ExecuteAnalyze()
    {
        // �{�^���𖳌���
        SetMenuButtonsInteractable(false);

        try {
            // �\�[�X�R�[�h�̃f�B���N�g�����擾
            var dir = _directoryInputField.text;

            // JavaParser�ŉ��
            var data = JavaSourceAnalyzer.Analyze(dir);

            // ��͌��ʂ����o��
            var creator = new BuildingCreator(_buidlingContainer, data);
            creator.Create();
        }
        finally {
            // �{�^����L����
            SetMenuButtonsInteractable(true);
        }
    }

    /// <summary>
    /// ���j���[�̃{�^��������\����ݒ肵�܂��D
    /// </summary>
    /// <param name="isInteractable">����\�ɂ���ꍇtrue</param>
    private void SetMenuButtonsInteractable(bool isInteractable)
    {
        foreach (var button in _menuButtons) {
            button.interactable = isInteractable;
        }
    }
}
