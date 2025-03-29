using System.Collections;
using UnityEngine;

public class FirstPanelController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void StartButtom()
    {
        this.transform.parent.parent.GetChild(1).gameObject.SetActive(true);
        this.transform.parent.gameObject.SetActive(false);
    }
    IEnumerator startTheGame(Level a)
    {
        yield return null;
        switch (a)
        {
            case Level.one:
                UnityEngine.SceneManagement.SceneManager.LoadScene("LevelOne");
                break;
            case Level.two:
                UnityEngine.SceneManagement.SceneManager.LoadScene("LevelTwo");
                break;
            case Level.three:
                UnityEngine.SceneManagement.SceneManager.LoadScene("LevelThree");
                break;
            case Level.four:
                UnityEngine.SceneManagement.SceneManager.LoadScene("LevelFour");
                break;
            case Level.five:
                UnityEngine.SceneManagement.SceneManager.LoadScene("LevelFive");
                break;
        }
    }
    void LevelButtom(Level a)
    {
        StartCoroutine(startTheGame(a));
    }
    public void LevelOne() => LevelButtom(Level.one);
    public void LevelTwo() => LevelButtom(Level.two);
    public void LevelThree() => LevelButtom(Level.three);
    public void LevelFour() => LevelButtom(Level.four);
    public void LevelFive() => LevelButtom(Level.five);
}
public enum Level
{
    one,
    two,
    three,
    four,
    five
}
