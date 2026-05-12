using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField]
    private int listSize = 10;

    [SerializeField]
    private GameObject bullet;

    private List<GameObject> bulletList = new List<GameObject>();

    private void Awake()
    {
        SettingPool();
    }

    private void SettingPool()
    {
        for(int i=0; i<listSize; i++)
        {
            GameObject go = Instantiate(bullet);
            bulletList.Add(go);
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

        GameObject go = Instantiate(bullet);
        bulletList.Add(go);
        return go;
    }

    public void ReturnObject(GameObject returnObject)
    {
        returnObject.SetActive(false);
    }
}
