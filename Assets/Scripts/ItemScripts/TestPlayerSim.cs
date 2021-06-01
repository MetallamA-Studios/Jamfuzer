using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerSim : MonoBehaviour
{
    public Armor armor;


    public void TestWeakArmor(float damage)
    {
        Debug.Log(armor.Check_Damage(damage, E_DAMAGE_TYPES.Physical));
    }

    public void TestNormalArmor(float damage)
    {
        
        Debug.Log(armor.Check_Damage(damage, E_DAMAGE_TYPES.Bio));
    }

    public void TestStrongArmor(float damage)
    {
        Debug.Log(armor.Check_Damage(damage, E_DAMAGE_TYPES.Energy));
    }
}
