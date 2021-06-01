using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_ARMOR_TYPE
{
    Light,
    Medium,
    Heavy
}

[CreateAssetMenu(fileName = "Armor", menuName = "Items/Armor", order = 1)]
public class Armor : ScriptableObject
{
    #region Public Variables
    public E_ARMOR_TYPE e_armorType;

    public Sprite s_armorSprite;

    public int i_defence;

    public int i_evasion;

    public string s_armorDescription;

    public E_DAMAGE_TYPES dt_strongAgainst;

    public E_DAMAGE_TYPES dt_weakAgainst;
    #endregion

    float Flat_Damage_Percentage()
    {
        return i_defence / 10f;
    }

    public float Check_Damage(float _incomingDamage, E_DAMAGE_TYPES _incomingDamageType)
    {
        if(_incomingDamageType == dt_strongAgainst)
        {
            return _incomingDamage - _incomingDamage * (Flat_Damage_Percentage() + 0.15f);
        }
        else if (_incomingDamageType == dt_weakAgainst)
        {
            return _incomingDamage - _incomingDamage * (Flat_Damage_Percentage() - 0.15f);
        }
        else if (_incomingDamageType != dt_strongAgainst || _incomingDamageType != dt_strongAgainst)
        {
            return _incomingDamage - _incomingDamage * Flat_Damage_Percentage();
        }

        return 0;
    }
}
