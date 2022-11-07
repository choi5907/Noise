using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRender;

    public void DrawNoiseMap(float[,] noiseMap){    // Noise에 noiseMap 호출
        int width = noiseMap.GetLength (0);         // 1차원 배열의 크기
        int height = noiseMap.GetLength (1);        // 2차원 배열의 크기

        Texture2D texture = new Texture2D(width, height);   // 너비와 높이가 같은 2D 텍스처
    
        Color[] colorMap = new Color[width * height];       // 배열을 곱하여 평면에서 모든 픽셀을 한번에 칠
        for(int y = 0; y < height; y++){
            for(int x = 0; x < width; x++){
                colorMap [y * width + x] = Color.Lerp (Color.black, Color.white, noiseMap [x, y]);
                // 해당하는 행과 열의 위치에 black~white 사이의 색을 펄린노이즈값을 가진 noiseMap만큼 지정
            }
        }
        // 2D 텍스처에 컬러값 배열 colorMap을 지정 > 적용
        texture.SetPixels(colorMap);
        texture.Apply();

        // 매번 Play하지 않도록 미리보기
        textureRender.sharedMaterial.mainTexture =  texture;    // 똑같은 배열의 텍스처를 만듬
        textureRender.transform.localScale = new Vector3 (width, 1, height); // ?

    }
}
