using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    public int itemsCollected = 0;

    void Awake()
    {
        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
            itemsCollected = 0;
            scoreText.text = itemsCollected.ToString();
        }
    }

    void Update()
    {
    }

    public void CollectItem()
    {
        itemsCollected++;
        UpdateCollectibleText();
    }

    private void UpdateCollectibleText()
    {
        scoreText.text = itemsCollected.ToString();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Loading1")
        {
            gameObject.SetActive(false);
        }
        else
        {
            if(scene.name == "Level2")
            {
                gameObject.SetActive(true);
            }
            
        }
    }
}
