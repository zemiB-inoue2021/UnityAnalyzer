using System;
using UnityEngine;

public class MoveCamerawithArrowKey : MonoBehaviour
{
    /// <summary>
    /// カメラの移動速度
    /// </summary>
    [Obsolete][SerializeField] private float _accel = 1.0f;

    /// <summary>
    /// 操作対象カメラ
    /// </summary>
    [SerializeField] private GameObject _mainCamera;

    /// <summary>
    /// 角度情報
    /// </summary>
    [SerializeField] private float x = 15f,y = 0,z = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) {
            if (_accel < 2.0f) _accel += 0.00625f;
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                    _mainCamera.transform.Translate(0, -0.1f, 0);
                }
                else {
                    _mainCamera.transform.Translate(0, 0, -0.1f);
                }
            }
            if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W)) {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                    _mainCamera.transform.Translate(0, 0.1f, 0);
                }
                else {
                    _mainCamera.transform.Translate(0, 0, 0.1f);
                }
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
                _mainCamera.transform.Translate(-0.1f, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
                _mainCamera.transform.Translate(0.1f, 0, 0);
            }
            if (Input.GetKey(KeyCode.K))
            {
                _mainCamera.transform.rotation = Quaternion.Euler(--x, y, z);
            }
            if (Input.GetKey(KeyCode.I))
            {
                _mainCamera.transform.rotation = Quaternion.Euler(++x, y, z);
            }
            if (Input.GetKey(KeyCode.J))
            {
                _mainCamera.transform.rotation = Quaternion.Euler(x, --y, z);
            }
            if (Input.GetKey(KeyCode.L))
            {
                _mainCamera.transform.rotation = Quaternion.Euler(x, ++y, z);
            }
            if (Input.GetKey(KeyCode.U))
            {
                _mainCamera.transform.rotation = Quaternion.Euler(x, y, --z);
            }
            if (Input.GetKey(KeyCode.O))
            {
                _mainCamera.transform.rotation = Quaternion.Euler(x, y, ++z);
            }
        }
        else {
            if (_accel > 1.01f) _accel -= 0.02f;
            else _accel = 1.0f;
        }

    }
}
