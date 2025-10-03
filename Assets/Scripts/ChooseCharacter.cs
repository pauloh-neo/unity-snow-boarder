using UnityEngine;

public class ChooseCharacter : MonoBehaviour
{
    [SerializeField] SpriteRenderer rex;
    [SerializeField] SpriteRenderer frog;
    [SerializeField] GameObject scoreCanvas;
    void Start()
    {
        BeginGame();
    }

    void BeginGame()
    {
        Time.timeScale = 0;
        scoreCanvas.SetActive(false);
        gameObject.SetActive(true);
    }

    public void ChooseRex()
    {
        rex.enabled = true;
        Time.timeScale = 1;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ChooseFrog()
    {
        frog.enabled = true;
        Time.timeScale = 1;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
    
}
