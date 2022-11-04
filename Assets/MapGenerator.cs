using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeight;
    public float NoiseScale;

    public void GenerateNoiseMap(){
        float[,] noiseMap = Noise.GenerateNoiseMap ( mapWidth, mapHeight, NoiseScale );

    }
}
