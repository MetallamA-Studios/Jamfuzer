using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_WEAPON_TYPE
{
    Gun,
    Shield,
    Sword
}

[CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 3)]
public class Weapon : ScriptableObject
{
    #region Public Variables
    public E_WEAPON_TYPE e_weaponType;
    public E_DAMAGE_TYPES dt_weaponDamageType;

    public Sprite s_weaponSprite;

    public int i_primaryAttackValue;
    public int i_secondaryAttackValue;
    public int i_meleeAttackValue;

    public string s_weaponDescription;

    public string s_weaponPrimaryAttackName;
    public string s_weaponSecondaryAttackName;
    public string s_weaponMeleeAttackName;

    public string s_weaponPrimaryAttackDescription;
    public string s_weaponSecondaryAttackDescription;
    public string s_weaponMeleeAttackDescription;

    public int i_ammoMax;
    public int i_currentAmmo;
    public int i_primaryAmmoUse;
    public int i_secondaryAmmoUse;
    #endregion

    public void Weapon_Primary_Attack()
    {

    }

    public void Weapon_Secondary_Attack()
    {

    }

    public void Weapon_Melee_Attack()
    {

    }

    public void Weapon_Reload()
    {
        i_currentAmmo = i_ammoMax;
    }
}
