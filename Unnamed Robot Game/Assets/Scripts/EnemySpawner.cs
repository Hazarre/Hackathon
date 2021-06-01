using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int randNum;
    public GameObject enemy; 
    public float spawnRate = 2f; 
    float randX;
    float randY;
    Vector2 whereToSpawn;
    float nextSpawn = 0; 
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn){
            GameObject player = GameObject.Find("Tower");
            nextSpawn = Time.time + spawnRate; 
            randNum = Random.Range(0,100);
            if( randNum < 25 ) {
                offset = new Vector3(
                Random.Range(20, 40 ), 
                Random.Range(20, 40 ), 
                0);
            }
            else if (randNum <50 ) {
                offset = new Vector3(
                Random.Range(-40, -20 ), 
                Random.Range(20, 40 ), 
                0);
            }
            else if (randNum <70 ){
                offset = new Vector3(
                Random.Range(-40, -20 ), 
                Random.Range(-40, -20 ), 
                0);
            }
            else{
                offset = new Vector3(
                Random.Range(20, 40 ),  
                Random.Range(-40, -20 ), 0);
            }

            Instantiate(enemy, player.transform.position + offset, Quaternion.identity);
        }
        
    }
}
