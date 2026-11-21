using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyPool : MonoBehaviour
{

#region 적 오브젝트 종류별 선언 및 풀링

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

    #endregion

    private void Awake()
    {
        //적 오브젝트를 풀링하기 
        SettingPoolList();
    }

    private void SettingPoolList()
    {
        SetPoolList(enemy1, enemylist1);
        SetPoolList(enemy2, enemylist2);
        SetPoolList(enemy3, enemylist3);
        SetPoolList(enemy4, enemylist4);
    }

    private void SetPoolList(GameObject go, List<GameObject> list)
    {
        //적 오브젝트를 설정한 리스트의 사이즈 만큼 반복하여 생성하고 리스트에 추가
        //이후 리스트에 추가한 적 오브젝트를 비활성화
        for(int i=0; i<listSize; i++)
        {
            GameObject enemy = Instantiate(go, poolParent);
            list.Add(enemy);
            enemy.GetComponent<EnemyController>().SettingEnemyPool(this);
            enemy.SetActive(false);
        }
    }
    
    public GameObject GetPoolObject(int listType)
    {
        //잘못된 범위의 listType 값이 들어왔을 경우에 null 반환
        if(listType < 0 || listType >= 4)
        {
            return null;
        }

        //listTpye으로 호출할 리스트와 오브젝트를 저장하기 위한 변수 선언
        List<GameObject> pool = null;
        GameObject poolObject = null;

        //listType에 따른 호출할 리스트와 오브젝트 저장
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

        //비활성 오브젝트를 찾지 못했을 경우
        //새 오브젝트 생성후 리스트에 추가한 뒤에 오브젝트 반환
        GameObject newObj = Instantiate(poolObject, poolParent);
        newObj.GetComponent<EnemyController>().SettingEnemyPool(this);
        pool.Add(newObj);

        return newObj;
    }


    //오브젝트를 오브젝트 풀로의 반환
    public void ReturnPoolObject(GameObject go)
    {
        go.SetActive(false);
    }
}
