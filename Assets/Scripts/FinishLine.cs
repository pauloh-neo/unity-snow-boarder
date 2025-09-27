using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        float layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex)
        {
            Invoke("ReloadScene", reloadDelay);
        }
    }

    void ReloadScene()
    {
        
        SceneManager.LoadScene(0);
    }
}
