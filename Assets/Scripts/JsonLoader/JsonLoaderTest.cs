using Assets.Scripts.Analyzer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonLoaderTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var data = JavaSourceAnalyzer.Analyze(@"D:\univ\enshud\compiler\src\main");
        //var data = JsonLoader.Load(@"D:\univ\ƒ[ƒ~B\research\sample_data.json");
        //var data = JsonLoader.Load(@"D:\univ\ƒ[ƒ~B\research\java_source_analyzer_sample.json");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
