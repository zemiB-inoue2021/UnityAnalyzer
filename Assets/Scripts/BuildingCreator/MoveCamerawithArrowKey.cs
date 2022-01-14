using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamerawithArrowKey : MonoBehaviour
{
    public float accel = 1.0f;
    /*
     * �ꉞ����JSON�`���œǂݍ��ݏ������������̂ŁC
     * �K���Ƀt�@�C��������ăe�X�g���Ă݂悤�Ǝv���Ă��܂�
     */
    public GameObject mainCamera ;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            if (accel < 2.0f) accel += 0.00625f;
            if (Input.GetKey(KeyCode.DownArrow))
            {
                mainCamera.transform.Translate(0, 0, -0.1f);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                mainCamera.transform.Translate(0, 0, 0.1f);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                mainCamera.transform.Translate(-0.1f, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                mainCamera.transform.Translate(0.1f, 0, 0);
            }
        }
        else {
            if (accel > 1.01f) accel -= 0.02f;
            else accel = 1.0f;
        }
        
    }
}
