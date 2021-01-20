using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScene : MonoBehaviour
{



    public void Scene1()
    {
        SceneManager.LoadScene("Jonas");
    }


    public void ExitGame()
    {
        Application.Quit();
    }



}
