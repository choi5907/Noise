using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRender;

    public void DrawNoiseMap(float[,] noiseMap){    // Noise에 noiseMap 호출
        int width = noiseMap.GetLength (0);         // 1차원 배열의 크기
        int height = noiseMap.GetLength (1);        // 2차원 배열의 크기

        Texture2D texture = new Texture2D(width, height);
    
        Color[] colorMap = new Color[width * height];
        for(int y = 0; y < height; y++){
            for(int x = 0; x < width; x++){

            }
        }
        texture.SetPixels(colorMap);
        texture.Apply();
    }
}
