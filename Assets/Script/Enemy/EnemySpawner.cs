using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoint;

    [SerializeField]
    private GameObject enemyA;

    [SerializeField]
    private GameObject enemyB;

    [SerializeField]
    private GameObject enemyC;

    [SerializeField]
    private GameObject enemyD;

    [SerializeField]
    private EnemyPool pool;

    private List<GameObject> enemyList = new List<GameObject>();

    private Coroutine spawnCoroutine;
    private YieldInstruction spawnTimer = new WaitForSeconds(0.5f);

    private StringBuilder sb = new StringBuilder();

    private int spawnCount = 0;
    private int spawnType = 0;

    private int spawnPointNumber = 0;

    private void Awake()
    {
        SetEnemyList();
        spawnCoroutine = StartCoroutine(EnemySpawn());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SpawnEnemy();
        }
    }

    public void StartSpawn()
    {
        
    }

    private void SetEnemyList()
    {
        enemyList.Clear();
        enemyList.Add(enemyA);
        enemyList.Add(enemyB);
        enemyList.Add(enemyC);
        enemyList.Add(enemyD);
    }

    public void SpawnEnemy()
    {
        if(spawnCount >= 40)
        {
            spawnCount = 0;
            spawnType++;
            GameManager.Instance.NextRound();
            if (spawnType >= 4)
                spawnType = 0;
        }
        
        if(spawnPointNumber >= 4)
        {
            spawnPointNumber = 0;
        }

        GameObject enemy = pool.GetPoolObject(spawnType);
        enemy.transform.position = spawnPoint[spawnPointNumber].transform.position;

        spawnCount++;
        spawnPointNumber++;

    }

    private IEnumerator EnemySpawn()
    {
        while (true)
        {
            SpawnEnemy();
            yield return spawnTimer;
        }
    }
}
