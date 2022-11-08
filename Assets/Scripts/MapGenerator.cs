using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    // 맵 생성기의 모드 전환
    public enum DrawMode{NoiseMap, ColorMap};
    public DrawMode drawMode;

    // noiseMap의 크기 받아오는 변수
    public int mapWidth;
    public int mapHeight;
    public float noiseScale;
    // 옥타브와 정규화에 필요한 변수
    public int octaves;
    [Range(0, 1)]   // 사용 가능한 범위 설정
    public float persistance;
    public float lacunarity;
    // 샘플링 변수
    public int seed;
    public Vector2 offset;
    // 미리보기 자동 업데이트
    public bool autoUpdate;

    public TerrainType[] regions;    
    // 노이즈맵 생성버튼 기능 ( MapDisplay로부터 정보를 가져온다 )
    public void GenerateMap(){
        float[,] noiseMap = Noise.GenerateNoiseMap ( mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset );

        Color[] colorMap = new Color[mapWidth * mapHeight];
        // 컬러맵(지형) 적용할 좌표
        for(int y = 0; y < mapHeight; y++){
            for(int x = 0; x < mapWidth; x++){
                float currentHeight = noiseMap[x, y];
                for(int i = 0; i < regions.Length; i++){
                    if(currentHeight <= regions[i].height){
                        colorMap [y * mapWidth + x] = regions[i].colors;
                        break;
                    }
                }
            }
        }
        // 맵 생성기 종류
        MapDisplay display = FindObjectOfType<MapDisplay> ();
        if(drawMode == DrawMode.NoiseMap){
            display.DrawTexture(TextureGenerator.TextureFromHeightMap(noiseMap));   
        } else if(drawMode == DrawMode.ColorMap){
            display.DrawTexture(TextureGenerator.TextureFromColorMap(colorMap, mapWidth, mapHeight));   
        }
    }

    void OnValidate() {
        if( mapWidth < 1 ){
            mapWidth = 1;
        }
        if( mapHeight < 1 ){
            mapHeight = 1;
        }
        if(lacunarity < 1){
            lacunarity = 1;
        }
        if(octaves < 0){
            octaves =  0;
        }
    }

    [System.Serializable]
    public struct TerrainType{
        public string name;
        public float height;
        public Color colors;
    }
}
