using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public void Button_Play()
    {
        SceneManager.LoadScene("TestScene");
    }
    public void Button_Quit()
    {
        Application.Quit();
    }
}
