using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public int numberOfMobsAtOnce;
    public int spawnRange;
    public float timeToWaitBeforeRespawn;
    public List<GameObject> enemySpawned;
    
    private void Start () {
        for (var i = 0; i < numberOfMobsAtOnce; i++) {
            var pos = transform.position;
            var randomPosition = new Vector3(Random.Range(pos.x - spawnRange, pos.x + spawnRange),
                pos.y,
                Random.Range(pos.z - spawnRange, pos.z + spawnRange));
            
            var mobSpawned = Instantiate(enemyToSpawn,randomPosition,Quaternion.identity);
            mobSpawned.transform.parent = transform;
            enemySpawned.Add(mobSpawned);
        }
        StartCoroutine(SpawnEnemes());
    }

    private IEnumerator SpawnEnemes(){
        
        for (var i = 0; i < enemySpawned.Count; i++) {
            if(enemySpawned[i] == null){
                enemySpawned.RemoveAt(i);
            }
        }
        
        if(enemySpawned.Count < numberOfMobsAtOnce){
            var pos = transform.position;
            var randomPosition = new Vector3(Random.Range(pos.x - spawnRange, pos.x + spawnRange),
                pos.y,
                Random.Range(pos.z - spawnRange, pos.z + spawnRange));
            
            var mobSpawned = Instantiate(enemyToSpawn,randomPosition,Quaternion.identity);
            mobSpawned.transform.parent = transform;
            enemySpawned.Add(mobSpawned);
        }
        
        yield return new WaitForSeconds(timeToWaitBeforeRespawn);
        StartCoroutine(SpawnEnemes());
    }
}
