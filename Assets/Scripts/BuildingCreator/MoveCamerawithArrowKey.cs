using System;
using UnityEngine;

public class MoveCamerawithArrowKey : MonoBehaviour
{
    /// <summary>
    /// ƒJƒƒ‰‚ÌˆÚ“®‘¬“x
    /// </summary>
    [Obsolete][SerializeField] private float _accel = 1.0f;

    /// <summary>
    /// ‘€ì‘ÎÛƒJƒƒ‰
    /// </summary>
    [SerializeField] private GameObject _mainCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) {
            if (_accel < 2.0f) _accel += 0.00625f;
            if (Input.GetKey(KeyCode.DownArrow)) {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                    _mainCamera.transform.Translate(0, -0.1f, 0);
                }
                else {
                    _mainCamera.transform.Translate(0, 0, -0.1f);
                }
            }
            if (Input.GetKey(KeyCode.UpArrow)) {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                    _mainCamera.transform.Translate(0, 0.1f, 0);
                }
                else {
                    _mainCamera.transform.Translate(0, 0, 0.1f);
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                _mainCamera.transform.Translate(-0.1f, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                _mainCamera.transform.Translate(0.1f, 0, 0);
            }
        }
        else {
            if (_accel > 1.01f) _accel -= 0.02f;
            else _accel = 1.0f;
        }

    }
}
