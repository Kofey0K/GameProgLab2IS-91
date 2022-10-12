using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreTrigger : MonoBehaviour
{
    public TMP_Text text;
    private int score = 0;
    private void OnTriggerEnter(Collider capsule)
    {
        if(capsule.CompareTag("Score"))
        {
            score += 1;
            text.text = $"Score: {score}/2";
            capsule.gameObject.SetActive(false);
        }
    }
}
