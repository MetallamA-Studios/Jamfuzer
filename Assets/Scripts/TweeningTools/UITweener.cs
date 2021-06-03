using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UI_ANIMATION_TYPES
{
    Move,
    Scale,
    ScaleX,
    ScaleY,
    Fade,
    Shake
}


public class UITweener : MonoBehaviour
{
    public GameObject GO_objectToAnimate;

    public UI_ANIMATION_TYPES e_animationType;
    public LeanTweenType LTT_easeType;
    public float f_duration;
    public float f_delay;

    public float f_shakeAmount;

    public AnimationCurve AC_animationCurve;

    public bool b_loop;
    public bool b_pingPong;

    public bool b_startPositionOffset;
    public Vector3 V3_from;
    public Vector3 V3_to;

    public bool b_showOnEnable;

    private LTDescr LTD_tweenObject;

    private Vector3 V3_initialPosition;

    private void OnEnable()
    {
        if (b_showOnEnable)
        {
            Show();
        }
    }

    public void Show()
    {
        Handle_Tween();
    }

    public void Handle_Tween()
    {
        if (GO_objectToAnimate == null)
        {
            GO_objectToAnimate = gameObject;
            V3_initialPosition = GO_objectToAnimate.GetComponent<RectTransform>().anchoredPosition;
        }        

        switch (e_animationType)
        {
            case UI_ANIMATION_TYPES.Move:
                Move_Absoloute();
                break;
            case UI_ANIMATION_TYPES.Scale:
                Scale();
                break;
            case UI_ANIMATION_TYPES.ScaleX:
                Scale();
                break;
            case UI_ANIMATION_TYPES.ScaleY:
                Scale();
                break;
            case UI_ANIMATION_TYPES.Fade:
                Fade();
                break;
            case UI_ANIMATION_TYPES.Shake:
                Shake();
                break;
        }

        LTD_tweenObject.setDelay(f_delay);
        LTD_tweenObject.setEase(LTT_easeType);

        if (b_loop)
        {
            LTD_tweenObject.loopCount = int.MaxValue;
        }
        if (b_pingPong)
        {
            LTD_tweenObject.setLoopPingPong();
        }
    }

    public void Fade()
    {
        if (gameObject.GetComponent<CanvasGroup>() == null)
        {
            gameObject.AddComponent<CanvasGroup>();
        }

        if (b_startPositionOffset)
        {
            GO_objectToAnimate.GetComponent<CanvasGroup>().alpha = V3_from.x;
        }

        LTD_tweenObject = LeanTween.alphaCanvas(GO_objectToAnimate.GetComponent<CanvasGroup>(), V3_to.x, f_duration).setEase(AC_animationCurve);
    }

    public void Move_Absoloute()
    {
        GO_objectToAnimate.GetComponent<RectTransform>().anchoredPosition = V3_from;

        LTD_tweenObject = LeanTween.move(GO_objectToAnimate.GetComponent<RectTransform>(), V3_to, f_duration).setEase(AC_animationCurve);
    }

    public void Scale()
    {
        if (b_startPositionOffset)
        {
            GO_objectToAnimate.GetComponent<RectTransform>().localScale = V3_from;
        }

        LTD_tweenObject = LeanTween.scale(GO_objectToAnimate, V3_to, f_duration).setEase(AC_animationCurve);
    }

    public void Shake()
    {
        LTD_tweenObject = LeanTween.moveX(GO_objectToAnimate.GetComponent<RectTransform>(), V3_to.x, f_shakeAmount).setEase(AC_animationCurve).setOnComplete(End_Shake);
    }

    public void End_Shake()
    {
        LTD_tweenObject = LeanTween.move(GO_objectToAnimate.GetComponent<RectTransform>(), V3_initialPosition, f_shakeAmount).setEase(AC_animationCurve);
    }

}
