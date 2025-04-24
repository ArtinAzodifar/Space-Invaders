public class Manager
{
    private static Manager instance;
    private bool isPlayerLaserActive = false;
    private bool isInvaderLaserActive = false;

    private Manager() { }

    public static Manager getInstance()
    {
        if (instance == null)
        {
            instance = new Manager();
        }
        return instance;
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

    //setters:
    public void setPlayerLaserActive(bool b)
    {
        isPlayerLaserActive = b;
    }
    public void setInvaderLaserActive(bool b)
    {
        isInvaderLaserActive = b;
    }
}
