using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_WEAPON_TYPE
{
    Gun,
    Shield,
    Sword
}

public class Weapon : ScriptableObject
{
    #region Public Variables
    public E_WEAPON_TYPE e_weaponType;

    public int i_attack;

    public string s_weaponDescription;

    public string s_weaponAttackName;

    public string s_weaponAttackDescription;

    public int i_ammoMax;

    public int i_currentAmmo;
    #endregion

    public void Weapon_Attack()
    {

    }
}
