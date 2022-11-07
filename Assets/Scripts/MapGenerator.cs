using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // noiseMap의 크기 받아오는 변수
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;

    // 미리보기 자동 업데이트
    public bool autoUpdate;
    
    // 노이즈맵 생성버튼 기능 ( MapDisplay로부터 정보를 가져온다 )
    public void GenerateMap(){
        float[,] noiseMap = Noise.GenerateNoiseMap ( mapWidth, mapHeight, noiseScale );

        MapDisplay display = FindObjectOfType<MapDisplay> ();
        display.DrawNoiseMap(noiseMap);
    }
}
