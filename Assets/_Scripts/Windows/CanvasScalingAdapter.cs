using UnityEngine;
using UnityEngine.UI;

public class CanvasScalingAdapter : MonoBehaviour
{
    [SerializeField] CanvasScaler m_canvasScaler;



    void OnEnable()
    {
        UpdateService.AddOptimizedUpdate(OptimizedUpdate);
    }

    void OnDisable()
    {
        UpdateService.RemoveOptimizedUpdate(OptimizedUpdate);
    }

    void OptimizedUpdate()
    {
        UpdateWindowScaling();
    }



    void UpdateWindowScaling()
    {
        if(GetCurrentAspectRatio() > 1)
        {
            m_canvasScaler.matchWidthOrHeight = 1;
        }
        else
        {
            if (GetCurrentAspectRatio() > 0.7f)
                m_canvasScaler.matchWidthOrHeight = 0.5f;
            else
                m_canvasScaler.matchWidthOrHeight = 0;
        }
    }

    float GetCurrentAspectRatio()
    {
        return (float)Screen.width / (float)Screen.height;
    }
}