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
        gameTime += Time.deltaTime; // ���� �ð� ����
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

    // ���� ����� �� ȣ��Ǵ� �̺�Ʈ
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // ���� ����� �� �̺�Ʈ �ڵ鷯
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // ���� ���� ���� ���
        if (scene.name == "GameEnd")
        {
            // ���� �Ŵ��� �ı�
            Destroy(gameObject);
        }
    }

    // ���� ����� �� �̺�Ʈ �ڵ鷯 ����
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
