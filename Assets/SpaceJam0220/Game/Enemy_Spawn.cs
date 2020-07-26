using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    public float min_Y = -4;
    public float max_Y = 4;
    
    public GameObject enemyPrefab;
    
    public float timer = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemies",timer);
    }

    // Update is called once per frame
    void SpawnEnemies()
    {
        float pos_Y = Random.Range(min_Y, max_Y);
        Vector3 temp = transform.position;
        temp.y = pos_Y;
        
        Instantiate(enemyPrefab, temp, Quaternion.identity);
        Invoke("SpawnEnemies",timer);
    }
}
