using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    public int itemsCollected = 0;
    float sirvepls;

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
        if (scene.name == "MainMenu" ||  scene.name == "Instructions" ||scene.name == "FirstCinematic" || scene.name == "Loading1" 
            || scene.name == "TransitionLegs" || scene.name == "Loading2" || scene.name == "TransitionNoHead" 
            || scene.name == "Loading3" || scene.name == "TransitionBodyComplete" || scene.name == "Loading4"
            || scene.name == "LastCinematic" || scene.name == "TheEnd")
        {
            gameObject.SetActive(false);
        }
        else
        {
            if(scene.name == "Level1" || scene.name == "Level2" || scene.name == "Level3") 
            {
                gameObject.SetActive(true);
            }
            
        }
    }
}
