using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject dialogeBox;
    public Text dialogText;
    public string dialgue;
    [SerializeField] AudioClip sceneMusic;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (sceneMusic != null)
            {
                AudioManager.Instance.PlayMusic(sceneMusic, false);
            }

            StartCoroutine(endGame());
           
        }
    }
 
    IEnumerator endGame() {
        
        dialogeBox.SetActive(true);
        dialogText.text = dialgue;


        yield return new WaitForSeconds(2f);

        Application.Quit();


    }
}
