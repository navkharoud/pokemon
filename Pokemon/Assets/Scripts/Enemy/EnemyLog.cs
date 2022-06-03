using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLog : Enemy
{
    public Transform target;
    public float chaseRad;
    public float attackRad;
    
    public Animator anim;

    public GameObject dialogeBox;
    public Text dialogText;
    private string dialgue = "YOU DIED";


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        //dialogeBox = GameObject.Find("DialogBox");
        //dialogText = dialogeBox.GetComponent<Text>();


    }

    private void Update()
    {
        CheckDistance();
    }

    void CheckDistance() {
        if (Vector3.Distance(target.position, this.transform.position) <= chaseRad && Vector3.Distance(target.position, this.transform.position) > attackRad)
        {

            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            anim.SetBool("wakeUp", true);

        }



    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            Debug.Log("Touched");
            StartCoroutine(DestroyPlayer());



        }
    }
    IEnumerator DestroyPlayer() {
        dialogeBox.SetActive(true);
        dialogText.text = dialgue;

        yield return new WaitForSeconds(1f);
        Destroy(GameObject.FindGameObjectWithTag("Player"));
    }



    }
