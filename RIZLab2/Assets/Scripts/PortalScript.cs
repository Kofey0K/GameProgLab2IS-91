using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public string destination = "Scene2";
    private void OnTriggerEnter(Collider player)
    {
        if(player.CompareTag("Player"))
        {
            SceneManager.LoadScene(destination);
        }
    }
}