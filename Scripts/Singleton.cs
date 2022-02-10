using UnityEngine;

/// <summary>
/// Inherit from this base class to create a singleton.
/// e.g. public class MyClassName : Singleton<MyClassName> {}
/// </summary>

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //Check to see if we're about to be destroyed.
    private static bool m_ShuttingDown = false;
    private static object m_lock = new object();
    private static T m_Instance;

    /// <summary>
    /// Access singleton instance through this proriety.
    /// </summary>
    public static T Instance
    {
        get
        {
            if(m_ShuttingDown)
            {
                Debug.LogWarning("[Singleton] Instance'" + typeof(T) +
                    "' already destroyed. Returning null.");
                return null;
            }
            lock (m_lock)
            {
                if(m_Instance == null)
                {
                    //Search for existing instane.
                    m_Instance = (T)FindObjectOfType(typeof(T));

                    //Create new instance if one doesn't already exist.
                    if(m_Instance == null)
                    {
                        //Need to create a new GameObject to attach the singleton to.
                        var singletonObject = new GameObject();
                        m_Instance = singletonObject.AddComponent<T>();
                        singletonObject.name = typeof(T).ToString() + " (Singleton)";

                        //Make instane persistent.
                        DontDestroyOnLoad(singletonObject);
                    }
                }

                return m_Instance;
            }
        }
    }

    private void OnApplicationQuit()
    {
        m_ShuttingDown = true;
    }

    private void OnDestroy()
    {
        m_ShuttingDown = true;
    }

    void Awake()
    {
        m_ShuttingDown = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
