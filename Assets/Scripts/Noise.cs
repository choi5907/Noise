using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Noise
{
    // 매개변수 입력
    // mapWidth mapHeight - 맵 크기, seed - 샘플링값, scale - 비율, 
    // octaves - 주파수를 중첩시키기 위한 값, persistance
    public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset){  
        float[,] noiseMap = new float[mapWidth, mapHeight]; // noise맵 크기지정
        // 고유의 값으로 샘플링??
        System.Random prng = new System.Random (seed);
        Vector2[] octaveOffsets = new Vector2[octaves];
        // -100000 ~ 100000 값 반환 하여 octaveoffset에 저장
        for(int i = 0; i < octaves; i++){
            float offsetX = prng.Next(-100000, 100000) + offset.x;
            float offsetY = prng.Next(-100000, 100000) + offset.y;
            octaveOffsets[i] = new Vector2 (offsetX, offsetY);
        }

        if(scale <= 0){                                     // 0이하일 경우 최소값 지정
            scale = 0.0001f;
        }

        // 노이즈맵 최소값 최대값 지정
        float maxNoiseHeight = float.MinValue;
        float minNoiseHeight = float.MaxValue;
        // 맵 중앙을 만들기 위한 절반값
        float halfWidth = mapWidth / 2f;
        float halfHeight = mapHeight / 2f;

        for( int y = 0; y < mapHeight; y++){
            for( int x = 0; x < mapWidth; x++){

                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;

                for(int i = 0; i < octaves; i++){
                    // x좌표와 y좌표들을 scale로 나누고 주파수를 곱하여 프리셋값을 더한다.
                    float sampleX = (x-halfWidth) / scale * frequency + octaveOffsets[i].x;
                    float sampleY = (y-halfHeight) / scale * frequency + octaveOffsets[i].y;

                    // 펄린값에 펄린노이즈를 적용시켜 저장
                    float perlinValue = Mathf.PerlinNoise(sampleX, sampleY) * 2 - 1;
                    // 노이즈의 폭은 펄린값에 진폭을 곱한 것을 더해준다.
                    noiseHeight += perlinValue * amplitude;

                    // 진폭에 지속적인 값을 곱해주고 주파수에도 lacun값을 곱해준다.
                    amplitude *= persistance;
                    frequency *= lacunarity;
                }
                if( noiseHeight > maxNoiseHeight ){
                    maxNoiseHeight = noiseHeight;
                } else if( noiseHeight < minNoiseHeight ){
                    minNoiseHeight = noiseHeight;
                }
                noiseMap [x, y] = noiseHeight;
            }
        }
        // 노이즈맵 정규화 과정
        for(int y = 0; y < mapHeight; y++){
            for(int x = 0; x < mapWidth; x++){
                // 역보간 Math.f 함수
                noiseMap [x, y] = Mathf.InverseLerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
            }
        }
        return noiseMap;                                    // 반환
    }
}
