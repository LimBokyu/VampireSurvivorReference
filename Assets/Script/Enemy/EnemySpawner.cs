using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPoint;

    [SerializeField]
    private GameObject enemyObject;

    private Coroutine spawnCoroutine;
    private YieldInstruction spawnTimer = new WaitForSeconds(0.5f);

    private StringBuilder sb = new StringBuilder();

    private void Start()
    {
        spawnCoroutine = StartCoroutine(EnemySpawn());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        int random = Random.Range(0, 4);

        //sb.Append("EnemySpawn : ");
        //sb.Append(random);
        //sb.Append("Point");
        //Debug.Log(sb);
        //sb.Clear();

        Instantiate(enemyObject, spawnPoint[random].transform.position, Quaternion.identity);
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
