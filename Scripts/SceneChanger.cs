using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
  public void play()
    {
        SceneManager.LoadScene("Story");
    }

    public void instruction()
    {
        SceneManager.LoadScene("Instruction");
    }
    public void gamePlay()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
