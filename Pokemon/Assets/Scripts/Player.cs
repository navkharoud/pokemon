using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public LayerMask objectLayer;
    public LayerMask grassLayer;

    [SerializeField] private float _speed = 5.0f;
    private bool _isMoving;
    private Vector2 _position;
    private Animator _anim;
    public event Action onEncounter;

    [SerializeField] Inventory _inventoryPrefab;
    private Inventory _inventory;


    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _inventory = Instantiate(_inventoryPrefab);


    }
    private void Start()
    {
        
    }

    public void HandleUpdate()
    {
        //checks if the player is moving or not
        if (!_isMoving) {

            //get the keycodes
            //getAxisRaw will be +- 1 only 
            _position.x = Input.GetAxisRaw("Horizontal");
            _position.y = Input.GetAxisRaw("Vertical");

            //makes thge player move only diagonally
            //Tile based movement instead of everywhere
            if (_position.x!= 0) {
                _position.y = 0;
            }

            //if the player is not at zero moement, 
            //the postion is changed
            if (_position != Vector2.zero) {
                _anim.SetFloat("XDir", _position.x);
                _anim.SetFloat("YDir", _position.y);

                var x = transform.position;
                x.x += _position.x;
                x.y += _position.y;
                if (IsWalkable(x)) {
                    StartCoroutine(Move(x));
                }
                
            }
        }
        _anim.SetBool("isMoving", _isMoving);
    }

    //corutine, used to do something over a period of time 
    //takes the player from start pos to target pos
    IEnumerator Move(Vector3 targetPos) {
        _isMoving = true;
        //checks if there is a difference between the two positions
        while( (targetPos - transform.position).sqrMagnitude >  Mathf.Epsilon){
            transform.position = Vector3.MoveTowards(transform.position, targetPos, _speed* Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        _isMoving = false;

        checkForEncounters();
    }
    private bool IsWalkable(Vector3 targetPos) {
        //checks if there is something/collider withing a circle made by the phyics 2d
        if(Physics2D.OverlapCircle(targetPos, 0.2f, objectLayer) != null){
            return false;
        }
        return true;
    }
    private void checkForEncounters() {
        

        if (Physics2D.OverlapCircle(transform.position, 0.2f, grassLayer) != null)
        {
            //We dont want an encounter everytime the person walks on grass 
            //random around 1-%
            if(UnityEngine.Random.Range(1, 101)<= 10){
                _anim.SetBool("isMoving", false);
                //Debug.Log("Encounter");
                onEncounter();
            }
        }
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PickUp"))
        {
            ItemData hitObject = collision.gameObject.
            GetComponent<Consumable>().Item;
            if (hitObject != null)
            {
                print("Hit: " + hitObject.ObjectName);
                bool shouldDisappear = false;
                switch (hitObject.Type)
                {
                    case ItemData.ItemType.Coin:
                    
                        shouldDisappear = _inventory.AddItem(hitObject);
                        break;
                    case ItemData.ItemType.Pokeballs:
                        shouldDisappear = _inventory.AddItem(hitObject);

                        break;
                    case ItemData.ItemType.Gold:
                        shouldDisappear = _inventory.AddItem(hitObject);

                        break;
                }
                
                    collision.gameObject.SetActive(false);
                //collision.gameObject.SetActive(false);
            }
        }
    }
}
