using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.JsonLoader.Data;

public class CreateBuildings : MonoBehaviour
{
    /// <summary>
    /// âêÕå„â¬éãâª
    /// </summary>
    private AnalysisData d;
    private bool debug = true;
    private int pnum = 0;
    private List<GameObject> cubes;

    public class MyAnalysisData : AnalysisData
    {
    }

    // TODO âêÕÉfÅ[É^Ç…íºï˚ëÃÇçÏê¨Ç∑ÇÈèàóùí«â¡

    void Start()
    {
        d = JsonLoader.Load("Assets/Sources/java_source_analyzer_sample.json");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int pacnum = 0;
            foreach (Package p in d.Packages)
            {
                int clsnum = 0, internum = 0, enumnum = 0;
                CreateCube(p, pacnum);
                foreach (ClassOrInterface c in p.Classes)
                {
                    CreateCube(c, pacnum, clsnum,true);
                    int mtdnum = 0;
                    foreach (Method m in c.Methods)
                    {
                        int paranum = 0;
                        CreateCube(m, pacnum, clsnum, mtdnum);
                        foreach (Param param in m.Params) {
                            CreateSphere(param, pacnum, clsnum, mtdnum, paranum,m.LOC);
                            paranum++;
                        }
                        mtdnum++;
                    }
                    clsnum++;
                }

                foreach (ClassOrInterface i in p.Interfaces)
                {
                    CreateCube(i, pacnum, internum,false);
                    int mtdnum = 0;
                    foreach (Method m in i.Methods)
                    {
                        int paranum = 0;
                        CreateCube(m, pacnum, internum+clsnum, mtdnum);
                        foreach (Param param in m.Params)
                        {
                            CreateSphere(param, pacnum, internum, mtdnum, paranum,m.LOC);
                            paranum++;
                        }
                        mtdnum++;
                    }
                    internum++;
                }

                foreach (Enum e in p.Enums)
                {
                    CreateCube(e, pacnum,enumnum, false);
                    int mtdnum = 0;
                    foreach (Method m in e.Methods)
                    {
                        int paranum = 0;
                        CreateCube(m, pacnum, clsnum+internum+enumnum, mtdnum);
                        foreach (Param param in m.Params)
                        {
                            CreateSphere(param, pacnum, enumnum, mtdnum, paranum, m.LOC);
                            paranum++;
                        }
                        mtdnum++;
                    }
                    enumnum++;
                }
                pacnum++;
            }
        }
    }

    private void CreateCube(Package package, int number)
    {
        string name;
        GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newCube.transform.position = new Vector3(number * 110, 0, 0);
        newCube.transform.localScale += new Vector3(99, 0, 99);
        newCube.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 0.0f);
        newCube.name = ((name = package.Name) == null) ? ("Package " + (number + 1).ToString()) : name;
        //cubes.Add(newCube);
    }

    private void CreateCube(ClassOrInterface c, int offset, int number, bool isClass)
    {
        {
            float darkness = (isClass? 0.5f : 0.7f);
            GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newCube.transform.position = new Vector3(offset * 110+(number % 3) * 30, 1, (number/3) * 30);
            newCube.transform.localScale += new Vector3(29, 0, 29);
            newCube.GetComponent<Renderer>().material.color = new Color(darkness, darkness, darkness);
            newCube.name = c.Name;
        }
    }

    private void CreateCube(Enum e, int offset, int number, bool isClass)
    {
        {
            float darkness = (isClass ? 0.5f : 0.7f);
            GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newCube.transform.position = new Vector3(offset * 110 + (number % 3) * 30, 1, (number / 3) * 30);
            newCube.transform.localScale += new Vector3(29, 0, 29);
            newCube.GetComponent<Renderer>().material.color = new Color(darkness, darkness, darkness);
            newCube.name = e.Name;
        }
    }

    private void CreateCube(Method method, int offset1 ,int offset2, int number)
    {
        {
            string typestr = method.ReturnType;
            Color color;
            color = SetColor(typestr);
            GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            newCube.transform.position = new Vector3(offset1*110+ (offset2 % 3) * 30+(number % 10) * 3, 2, (offset2 / 3) * 30+(number / 10) * 3);
            newCube.transform.localScale += new Vector3(1+method.CyclomaticComplexity * 0.1f, 0.1f * method.LOC, 1+method.Params.Length * 1.0f);
            newCube.GetComponent<Renderer>().material.color = color;
            newCube.name = method.Name;
        }
    }

    private void CreateSphere(Param param, int offset1, int offset2, int offset3, int number, int parentLOC)
    {
        {
            string typestr = param.Type;
            Color color;
            color = SetColor(typestr);
            GameObject newSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            newSphere.transform.position = new Vector3(offset1 * 110 + (offset2 % 3) * 30 + (offset3 % 10) * 3 + number%3, 3+parentLOC*0.1f, (offset2 / 3) * 30 + (number / 10) * 3+number/3);
            newSphere.transform.localScale += new Vector3(0,0,0);
            newSphere.GetComponent<Renderer>().material.color = color;
            newSphere.name = param.Name;
        }
    }

    private static Color SetColor(string typestr)
    {
        Color color;
        switch (typestr)
        {
            case "void":
                color = new Color(0.0f, 0.0f, 0.0f);
                break;
            case "int":
                color = new Color(1.0f, 0.0f, 0.0f);
                break;
            case "String":
                color = new Color(0.0f, 1.0f, 0.0f);
                break;
            case "Boolean":
                color = new Color(0.0f, 0.0f, 1.0f);
                break;
            case "int[]":
            case "List<int>":
                color = new Color(1.0f, 0.5f, 0.5f);
                break;
            case "String[]":
            case "List<String>":
                color = new Color(1.0f, 0.5f, 0.5f);
                break;
            case "boolean[]":
            case "List<boolean>":
                color = new Color(1.0f, 0.5f, 0.5f);
                break;
            default:
                color = new Color(1.0f, 1.0f, 1.0f);
                break;
        }

        return color;
    }
}