using Ring;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton Pattern

    private static readonly object _lock = new object();
    private static GameManager _instance;

    public static GameManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new GameObject("GameManager").AddComponent<GameManager>();
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
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    #endregion

    [HeaderTextColor(.6f, 1f, .6f, headerText = "Ui GameObject")]
    public Game_Manager _directionCar;
    [HeaderTextColor(.6f, 1f, .6f, headerText = "Change GamePlay")]
    public Game_Play _gamePlay;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
