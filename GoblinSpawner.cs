using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoblinSpawner : MonoBehaviour
{
    public float spawnTime;
    public float spawnDecreaseTime;
    public float spawnDecreaseMin;
    public GameObject prefab;
    public float numOfEnemies;
    public float maxEnemies;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnGoblin());
    }
    // Update is called once per frame
    IEnumerator SpawnGoblin()
    {
        yield return new WaitForSeconds(spawnTime);
        /******SIMPLIFY******/
        if((numOfEnemies < maxEnemies && GameManager.gameManager.enemiesSpawned < GameManager.gameManager.maxEnemiesLevel1
            && GameManager.gameManager.activeScene == "TTTExterior+Town")
            || (numOfEnemies < maxEnemies && GameManager.gameManager.enemiesSpawned < GameManager.gameManager.maxEnemiesLevel2 &&
            GameManager.gameManager.activeScene == "TTTExterior+Town 2"))
        /********************/
        {
            GameObject enemy = Instantiate(prefab, transform.position, Quaternion.identity);
            Enemy enemy1 = enemy.GetComponent<Enemy>();
            enemy1.spawner = this.gameObject.GetComponent<GoblinSpawner>();

            numOfEnemies++;
            GameManager.gameManager.enemiesSpawned++;
        }
        else if (numOfEnemies >= maxEnemies)
            yield return null;
        if (spawnTime > spawnDecreaseMin)
            spawnTime *= spawnDecreaseTime;
        StartCoroutine(SpawnGoblin());
    }
    
}
