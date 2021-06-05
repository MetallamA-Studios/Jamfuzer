using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Decal Theme", menuName = "CustomEnviro/DecalTheme", order = 12)]
public class DecalThemeSO : ScriptableObject
{
    public Sprite largeDoorPattern;
    public Sprite smallDoorPattern;
    public Sprite bigPillarPattern;
    public Sprite smallPillarPattern;
    public Sprite[] floorPatterns;
}
