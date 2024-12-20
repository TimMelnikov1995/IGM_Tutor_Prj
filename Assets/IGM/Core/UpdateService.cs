using System.Collections;
using UnityEngine;

public class UpdateService : MonoBehaviour
{
    #region Singelton
    private static UpdateService _instance;
    public static UpdateService Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<UpdateService>();

            return _instance;
        }
    }
    #endregion

    [SerializeField] float m_optimizedUpdateTime = 0.1f;

    public delegate void updateDelegate();
    updateDelegate UpdateDelegate;

    public delegate void optimizedUpdateDelegate();
    optimizedUpdateDelegate OptimizedUpdateDelegate;

    void Start()
    {
        StartCoroutine(OptimizedUpdate());
    }

    void Update()
    {
        UpdateDelegate?.Invoke();
    }



    IEnumerator OptimizedUpdate()
    {
        yield return new WaitForSeconds(m_optimizedUpdateTime);

        OptimizedUpdateDelegate?.Invoke();

        StartCoroutine(OptimizedUpdate());
    }

    public static void startCoroutine(IEnumerator enumerator)
    {
        Instance.StartCoroutine(enumerator);
    }

    public static void stopCoroutine(IEnumerator enumerator)
    {
        Instance.StopCoroutine(enumerator);
    }



    public static void AddUpdate(updateDelegate method)
    {
        if (Instance != null)
            Instance.UpdateDelegate += method;
        else
            Debug.LogError("No SingleUpdate in scene");
    }

    public static void RemoveUpdate(updateDelegate method)
    {
        if (Instance != null)
            Instance.UpdateDelegate -= method;
        //else
            //Debug.LogError("No SingleUpdate in scene");
    }
    public static void AddOptimizedUpdate(optimizedUpdateDelegate method)
    {
        if (Instance != null)
            Instance.OptimizedUpdateDelegate += method;
        else
            Debug.LogError("No SingleUpdate in scene");
    }

    public static void RemoveOptimizedUpdate(optimizedUpdateDelegate method)
    {
        if (Instance != null)
            Instance.OptimizedUpdateDelegate -= method;
        else
            Debug.LogError("No SingleUpdate in scene");
    }
}