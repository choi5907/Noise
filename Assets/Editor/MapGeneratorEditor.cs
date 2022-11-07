using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// MapGenerator를 버튼으로 실행하는 스크립트, Editor 폴더에 있어야한다.
// Editor를 상속받아서 UI를 생성
 [CustomEditor (typeof(MapGenerator))]
public class MapGeneratorEditor : Editor
{
    public override void OnInspectorGUI(){
        MapGenerator mapGen = (MapGenerator)target;

        if(DrawDefaultInspector()){
            if(mapGen.autoUpdate){
                mapGen.GenerateMap();
            }
        }

        if(GUILayout.Button("Generate")){
            mapGen.GenerateMap();
        }       
    }
}