using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Tilemaps;

[ExecuteInEditMode]
public class ReColourRoomScript : MonoBehaviour
{
    public ColourThemeSO currentColourTheme;
    public GameObject room;

    public bool useGradientLights;
    public bool useGradientSecondary;

    public void ReColour()
    {
        foreach(Transform child in room.transform)
        {

            switch (child.name)
            {
                case string a when a.Contains("Objects"):

                    foreach (Transform childOfChild in child)
                    {
                        switch (childOfChild.name)
                        {
                            case string d when d.Contains("Decal"):

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

                            case string e when e.Contains("Pillar"):

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

                                switch (useGradientLights)
                                {
                                    case true:
                                        Color randColor = currentColourTheme.gradientLightColor.Evaluate(Random.Range(0f, 1f));
                                        childOfChild.Find("Decal").transform.GetComponent<SpriteRenderer>().color = randColor;
                                        break;

                                    case false:
                                        childOfChild.Find("Decal").transform.GetComponent<SpriteRenderer>().color = currentColourTheme.lightColor;
                                        break;
                                }
                                break;

                            case string f when f.Contains("Door"):

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

                                switch (useGradientLights)
                                {
                                    case true:
                                        Color randColor = currentColourTheme.gradientLightColor.Evaluate(Random.Range(0f, 1f));
                                        childOfChild.Find("Decal").transform.GetComponent<SpriteRenderer>().color = randColor;
                                        break;

                                    case false:
                                        childOfChild.Find("Decal").transform.GetComponent<SpriteRenderer>().color = currentColourTheme.lightColor;
                                        break;
                                }
                                break;
                        }
                    }
                    break;

                case string b when b.Contains("Base"):
                    child.GetComponent<Tilemap>().color = currentColourTheme.mainColor;
                    break;

                case string c when c.Contains("Top"):
                    child.GetComponent<Tilemap>().color = currentColourTheme.thirdColor;
                    break;

                case string g when g.Contains("Wall"):
                    child.GetComponent<Tilemap>().color = currentColourTheme.thirdColor;
                    break;

            }
        }
    }
}
