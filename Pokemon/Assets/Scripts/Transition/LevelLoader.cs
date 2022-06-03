using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator anim;
    public float transtionTime = 3f;
    public bool inScreen = true;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && inScreen) {
            LoadNextLevel();
        }
    }
    public void LoadNextLevel() {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    //Coroutine to delay and make the animation possible
    IEnumerator LoadLevel(int lvlIndex) {
        //play
        anim.SetTrigger("Start");

        //wait
        yield return new WaitForSeconds(transtionTime);
        //Load Scene
        SceneManager.LoadScene(lvlIndex);
    
    }
}

