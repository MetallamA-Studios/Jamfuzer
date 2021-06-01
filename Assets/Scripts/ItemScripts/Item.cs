using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_ITEM_TYPE
{
    Healing,
    Upgrade,
    Powerup
}

public class Item : ScriptableObject
{
    #region Public Variables
    public E_ITEM_TYPE e_itemType;

    public int i_attack;

    public int i_defense;

    public int i_accuracy;

    public int i_evasion;

    public string s_itemDescription;

    public string s_itemUseName;

    public string s_weaponUseDescription;
    #endregion

    public void Use_Item()
    {

    }
}
