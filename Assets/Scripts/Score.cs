using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI score;
    private Manager manager = Manager.getInstance();
    void Start()
    {
        score.text = "score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "score: " + manager.getScore();
    }
}
