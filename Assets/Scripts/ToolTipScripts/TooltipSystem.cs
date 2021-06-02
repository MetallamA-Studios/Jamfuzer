using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{
    private static TooltipSystem tts_current;

    public Tooltip tooltip;

    private void Awake()
    {
        tts_current = this;
    }

    private void Start()
    {
        tts_current.tooltip.cg_canvasGroup.alpha = 0;
    }

    public static void Show(string content, string header = "")
    {
        tts_current.tooltip.SetText(content, header);
        tts_current.tooltip.cg_canvasGroup.alpha = 0;
        tts_current.tooltip.gameObject.SetActive(true);
        tts_current.tooltip.cg_canvasGroup.LeanAlpha(1, 0.5f).setEaseInQuart();
    }

    public static void Hide()
    {
        tts_current.tooltip.cg_canvasGroup.LeanAlpha(0, 0.3f).setEaseOutQuart().setOnComplete(tts_current.On_Complete);
    }

    void On_Complete()
    {
        tts_current.tooltip.gameObject.SetActive(false);
    }
}
