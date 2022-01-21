using Assets.Scripts.Analyzer;
using SFB;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// ソースコードのディレクトリ
    /// </summary>
    [SerializeField] private TMPro.TMP_InputField _directoryInputField;

    /// <summary>
    /// 建物を配置する親オブジェクト
    /// </summary>
    [SerializeField] private GameObject _buidlingContainer;

    /// <summary>
    /// メニューのボタン
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
    /// 解析対象ディレクトリ選択画面を表示します．
    /// </summary>
    public void SelectDirectory()
    {
        var dir = StandaloneFileBrowser.OpenFolderPanel(string.Empty, string.Empty, false);
        if (dir == null || dir.Length == 0) { return; }

        _directoryInputField.text = dir[0];
    }

    /// <summary>
    /// 解析を実行して，視覚化を行います．
    /// </summary>
    public void ExecuteAnalyze()
    {
        // ボタンを無効化
        SetMenuButtonsInteractable(false);

        try {
            // ソースコードのディレクトリを取得
            var dir = _directoryInputField.text;

            // JavaParserで解析
            var data = JavaSourceAnalyzer.Analyze(dir);

            // 解析結果を視覚化
            var creator = new BuildingCreator(_buidlingContainer, data);
            creator.Create();
        }
        finally {
            // ボタンを有効化
            SetMenuButtonsInteractable(true);
        }
    }

    /// <summary>
    /// メニューのボタンが操作可能化を設定します．
    /// </summary>
    /// <param name="isInteractable">操作可能にする場合true</param>
    private void SetMenuButtonsInteractable(bool isInteractable)
    {
        foreach (var button in _menuButtons) {
            button.interactable = isInteractable;
        }
    }
}
