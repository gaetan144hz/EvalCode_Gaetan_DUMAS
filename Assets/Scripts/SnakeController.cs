using System;
using System.Collections;
using System.Security.Cryptography;
using TreeEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.Serialization;

public class SnakeController : MonoBehaviour
{
    private Vector2 moveInput;
    private Vector2 currentInput;
    
    private bool isAlive = true;
    private bool fruitEaten;

    private int eatenFruits;

    public GameObject tail;
    public Transform newPartPosition;
    public GameObject gameOver;

    private Rigidbody2D rb;

    [SerializeField] private float timeBeforeMove;
    
    private void Start()
    {
        //StartCoroutine(Move());

        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        currentInput = Vector2Int.RoundToInt(moveInput);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            moveInput = context.ReadValue<Vector2>();
            currentInput = Vector2Int.RoundToInt(moveInput);
        }
    }

    public void AddTailPart()
    {
        if (fruitEaten == false)
        {
            return;
        }
        else
        {
            Instantiate(tail, this.newPartPosition.position, Quaternion.identity);
            fruitEaten = false;
        }
    }

    public void EatFruit()
    {
        fruitEaten = true;
        eatenFruits++;
    }

    IEnumerator Move()
    {
        while (isAlive == true)
        {
            var emptySpace = rb.position;
            rb.MovePosition(currentInput + emptySpace);
            AddTailPart();
            yield return new WaitForSeconds(timeBeforeMove);
        }
    }

    #region Die

    private void Die()
    {
        isAlive = false;
        Instantiate(gameOver,transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayZone"))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("tail"))
        {
            Die();
        }
    }

    #endregion
    
}
