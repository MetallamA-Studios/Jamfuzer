using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToolTipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private static LTDescr lt_delay;

    public string content;

    [Multiline()]
    public string header;

    public void OnPointerEnter(PointerEventData eventData)
    {
        lt_delay = LeanTween.delayedCall(0.5f, () =>
        {
            TooltipSystem.Show(content, header);
        });
    }

    public void OnMouseEnter()
    {
        lt_delay = LeanTween.delayedCall(0.5f, () =>
        {
            TooltipSystem.Show(content, header);
        });
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.cancel(lt_delay.uniqueId);
        TooltipSystem.Hide();
    }

    public void OnMouseExit()
    {
        LeanTween.cancel(lt_delay.uniqueId);
        TooltipSystem.Hide();
    }
}