using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private int listSize = 10;

    [SerializeField]
    private GameObject bullet;

    [SerializeField]
    private Transform bulletParent;

    private List<GameObject> bulletList = new List<GameObject>();

    private void Awake()
    {
        SettingPool();
    }

    //리스트 사이즈 만큼 게임 오브젝트를 생성하고
    //오브젝트를 리스트에 추가한 뒤 반환될 오브젝트 풀을 이 컴포넌트로 지정
    //이후 비활성화
    private void SettingPool()
    {
        for(int i=0; i<listSize; i++)
        {
            GameObject go = Instantiate(bullet, bulletParent);
            bulletList.Add(go);
            go.GetComponent<Bullet>().SettingPool(this);
            go.SetActive(false);
        }
    }

    public GameObject GetPoolObject()
    {
        foreach(GameObject bullet in bulletList)
        {
            if(!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        GameObject go = Instantiate(bullet, bulletParent);
        bulletList.Add(go);
        go.GetComponent<Bullet>().SettingPool(this);
        return go;
    }

    //오브젝트 리스트에 반환
    public void ReturnObject(GameObject returnObject)
    {
        returnObject.SetActive(false);
    }
}
