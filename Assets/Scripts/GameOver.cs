using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    private Manager manager = Manager.getInstance();

    private void Awake()
    {
        score.text = "Score: " + manager.getScore();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}