using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float MoveSpeed = 3f;//velocità che nel corso della partita cambia
    public Vector3 pos;
    public float x_start;
    public float y_start;
    void Start()
    {
        MoveSpeed = RandomSpeed();
        pos = transform.position;
        x_start = pos.x;
        y_start = pos.y;
    }
    
    public bool moveUp;
    public bool moveLeft;

    // Update is called once per frame
    void Update()//in base al caso delle variabili booleane, l'oggetto obliquo si muove in quella direzione, 
    {
        pos = transform.position;
        if (moveUp && moveLeft)
        {
            Vector3 temp = transform.position;
            temp.x += MoveSpeed * Time.deltaTime;
            temp.y += MoveSpeed * Time.deltaTime;
            transform.position = temp;
        }
        if (!moveUp && moveLeft)
        {
            Vector3 temp = transform.position;
            temp.x += MoveSpeed * Time.deltaTime;
            temp.y -= MoveSpeed * Time.deltaTime;
            transform.position = temp;
        }
        if (!moveUp && !moveLeft)
        {
            Vector3 temp = transform.position;
            temp.x -= MoveSpeed * Time.deltaTime;
            temp.y -= MoveSpeed * Time.deltaTime;
            transform.position = temp;
        }
        if (moveUp && !moveLeft)
        {
            Vector3 temp = transform.position;
            temp.x -= MoveSpeed * Time.deltaTime;
            temp.y += MoveSpeed * Time.deltaTime;
            transform.position = temp;
        }
        if (pos.x > -4.3f && pos.x < -3.34f && pos.y < -1.49f)
        {
            moveUp = !moveUp;
            MoveSpeed = RandomSpeed();
        }
       
    }

    static float RandomSpeed()//per cambiare la velocità del enemy randomicamente
    {
        float velocity = 0f;
        velocity = Random.Range(1f, 6f);
        return velocity;
    }

    void OnTriggerEnter2D(Collider2D collisione)//per quando il nemico obliquo colpisce uno dei muri ci sono due casi:
                                                //se colpisce un muro orizzontale, cambia la direzione orizzontale verso cui si muove
                                                //se colpisce un muro verticale, cambia la direzione verticale verso cui si muove
    {
        if(collisione.tag == "Change x")
        {
            moveLeft = !moveLeft;
            MoveSpeed = RandomSpeed();
        }
        else if(collisione.tag == "Change y")
        {
            moveUp = !moveUp;
            MoveSpeed = RandomSpeed();
        }
        
    }
}
