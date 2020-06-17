using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class xollisionHandler : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float levelLoadDelay = .8f;
    public GameObject deathFX;

    public  void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
        deathFX.SetActive(true);
        Invoke("ReloadScene", levelLoadDelay);
    }

    public void StartDeathSequence()
    {
        //print("Player Dying");
        SendMessage("OnPlayerDeath");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(1);
    }
}
