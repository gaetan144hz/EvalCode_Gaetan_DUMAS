using System;
using UnityEngine;
using Random = System.Random;

public class Spawner : MonoBehaviour
{
    public BoxCollider2D playZone;

    public GameObject fruitPrefab;

    private void Start()
    {
        SpawnFruit();
    }

    public void SpawnFruit()
    {
        Vector2Int maxSpawnPose = Random.Range(17, 9);
        Vector2Int minSpawnPose = Random.Range(-17, -9);
        
        Instantiate(fruitPrefab, new Vector2Int(maxSpawnPose, minSpawnPose));
    }
}
