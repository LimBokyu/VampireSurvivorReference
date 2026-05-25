using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Item
{
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
