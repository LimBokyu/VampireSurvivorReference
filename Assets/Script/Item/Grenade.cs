using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grenade : Item
{
    [SerializeField]
    private GameObject grenade;

    int dirNum = 0;

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

        GameObject go = Instantiate(grenade, this.transform.position, grenade.transform.rotation);
        go.transform.forward = attackDir;
        dirNum++;
    }

    private void AttackLevel2()
    {
        
    }

    private void AttackLevel3()
    {

    }

    private void AttackLevel4()
    {

    }

    private void AttackLevel5()
    {

    }
}
