using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Sign : MonoBehaviour
{
    public GameObject dialogeBox;
    public Text dialogText;
    public string dialgue;
    public bool isActive;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isActive) {
            if (dialogeBox.activeInHierarchy)
            {
                dialogeBox.SetActive(false);
            }
            else {
                dialogeBox.SetActive(true);
                dialogText.text = dialgue;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            isActive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            isActive = false;
            dialogeBox.SetActive(false);
        }
    }
}
