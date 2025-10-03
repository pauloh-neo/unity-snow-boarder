using UnityEngine;

public class ChooseCharacter : MonoBehaviour
{
    [SerializeField] SpriteRenderer rex;
    [SerializeField] SpriteRenderer frog;
    [SerializeField] Canvas scoreCanvas;
    [SerializeField] Canvas chooseCharCanvas;
    void Start()
    {
        Time.timeScale = 0;
        chooseCharCanvas.enabled = true;
        scoreCanvas.enabled = false;
    }


    public void ChooseRex()
    {
        rex.enabled = true;
        Time.timeScale = 1;
        chooseCharCanvas.enabled = false;
        scoreCanvas.enabled = true;
    }

    public void ChooseFrog()
    {
        frog.enabled = true;
        Time.timeScale = 1;
        chooseCharCanvas.enabled = false;
        scoreCanvas.enabled = true;
    }
    
}
