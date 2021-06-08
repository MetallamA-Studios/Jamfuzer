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
    public StyleThemeSO currentStyleTheme;
    public GameObject room;
    public GameObject objects;

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

                    foreach (Transform childOfChildOfChildOfChild in childOfChildOfChild)
                    {
                        switch (childOfChildOfChildOfChild.tag)
                        {
                            case "MainColour":
                                childOfChildOfChildOfChild.GetComponent<SpriteRenderer>().color = currentColourTheme.mainColor;
                                break;

                            case "SecondaryColour":
                                switch (useGradientSecondary)
                                {
                                    case true:
                                        Color randColor = currentColourTheme.gradientSecondaryColor.Evaluate(Random.Range(0f, 1f));
                                        childOfChildOfChildOfChild.GetComponent<SpriteRenderer>().color = randColor;
                                        break;

                                    case false:
                                        childOfChildOfChildOfChild.GetComponent<SpriteRenderer>().color = currentColourTheme.secondaryColor;
                                        break;
                                }
                                break;

                            case "ThirdColour":
                                childOfChildOfChildOfChild.GetComponent<SpriteRenderer>().color = currentColourTheme.thirdColor;
                                break;

                            case "LightColour":
                                switch (useGradientLights)
                                {
                                    case true:
                                        Color randColor = currentColourTheme.gradientLightColor.Evaluate(Random.Range(0f, 1f));
                                        childOfChildOfChildOfChild.GetComponent<SpriteRenderer>().color = randColor;
                                        break;

                                    case false:
                                        childOfChildOfChildOfChild.GetComponent<SpriteRenderer>().color = currentColourTheme.lightColor;
                                        break;
                                }
                                break;
                        }
                    }
                }
            }
        }
    }

    public void ReDecor()
    {
        string targetDecal = currentStyleTheme.decalInt;
        string targetBase = currentStyleTheme.baseStyleTheme;

        var allChildren = objects.GetComponentsInChildren<Transform>(true);
            //Debug.Log(child.gameObject.name);

            switch (targetDecal)
            {
            case "0":
                foreach (Transform child in allChildren)
                {
                    switch (child.name)
                    {
                        case string one when one.Contains("1"):
                            child.gameObject.SetActive(false);
                            break;

                        case string two when two.Contains("2"):
                            child.gameObject.SetActive(false);
                            break;

                        case string three when three.Contains("3"):
                            child.gameObject.SetActive(false);
                            break;
                    }
                }
                break;


            case "1":
                    foreach (Transform child in allChildren)
                    {
                        switch (child.name)
                        {
                            case string one when one.Contains("1"):
                                child.gameObject.SetActive(true);
                                break;

                            case string two when two.Contains("2"):
                                child.gameObject.SetActive(false);
                                break;

                            case string three when three.Contains("3"):
                                child.gameObject.SetActive(false);
                                break;
                        }
                    }
                    break;


                case "2":
                foreach (Transform child in allChildren)
                {
                    switch (child.name)
                    {
                        case string one when one.Contains("1"):
                            child.gameObject.SetActive(false);
                            break;

                        case string two when two.Contains("2"):
                            child.gameObject.SetActive(true);
                            break;

                        case string three when three.Contains("3"):
                            child.gameObject.SetActive(false);
                            break;
                    }
                }
                    break;

                case "3":
                foreach (Transform child in allChildren)
                {
                    switch (child.name)
                    {
                        case string one when one.Contains("1"):
                            child.gameObject.SetActive(false);
                            break;

                        case string two when two.Contains("2"):
                            child.gameObject.SetActive(false);
                            break;

                        case string three when three.Contains("3"):
                            child.gameObject.SetActive(true);
                            break;
                    }
                }
                    break;
            }

        switch (targetBase)
        {
            case "Simple":
                foreach (Transform child in allChildren)
                {
                    switch (child.name)
                    {
                        case string one when one.Contains("Simple"):
                            child.gameObject.SetActive(true);
                            break;

                        case string two when two.Contains("Circular"):
                            child.gameObject.SetActive(false);
                            break;

                        case string three when three.Contains("Deco"):
                            child.gameObject.SetActive(false);
                            break;
                    }
                }
                break;

            case "Circular":
                foreach (Transform child in allChildren)
                {
                    switch (child.name)
                    {
                        case string one when one.Contains("Simple"):
                            child.gameObject.SetActive(false);
                            break;

                        case string two when two.Contains("Circular"):
                            child.gameObject.SetActive(true);
                            break;

                        case string three when three.Contains("Deco"):
                            child.gameObject.SetActive(false);
                            break;
                    }
                }
                break;

            case "Deco":
                foreach (Transform child in allChildren)
                {
                    switch (child.name)
                    {
                        case string one when one.Contains("Simple"):
                            child.gameObject.SetActive(false);
                            break;

                        case string two when two.Contains("Circular"):
                            child.gameObject.SetActive(false);
                            break;

                        case string three when three.Contains("Deco"):
                            child.gameObject.SetActive(true);
                            break;
                    }
                }
                break;
        }

    }
}
