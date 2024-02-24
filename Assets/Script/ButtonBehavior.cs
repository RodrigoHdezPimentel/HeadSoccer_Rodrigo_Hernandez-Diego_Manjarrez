using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadGame(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void exit()
    {
        print("Exit!");
        Application.Quit();
    }
}
