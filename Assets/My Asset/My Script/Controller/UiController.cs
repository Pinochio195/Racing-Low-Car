using Ring;
using UnityEngine;

public class UiController : MonoBehaviour
{
    #region Singleton Pattern

    private static readonly object _lock = new object();
    private static UiController _instance;

    public static UiController Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new GameObject("GameManager").AddComponent<UiController>();
                }
                return _instance;
            }
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    #endregion

    [HeaderTextColor(.6f, 1f, .6f, headerText = "Ui GameObject")]
    public Ui_Manager _uiManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
