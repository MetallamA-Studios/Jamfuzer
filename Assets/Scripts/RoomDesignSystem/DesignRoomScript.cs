using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Tilemaps;
//using UnityEngine.Experimental.Rendering.Universal;

[ExecuteInEditMode]
public class DesignRoomScript : MonoBehaviour
{
    public ColourThemeSO currentColourTheme;
    public DecalThemeSO currentDecalTheme;
    public GameObject room;

    public bool useGradientLights;
    public bool useGradientSecondary;

    public void ReColour()
    {
        foreach(Transform child in room.transform)
        {
            switch (child.tag)
            {
                case "MainColour":
                    child.GetComponent<Tilemap>().color = currentColourTheme.mainColor;
                    break;

                case "SecondaryColour":
                    switch (useGradientSecondary)
                    {
                        case true:
                            Color randColor = currentColourTheme.gradientSecondaryColor.Evaluate(Random.Range(0f, 1f));
                            child.GetComponent<Tilemap>().color = randColor;
                            break;

                        case false:
                            child.GetComponent<Tilemap>().color = currentColourTheme.secondaryColor;
                            break;
                    }
                    break;

                case "ThirdColour":
                    child.GetComponent<Tilemap>().color = currentColourTheme.thirdColor;
                    break;

                case "LightColour":
                    switch (useGradientLights)
                    {
                        case true:
                            Color randColor = currentColourTheme.gradientLightColor.Evaluate(Random.Range(0f, 1f));
                            child.GetComponent<Tilemap>().color = randColor;
                            break;

                        case false:
                            child.GetComponent<Tilemap>().color = currentColourTheme.lightColor;
                            break;
                    }
                    break;
            }

            foreach (Transform childOfChild in child)
            {
                switch (childOfChild.tag)
                {
                    case "MainColour":
                        childOfChild.GetComponent<SpriteRenderer>().color = currentColourTheme.mainColor;
                        break;

                    case "SecondaryColour":
                        switch (useGradientSecondary)
                        {
                            case true:
                                Color randColor = currentColourTheme.gradientSecondaryColor.Evaluate(Random.Range(0f, 1f));
                                childOfChild.GetComponent<SpriteRenderer>().color = randColor;
                                break;

                            case false:
                                childOfChild.GetComponent<SpriteRenderer>().color = currentColourTheme.secondaryColor;
                                break;
                        }
                        break;

                    case "ThirdColour":
                        childOfChild.GetComponent<SpriteRenderer>().color = currentColourTheme.thirdColor;
                        break;

                    case "LightColour":
                        switch (useGradientLights)
                        {
                            case true:
                                Color randColor = currentColourTheme.gradientLightColor.Evaluate(Random.Range(0f, 1f));
                                childOfChild.GetComponent<SpriteRenderer>().color = randColor;
                                break;

                            case false:
                                childOfChild.GetComponent<SpriteRenderer>().color = currentColourTheme.lightColor;
                                break;
                        }
                        break;
                }

                foreach (Transform childOfChildOfChild in childOfChild)
                {
                    switch (childOfChildOfChild.tag)
                    {
                        case "MainColour":
                            childOfChildOfChild.GetComponent<SpriteRenderer>().color = currentColourTheme.mainColor;
                            break;

                        case "SecondaryColour":
                            switch (useGradientSecondary)
                            {
                                case true:
                                    Color randColor = currentColourTheme.gradientSecondaryColor.Evaluate(Random.Range(0f, 1f));
                                    childOfChildOfChild.GetComponent<SpriteRenderer>().color = randColor;
                                    break;

                                case false:
                                    childOfChildOfChild.GetComponent<SpriteRenderer>().color = currentColourTheme.secondaryColor;
                                    break;
                            }
                            break;

                        case "ThirdColour":
                            childOfChildOfChild.GetComponent<SpriteRenderer>().color = currentColourTheme.thirdColor;
                            break;

                        case "LightColour":
                            switch (useGradientLights)
                            {
                                case true:
                                    Color randColor = currentColourTheme.gradientLightColor.Evaluate(Random.Range(0f, 1f));
                                    childOfChildOfChild.GetComponent<SpriteRenderer>().color = randColor;
                                    break;

                                case false:
                                    childOfChildOfChild.GetComponent<SpriteRenderer>().color = currentColourTheme.lightColor;
                                    break;
                            }
                            break;
                    }
                }
            }
        }
    }

