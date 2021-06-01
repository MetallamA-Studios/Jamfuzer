using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Entity : ScriptableObject
{
    #region Public Variables
    public string s_entityName;

    public int i_entityHealth;

    public int i_entityLevel;

    public int i_entityExperience;

    public Dictionary<string, int> d_entityStats = new Dictionary<string, int>();

    public Weapon w_leftHand = null, w_rightHand = null;

    public Item armorItem = null, healthItem = null;

    #endregion

    public void Setup_Stats()
    {
        d_entityStats.Add("Attack", 0);
        d_entityStats.Add("Defense", 0);
        d_entityStats.Add("Accuracy", 0);
        d_entityStats.Add("Evasion", 0);
    }

}

