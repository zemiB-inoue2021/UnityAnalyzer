using UnityEngine;
using Assets.Scripts.JsonLoader.Data;

public class BuildingCreator
{
    /// <summary>
    /// 可視化対象データ
    /// </summary>
    private AnalysisData _data;

    /// <summary>
    /// 建物の配置する親オブジェクト
    /// </summary>
    private GameObject _buildingContainer;

    public BuildingCreator(GameObject container, AnalysisData data)
    {
        _buildingContainer = container;
        _data = data;
    }

    /// <summary>
    /// 建物のオブジェクトを作成します．
    /// </summary>
    public void Create()
    {
        // 子オブジェクトを全削除
        DestroyChildren(_buildingContainer);

        // 建物を生成
        int pacnum = 0;
        foreach (Package p in _data.Packages) {
            int clsnum = 0, internum = 0, enumnum = 0;
            CreateCube(p, pacnum);
            foreach (ClassOrInterface c in p.Classes) {
                CreateCube(c, pacnum, clsnum, true);
                int mtdnum = 0, connum = 0;
                foreach (Constructor constructor in c.Constructors) {
                    int paranum = 0;
                    CreateCube(constructor, pacnum, clsnum, connum);
                    foreach (Param param in constructor.Params) {
                        CreateSphere(param, pacnum, clsnum, connum, paranum, constructor.LOC);
                        paranum++;
                    }
                    connum++;
                }
                foreach (Method m in c.Methods) {
                    int paranum = 0;
                    CreateCube(m, pacnum, clsnum, mtdnum);
                    foreach (Param param in m.Params) {
                        CreateSphere(param, pacnum, clsnum, mtdnum, paranum, m.LOC);
                        paranum++;
                    }
                    mtdnum++;
                }
                clsnum++;
            }

            foreach (ClassOrInterface i in p.Interfaces) {
                CreateCube(i, pacnum, internum, false);
                int mtdnum = 0, connum = 0;
                foreach (Constructor constructor in i.Constructors) {
                    int paranum = 0;
                    CreateCube(constructor, pacnum, internum + clsnum, connum);
                    foreach (Param param in constructor.Params) {
                        CreateSphere(param, pacnum, internum, connum, paranum, constructor.LOC);
                        paranum++;
                    }
                    connum++;
                }
                foreach (Method m in i.Methods) {
                    int paranum = 0;
                    CreateCube(m, pacnum, internum + clsnum, mtdnum);
                    foreach (Param param in m.Params) {
                        CreateSphere(param, pacnum, internum, mtdnum, paranum, m.LOC);
                        paranum++;
                    }
                    mtdnum++;
                }
                internum++;
            }

            foreach (Enum e in p.Enums) {
                CreateCube(e, pacnum, enumnum);
                int mtdnum = 0, connum = 0, valnum = 0;
                foreach (Constructor constructor in e.Constructors) {
                    int paranum = 0;
                    CreateCube(constructor, pacnum, clsnum + internum + enumnum, connum);
                    foreach (Param param in constructor.Params) {
                        CreateSphere(param, pacnum, enumnum, connum, paranum, constructor.LOC);
                        paranum++;
                    }
                    connum++;
                }
                foreach (Method m in e.Methods) {
                    int paranum = 0;
                    CreateCube(m, pacnum, clsnum + internum + enumnum, mtdnum);
                    foreach (Param param in m.Params) {
                        CreateSphere(param, pacnum, enumnum, mtdnum, paranum, m.LOC);
                        paranum++;
                    }
                    mtdnum++;
                }
                foreach (string val in e.Values) {
                    CreateCube(val, pacnum, clsnum + internum + enumnum, valnum);
                    valnum++;
                }
                enumnum++;
            }
            pacnum++;
        }
    }

    private void CreateCube(Package package, int number)
    {
        GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newCube.transform.position = new Vector3(number * 110, 0, 0);
        newCube.transform.localScale += new Vector3(99, 0, 99);
        newCube.GetComponent<Renderer>().material.color = new Color(0.0f, 0.0f, 0.0f);

        // 親オブジェクトを設定
        newCube.transform.parent = _buildingContainer.transform;
    }

