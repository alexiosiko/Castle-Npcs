using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    void Awake ()
    {
        instance = this;
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

}
