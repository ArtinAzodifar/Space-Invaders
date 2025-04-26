using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager
{
    private static Manager instance;
    private bool isPlayerLaserActive = false;
    private bool isInvaderLaserActive = false;
    private int score = 0;

    private Manager() { }

    public static Manager getInstance()
    {
        if (instance == null)
        {
            instance = new Manager();
        }
        return instance;
    }

    public void win()
    {
        SceneManager.LoadScene("WinScene");
    }

    public void loose()
    {
        SceneManager.LoadScene("LooseScene");
    }

    //getters:
    public bool getIsPlayerLaserActive()
    {
        return isPlayerLaserActive;
    }
    public bool getIsInvaderLaserActive()
    {
        return isInvaderLaserActive;
    }
    public int getScore()
    {
        return score;
    }

    //setters:
    public void setPlayerLaserActive(bool b)
    {
        isPlayerLaserActive = b;
    }
    public void setInvaderLaserActive(bool b)
    {
        isInvaderLaserActive = b;
    }
    public void addScore(int score)
    {
        this.score += score;
    }
    public void setScore(int i)
    {
        score = i;
    }
}
