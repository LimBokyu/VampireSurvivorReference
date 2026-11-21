using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade : Item
{
    [SerializeField]
    private GameObject grenade;

    int dirNum = 0;

    public override void AutoAttack()
    {
        
    }

    override public void StartAutoAttack()
    {
        switch (itemLevel)
        {
            case 1:
                AttackLevel1();
                break;
            case 2:
                AttackLevel2();
                break;
            case 3:
                AttackLevel3();
                break;
            case 4:
                AttackLevel4();
                break;
            case 5:
                AttackLevel5();
                break;
        }
    }

    private void AttackLevel1()
    {
        Vector3 attackDir;
        switch (dirNum)
        {
            case 0:
                attackDir = Vector3.forward;
                break;
            case 1:
                attackDir = Vector3.right;
                break;
            case 2:
                attackDir = Vector3.back;
                break;
            case 3:
                attackDir = Vector3.left;
                break;
            default:
                attackDir = Vector3.zero;
                break;
        }

        SpawnGrenade(attackDir);
        NextDirectionNumber();
    }

    private void AttackLevel2()
    {
        Vector3 attackDir;

        int num = dirNum % 2;

        switch (num)
        {
            case 0:
                attackDir = Vector3.forward;
                break;
            case 1:
                attackDir = Vector3.right;
                break;
            default:
                attackDir = Vector3.zero;
                break;
        }

        SpawnGrenade(attackDir);
        SpawnGrenade(attackDir * -1);

        NextDirectionNumber();
    }

    private void AttackLevel3()
    {
        SpawnGrenade(Vector3.forward);
        SpawnGrenade(Vector3.right);
        SpawnGrenade(Vector3.back);
        SpawnGrenade(Vector3.left);
    }

    private void AttackLevel4()
    {
        int num = dirNum % 2;

        switch (num)
        {
            case 0:
                SpawnGrenade(Vector3.forward);
                SpawnGrenade(Vector3.right);
                SpawnGrenade(Vector3.back);
                SpawnGrenade(Vector3.left);
                break;
            case 1:
                SpawnGrenade(new Vector3(1, 0, 1));
                SpawnGrenade(new Vector3(-1, 0, 1));
                SpawnGrenade(new Vector3(1, 0, -1));
                SpawnGrenade(new Vector3(-1, 0, -1));
                break;
            default:
                break;
        }

        NextDirectionNumber();
    }

    private void AttackLevel5()
    {
        SpawnGrenade(Vector3.forward);
        SpawnGrenade(Vector3.right);
        SpawnGrenade(Vector3.back);
        SpawnGrenade(Vector3.left);
        SpawnGrenade(new Vector3( 1,  0,  1));
        SpawnGrenade(new Vector3(-1,  0,  1));
        SpawnGrenade(new Vector3( 1,  0, -1));
        SpawnGrenade(new Vector3(-1,  0, -1));
    }

    private void NextDirectionNumber()
    {
        dirNum++;
        if(dirNum > 3)
        {
            dirNum = 0;
        }
    }

    private void SpawnGrenade(Vector3 dir)
    {
        GameObject go = Instantiate(grenade, this.transform.position, grenade.transform.rotation);
        go.transform.forward = dir.normalized;
    }
}
