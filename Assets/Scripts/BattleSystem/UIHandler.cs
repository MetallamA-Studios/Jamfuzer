using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIHandler : MonoBehaviour
{
    public Image playerHealth;
    public Image playerXP;

    public Image playerArmor;
    public Image playerPrimaryWeapon;
    public Image playerSecondaryWeapon;

    public GameObject primaryWeaponSelectedUI;
    public GameObject secondaryWeaponSelectedUI;

    public void UpdatePrimaryWeaponIcon(Sprite weaponIcon)
    {
        playerPrimaryWeapon.sprite = weaponIcon;
    }

    public void UpdateSecondaryWeaponIcon(Sprite weaponIcon)
    {
        playerSecondaryWeapon.sprite = weaponIcon;
    }

    public void UpdatePlayerArmor(Sprite armorIcon)
    {
        playerArmor.sprite = armorIcon;
    }

    public void UpdatePlayerHP(int playerHP, int playerMaxHealth)
    {
        playerHealth.fillAmount = LeanTween.linear(1, 0, NormalizeHealth(playerHP, playerMaxHealth, 0));
    }

    float NormalizeHealth(int newHealth, int playerMaxHealth, int playerMinHealth)
    {
        return (newHealth - playerMinHealth) / (playerMaxHealth - playerMinHealth);
    }
}
