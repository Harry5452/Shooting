using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerMovement Player;
    public PoolManager Pool;
    [Header("Player Info")]
    public float health;
    public float maxHealth = 100f;
    public int kills;
    public float gameTime = 0f;
    public float moveSpeed = 5f;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        gameTime += Time.deltaTime; // 게임 시간 증가
        Die();
    }

    public void Die()
    {
        if (health <= 0)
        {
            moveSpeed = 0f;
            SceneManager.LoadScene("GameEnd");
            gameTime = 0f;
        }
    }

    // 씬이 변경될 때 호출되는 이벤트
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 씬이 변경될 때 이벤트 핸들러
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 게임 종료 씬인 경우
        if (scene.name == "GameEnd")
        {
            // 게임 매니저 파괴
            Destroy(gameObject);
        }
    }

    // 씬이 변경될 때 이벤트 핸들러 제거
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
