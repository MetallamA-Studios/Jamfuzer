using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_ARMOR_TYPE
{
    Light,
    Medium,
    Heavy
}

public class Armor : ScriptableObject
{
    #region Public Variables
    public E_ARMOR_TYPE e_armorType;

    public int i_defence;

    public int i_evasion;

    public string s_armorDescription;
    #endregion

    public void Defend()
    {

    }
}
