using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Colour Theme", menuName = "CustomEnviro/ColourTheme", order = 11)]
public class ColourThemeSO : ScriptableObject
{
    public Color mainColor = new Color(255, 255, 255, 1);
    public Color secondaryColor = new Color(255, 255, 255, 1);
    public Color thirdColor = new Color(255, 255, 255, 1);
    public Color lightColor = new Color(255, 255, 255, 1);
    public Gradient gradientLightColor;
    public Gradient gradientSecondaryColor;
}
