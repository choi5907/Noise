using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextureGenerator
{
    public static Texture2D TextureFromColorMap(Color[] colorMap, int width, int height){
        Texture2D texture = new Texture2D(width, height);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.SetPixels(colorMap);
        texture.Apply();
        return texture;
    }

    public static Texture2D TextureFromHeightMap(float[,] heightMap){   // Noise에 noiseMap 호출하기위한 height매개변수
        int width = heightMap.GetLength (0);         // 1차원 배열의 크기
        int height = heightMap.GetLength (1);        // 2차원 배열의 크기
    
        Color[] colorMap = new Color[width * height];       // 배열을 곱하여 평면에서 모든 픽셀을 한번에 칠
        for(int y = 0; y < height; y++){
            for(int x = 0; x < width; x++){
                colorMap [y * width + x] = Color.Lerp (Color.black, Color.white, heightMap [x, y]);
                // 해당하는 행과 열의 위치에 black~white 사이의 색을 펄린노이즈값을 가진 heightMap만큼 지정
            }
        }
        // // 2D 텍스처에 컬러값 배열 colorMap을 지정 > 적용
        // texture.SetPixels(colorMap);
        // texture.Apply();

        return TextureFromColorMap(colorMap, width, height);
    }
}
