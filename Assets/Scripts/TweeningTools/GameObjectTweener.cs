using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectTweener : MonoBehaviour
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

    public Color C_fromColor;
    public Color C_toColor;

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
            V3_initialPosition = GO_objectToAnimate.GetComponent<Transform>().position;
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
        if (b_startPositionOffset)
        {
            LTD_tweenObject = LeanTween.color(GO_objectToAnimate, C_fromColor, 0f);
        }

        LTD_tweenObject = LeanTween.color(GO_objectToAnimate, C_toColor, f_duration).setEase(AC_animationCurve);
    }

    public void Move_Absoloute()
    {
        GO_objectToAnimate.transform.position = V3_from;

        LTD_tweenObject = LeanTween.move(GO_objectToAnimate, V3_to, f_duration).setEase(AC_animationCurve);
    }

    public void Scale()
    {
        if (b_startPositionOffset)
        {
            GO_objectToAnimate.transform.localScale = V3_from;
        }

        LTD_tweenObject = LeanTween.scale(GO_objectToAnimate, V3_to, f_duration).setEase(AC_animationCurve);
    }

    public void Shake()
    {
        LTD_tweenObject = LeanTween.moveX(GO_objectToAnimate, V3_to.x, f_shakeAmount).setEase(AC_animationCurve).setOnComplete(End_Shake);
    }

    public void End_Shake()
    {
        LTD_tweenObject = LeanTween.move(GO_objectToAnimate, V3_initialPosition, f_shakeAmount).setEase(AC_animationCurve);
    }
}
