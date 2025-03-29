using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToNormalScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ToNormalScene()
    {
        SceneManager.LoadScene(0);
        Destroy(transform.parent.parent.parent.gameObject);
    }
}
