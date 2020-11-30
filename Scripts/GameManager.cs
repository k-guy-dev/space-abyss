using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject player;
    public Camera camera;
    public GameObject lostScreen_MoonShot;
    public GameObject lostScreen_Asteroid;
    public GameObject cluster1Won;

    public bool cl1Won = false;
    public bool ls_ms = false;
    public bool ls_as = false;
    float Timer;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float screen_width = Screen.width;
        float screen_height = Screen.height;

        Vector3 player_pos = player.transform.position;

        Vector3 inst_pos1 = new Vector3(Random.Range(-88f,420f),7.1f,player_pos.z);
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            Instantiate(asteroid, inst_pos1, Quaternion.identity);
            Timer = 4f;
        }
        if (ls_ms)
        {
            lostScreen_MoonShot.SetActive(true);
        }
        else if (ls_as)
        {
            lostScreen_Asteroid.SetActive(true);
        }
        else if (cl1Won)
        {
            cluster1Won.SetActive(true);
        }
    }

    public void restart()
    {
        SceneManager.LoadScene("Gameplay");
    }
   
}
