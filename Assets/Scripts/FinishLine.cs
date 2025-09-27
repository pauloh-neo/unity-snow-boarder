using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float reloadDelay = 1f;
    [SerializeField] ParticleSystem finishParticleEffector;
    void OnTriggerEnter2D(Collider2D collision)
    {
        float layerIndex = LayerMask.NameToLayer("Player");

        if (collision.gameObject.layer == layerIndex)
        {
            finishParticleEffector.Play();
            Invoke("ReloadScene", reloadDelay);
        }
    }

    void ReloadScene()
    {
        
        SceneManager.LoadScene(0);
    }
}
