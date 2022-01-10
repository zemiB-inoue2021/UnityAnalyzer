using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBuildings : MonoBehaviour
{
    int count = 0;
    int a = 0;
    public const int MAX_COUNT = 75;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == MAX_COUNT)
        {
            GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newCube.transform.position = new Vector3(a, 0, a);
            newCube.transform.localScale += new Vector3(0, a / 10.0F, 0);
            newCube.GetComponent<Renderer>().material.color = new Color(Mathf.Abs(Mathf.Sin(a * Mathf.PI / 100)), Mathf.Abs(Mathf.Cos(a * Mathf.PI / 100)), 0.0f);
            newCube.name = "Cube "+(a+1).ToString();
            count = 0; a++;
        }
        else count++;
    }
}
