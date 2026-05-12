using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPool : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy1;

    [SerializeField]
    private GameObject enemy2;

    [SerializeField]
    private GameObject enemy3;

    [SerializeField]
    private GameObject enemy4;

    private List<GameObject> enemylist1 = new List<GameObject>();
    private List<GameObject> enemylist2 = new List<GameObject>();
    private List<GameObject> enemylist3 = new List<GameObject>();
    private List<GameObject> enemylist4 = new List<GameObject>();

    [SerializeField]
    private Transform poolParent;

    [SerializeField]
    private int listSize = 20;

    private void Awake()
    {
        SetPoolList(enemy1, enemylist1);
    }

    private void SetPoolList(GameObject go, List<GameObject> list)
    {
        for(int i=0; i<listSize; i++)
        {
            GameObject enemy = Instantiate(go, gameObject.transform);
            list.Add(enemy);
            enemy.GetComponent<EnemyController>().SettingEnemyPool(this);
            enemy.SetActive(false);
        }
    }
    
    public GameObject GetPoolObject(int listType)
    {
        List<GameObject> pool = null;
        GameObject poolObject = null;
        switch (listType)
        {
            case 0:
                pool = enemylist1;
                poolObject = enemy1;
                break;
            case 1:
                pool = enemylist2;
                poolObject = enemy2; 
                break;
            case 2:
                pool = enemylist3;
                poolObject = enemy3;
                break;
            case 3:
                pool = enemylist4;
                poolObject = enemy4;
                break;
            default:
                pool = null;
                poolObject = null;
                break;
        }


        //비활성 오브젝트를 찾아서 반환
        foreach (GameObject obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(poolObject);
        newObj.GetComponent<EnemyController>().SettingEnemyPool(this);
        pool.Add(newObj);

        return newObj;
    }

    public void ReturnPoolObject(GameObject go)
    {
        go.SetActive(false);
    }
}