    private void CreateCube(ClassOrInterface c, int offset, int number, bool isClass)
    {
        float darkness = (isClass ? 0.5f : 0.7f);
        GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newCube.transform.position = new Vector3(offset * 110 + (number % 3) * 30 + 12, 1, (number / 3) * 30);
        newCube.transform.localScale += new Vector3(29, 0, 29);
        newCube.GetComponent<Renderer>().material.color = new Color(darkness, darkness, darkness);
        newCube.name = c.Name;

        // 親オブジェクトを設定
        newCube.transform.parent = _buildingContainer.transform;
    }

    private void CreateCube(Enum e, int offset, int number)
    {
        float darkness = 0.3f;
        GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newCube.transform.position = new Vector3(offset * 110 + (number % 3) * 30 + 12, 1, (number / 3) * 30);
        newCube.transform.localScale += new Vector3(29, 0, 29);
        newCube.GetComponent<Renderer>().material.color = new Color(darkness, darkness, darkness);
        newCube.name = e.Name;

        // 親オブジェクトを設定
        newCube.transform.parent = _buildingContainer.transform;
    }

    private void CreateCube(Method method, int offset1, int offset2, int number)
    {
        string typestr = method.ReturnType;
        Color color;
        color = SetColor(typestr);
        GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newCube.transform.position = new Vector3(offset1 * 110 + (offset2 % 3) * 30 + (number % 10) * 3, 2 + 0.05f * method.LOC, (offset2 / 3) * 30 + (number / 10) * 3);
        newCube.transform.localScale += new Vector3(1 + method.CyclomaticComplexity * 0.1f, 0.1f * method.LOC, 1 + method.Params.Length * 1.0f);
        newCube.GetComponent<Renderer>().material.color = color;
        newCube.name = method.Name;

        // 親オブジェクトを設定
        newCube.transform.parent = _buildingContainer.transform;
    }

    private void CreateCube(Constructor constructor, int offset1, int offset2, int number)
    {
        GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newCube.transform.position = new Vector3(offset1 * 110 + (offset2 % 3) * 30 + (number % 10) * 3, 2 + 0.05f * constructor.LOC, (offset2 / 3) * 30 + (number / 10) * 3 + 5);
        newCube.transform.localScale += new Vector3(1 + constructor.CyclomaticComplexity * 0.1f, 0.1f * constructor.LOC, 1 + constructor.Params.Length * 1.0f);
        newCube.GetComponent<Renderer>().material.color = new Color(1.0f, 0.2f, 1.0f);
        newCube.name = "Constructor " + (number + 1).ToString();

        // 親オブジェクトを設定
        newCube.transform.parent = _buildingContainer.transform;
    }

    private void CreateSphere(Param param, int offset1, int offset2, int offset3, int number, int parentLOC)
    {
        string typestr = param.Type;
        Color color;
        color = SetColor(typestr);
        GameObject newSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        newSphere.transform.position = new Vector3(offset1 * 110 + (offset2 % 3) * 30 + (offset3 % 10) * 3 + number % 3, 3 + parentLOC * 0.1f, (offset2 / 3) * 30 + (number / 10) * 3 + number / 3);
        newSphere.transform.localScale += new Vector3(0, 0, 0);
        newSphere.GetComponent<Renderer>().material.color = color;
        newSphere.name = param.Name;

        // 親オブジェクトを設定
        newSphere.transform.parent = _buildingContainer.transform;
    }

    private void CreateCube(string value, int offset1, int offset2, int number)
    {
        GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        newCube.transform.position = new Vector3(offset1 * 110 + (offset2 % 3) * 30 + (number % 10) * 3, 2, (offset2 / 3) * 30 + (number / 10) * 3 - 5);
        newCube.transform.localScale += new Vector3(0, 0, 0);
        newCube.GetComponent<Renderer>().material.color = new Color(0.3f, 1.0f, 0.3f);
        newCube.name = value;

        // 親オブジェクトを設定
        newCube.transform.parent = _buildingContainer.transform;
    }

    private static Color SetColor(string typestr)
    {
        Color color;
        switch (typestr) {
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
                color = new Color(0.5f, 1.0f, 0.5f);
                break;
            case "boolean[]":
            case "List<boolean>":
                color = new Color(0.5f, 0.5f, 1.0f);
                break;
            default:
                color = new Color(1.0f, 1.0f, 1.0f);
                break;
        }

        return color;
    }

    private void DestroyChildren(GameObject gameObject)
    {
        foreach (Transform transform in gameObject.transform) {
            Object.Destroy(transform.gameObject);
        }
    }
}