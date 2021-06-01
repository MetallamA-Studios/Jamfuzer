using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_ITEM_TYPE
{
    Healing,
    Upgrade,
    Powerup
}

[CreateAssetMenu(fileName = "Item", menuName = "Items/Item", order = 2)]
public class Item : ScriptableObject
{
    #region Public Variables
    public E_ITEM_TYPE e_itemType;

    public Sprite s_itemSprite;

    public int i_itemAttackModifier;

    public int i_itemDefenseModifier;

    public int i_itemAccuracyModifier;

    public int i_itemEvasionModifier;

    public string s_itemDescription;

    public string s_itemUseName;

    public string s_weaponUseDescription;

    public E_DAMAGE_TYPES dt_itemDamageType;
    #endregion

    public void Use_Item()
    {

    }
}
