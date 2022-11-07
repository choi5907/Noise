using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    // 매개변수 입력
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, float scale, int octaves, float persistance, float lacunarity){  
        float[,] noiseMap = new float[mapWidth, mapHeight]; // noise맵 크기지정

        if(scale <= 0){                                     // 0이하일 경우 최소값 지정
            scale = 0.0001f;
        }

        for( int y = 0; y < mapHeight; y++){
            for( int x = 0; x < mapWidth; x++){

                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for(int i = 0; i < octaves; i++){
                    float sampleX = x / scale * frequency;  // x좌표와 y좌표들을 scale로 나누어 저장
                    float sampleY = y / scale * frequency;

                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY);    // 펄린값에 펄린노이즈를 적용시켜 저장
                    noiseHeight += perlinValue *amplitude;
                    
                    amplitude *= persistance;
                    frequency *= lacunarity;
                    
                }
                
            }
        }
        return noiseMap;                                    // 반환
    }
}
