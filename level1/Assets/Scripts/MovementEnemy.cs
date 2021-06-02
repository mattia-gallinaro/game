using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    //per gli enemy che si muovono in orizzonatale 
    private float MoveSpeed = 0f;
    public bool moveRight;

    void Update()//viene richiamata per ogni frame
                 //in base al valore della variabile booleana
                 //si muove costantemente nel tempo verso quella direzione
    {
        if (moveRight)
        {
            Vector3 temp = transform.position;
            temp.x += MoveSpeed * Time.deltaTime;
            transform.position = temp;
        }
        else
        {
            Vector3 temp = transform.position;
            temp.x -= MoveSpeed * Time.deltaTime;
            transform.position = temp;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)//verifica se i nemici collidono con i muri e cambia il valore della variabile booleana
    {
        if(collision.tag == "Change x")
        {
            moveRight = !moveRight;
        }
    }
}
