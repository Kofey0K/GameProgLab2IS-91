using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalScript : MonoBehaviour
{
    public TMP_Text text;
    public string destination = "Scene2";
    public string goal = "Score: 2/2"; 
    private void OnTriggerEnter(Collider player)
    {
        if(player.CompareTag("Player") && text.text == goal)
        {
            SceneManager.LoadScene(destination);
        }
    }
}