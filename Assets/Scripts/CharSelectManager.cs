using UnityEngine;

public class CharSelectManager : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject dinoSprite;
    [SerializeField] GameObject frogSprite;
    void Start()
    {
        Time.timeScale = 0;

    }

    void BeginGame()
    {
        Time.timeScale = 1;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void selectDino()
    {
        dinoSprite.SetActive(true);
        BeginGame();
    }

    public void selectFrog()
    {
        frogSprite.SetActive(true);
        BeginGame();
    }


}
