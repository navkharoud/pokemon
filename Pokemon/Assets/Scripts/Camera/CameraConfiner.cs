using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;


public class CameraConfiner : MonoBehaviour
{
    [SerializeField] AudioClip sceneMusic;
    [SerializeField] AudioClip sfxChange;

    public bool needText;
    public string text;
    public GameObject textobj;
    public Text placeText;
    public PolygonCollider2D GroundLayer2;
    public CinemachineConfiner confiner;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        confiner.m_BoundingShape2D = GroundLayer2;
        confiner.InvalidatePathCache();
        if (sceneMusic != null) {
            AudioManager.Instance.PlayMusic(sceneMusic, true);
        }


        if (needText)
        {
            StartCoroutine(showPlace());
        }
    }
    private IEnumerator showPlace() {
        if (sfxChange!= null) {
            AudioManager.Instance.playSFX(sfxChange);
        }
        
        textobj.SetActive(true);
        placeText.text = text;
        yield return new WaitForSeconds(2f);
        textobj.SetActive(false);
    }
    

}
