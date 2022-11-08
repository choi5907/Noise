using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{
    public Renderer textureRender;

    public void DrawTexture(Texture2D texture){    
        // 매번 Play하지 않도록 미리보기
        textureRender.sharedMaterial.mainTexture =  texture;    // 똑같은 배열의 텍스처를 만듬
        textureRender.transform.localScale = new Vector3 (texture.width, 1, texture.height); // ?
    }
}
