using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Manager manager = Manager.getInstance();
    public void StartGame()//too buttone play seda zde mishe
    {
        manager.setScore(0);
        SceneManager.LoadScene("MainScene");
    }
}