    public void ReDecor()
    {
        foreach (Transform child in room.transform)
        {

            switch (child.name)
            {
                case string a when a.Contains("Objects"):

                    foreach (Transform childOfChild in child)
                    {
                        switch (childOfChild.name)
                        {
                            case string d when d.Contains("Decal"):

                                switch (childOfChild.name)
                                {
                                    case string i when i.Contains("Under"):

                                        switch (childOfChild.name)
                                        {
                                            case string j when j.Contains("1"):
                                                childOfChild.GetComponent<SpriteRenderer>().sprite = currentDecalTheme.floorPatterns[4];
                                                //childOfChild.GetComponent<Light2D>().lightCookieSprite = currentDecalTheme.floorPatterns[4];
                                                break;
                                            case string k when k.Contains("2"):
                                                childOfChild.GetComponent<SpriteRenderer>().sprite = currentDecalTheme.floorPatterns[5];
                                                //childOfChild.GetComponent<Light2D>().lightCookieSprite = currentDecalTheme.floorPatterns[5];
                                                break;
                                            case string l when l.Contains("3"):
                                                childOfChild.GetComponent<SpriteRenderer>().sprite = currentDecalTheme.floorPatterns[6];
                                                //childOfChild.GetComponent<Light2D>().lightCookieSprite = currentDecalTheme.floorPatterns[6];
                                                break;
                                            case string m when m.Contains("4"):
                                                childOfChild.GetComponent<SpriteRenderer>().sprite = currentDecalTheme.floorPatterns[7];
                                                //childOfChild.GetComponent<Light2D>().lightCookieSprite = currentDecalTheme.floorPatterns[7];
                                                break;
                                            case string n when n.Contains("5"):
                                                childOfChild.GetComponent<SpriteRenderer>().sprite = currentDecalTheme.floorPatterns[8];
                                                //childOfChild.GetComponent<Light2D>().lightCookieSprite = currentDecalTheme.floorPatterns[8];
                                                break;
                                            case string o when o.Contains("6"):
                                                childOfChild.GetComponent<SpriteRenderer>().sprite = currentDecalTheme.floorPatterns[9];
                                                //childOfChild.GetComponent<Light2D>().lightCookieSprite = currentDecalTheme.floorPatterns[9];

                                                break;
                                        }

                                        break;

                                    case string p when p.Contains("Top"):

                                        switch (childOfChild.name)
                                        {
                                            case string q when q.Contains("1"):
                                                childOfChild.GetComponent<SpriteRenderer>().sprite = currentDecalTheme.floorPatterns[0];
                                                //childOfChild.GetComponent<Light2D>().lightCookieSprite = currentDecalTheme.floorPatterns[0];
                                                break;
                                            case string r when r.Contains("2"):
                                                childOfChild.GetComponent<SpriteRenderer>().sprite = currentDecalTheme.floorPatterns[1];
                                                //childOfChild.GetComponent<Light2D>().lightCookieSprite = currentDecalTheme.floorPatterns[1];
                                                break;
                                            case string s when s.Contains("3"):
                                                childOfChild.GetComponent<SpriteRenderer>().sprite = currentDecalTheme.floorPatterns[2];
                                                //childOfChild.GetComponent<Light2D>().lightCookieSprite = currentDecalTheme.floorPatterns[2];
                                                break;
                                            case string t when t.Contains("4"):
                                                childOfChild.GetComponent<SpriteRenderer>().sprite = currentDecalTheme.floorPatterns[3];
                                                //childOfChild.GetComponent<Light2D>().lightCookieSprite = currentDecalTheme.floorPatterns[3];
                                                break;
                                        }

                                        break;
                                }
                                break;

                            case string e when e.Contains("Pillar"):

                                switch (childOfChild.name)
                                {
                                    case string u when u.Contains("Big"):
                                        childOfChild.Find("Decal").transform.GetComponent<SpriteRenderer>().sprite = currentDecalTheme.bigPillarPattern;
                                        //childOfChild.Find("Decal").transform.GetComponent<Light2D>().lightCookieSprite = currentDecalTheme.bigPillarPattern;
                                        break;

                                    case string v when v.Contains("Small"):
                                        childOfChild.Find("Decal").transform.GetComponent<SpriteRenderer>().sprite = currentDecalTheme.smallPillarPattern;
                                        //childOfChild.Find("Decal").transform.GetComponent<Light2D>().lightCookieSprite = currentDecalTheme.smallPillarPattern;
                                        break;
                                }

                                break;

                            case string f when f.Contains("Door"):

                                switch (childOfChild.name)
                                {
                                    case string w when w.Contains("Large"):
                                        childOfChild.Find("Decal").transform.GetComponent<SpriteRenderer>().sprite = currentDecalTheme.largeDoorPattern;
                                        //childOfChild.Find("Decal").transform.GetComponent<Light2D>().lightCookieSprite = currentDecalTheme.largeDoorPattern;
                                        break;

                                    case string x when x.Contains("Small"):
                                        childOfChild.Find("Decal").transform.GetComponent<SpriteRenderer>().sprite = currentDecalTheme.smallDoorPattern;
                                        //childOfChild.Find("Decal").transform.GetComponent<Light2D>().lightCookieSprite = currentDecalTheme.smallDoorPattern;
                                        break;
                                }
                                break;
                        }
                    }
                    break;

            }
        }
    }
}
