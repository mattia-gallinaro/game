using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private float MoveSpeed = 2f;
    public GameController m_yesyesScript;//per richiamare funzioni dallo script GameController
    public int score = 0;
    public int CoinValue = 1;
    public int deaths = 0;

    
    void FixedUpdate()//ad ogni frame il programma verifica quale tasto preme o mantiene premuto e muove l'oggeto in quella direzione
    {
        Vector2 move = transform.position;
        if (Input.GetAxis("Horizontal") > 0 || Input.GetKey("d"))
        {
            move.x += MoveSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis("Horizontal") < 0 || Input.GetKey("a"))
        {
            move.x -= MoveSpeed * Time.deltaTime;
        }
        if (Input.GetAxis("Vertical") > 0 || Input.GetKey("w"))
        {
            move.y += MoveSpeed * Time.deltaTime;
        }
        else if (Input.GetAxis("Vertical") < 0 || Input.GetKey("s"))
        {
            move.y -= MoveSpeed * Time.deltaTime;
        }
        transform.position = move;
    }
    private void OnTriggerEnter2D(Collider2D yesyes)//verifica quando scontra qualcosa nel livello
    {
        if(yesyes.gameObject.CompareTag("Collect"))//quando raccoglie la coin
        {
            score += CoinValue;
            if (score <= 5)
            {
                Instantiate(yesyes.gameObject, new Vector2(Random.Range(-3.67f, 3.67f), Random.Range(-2f, 2f)), Quaternion.identity);
                Destroy(yesyes.gameObject);
                m_yesyesScript.SpawnaOggetto(score);
                
            }
            else
            {
                Instantiate(yesyes.gameObject, new Vector2(Random.Range(-3.67f, 3.67f), Random.Range(-2f, 2f)), Quaternion.identity);
                Destroy(yesyes.gameObject);
                m_yesyesScript.SpawnaOggetto(score);
                score -= CoinValue;
            }
        }
        if(yesyes.tag == "Enemy" || yesyes.tag == "Enemy1" || yesyes.tag == "Enemy2" || yesyes.tag == "Enemy3" || yesyes.tag == "Enemy4" || yesyes.tag == "EnemyObliquo") //quando colpisce uno dei nemici quando sono attivi
        {
            score = 0;
            deaths++;
            m_yesyesScript.Reset(score, deaths);
        }
        if(yesyes.tag == "Goal")//quando raggiunge la fine del livello
        {
            if (score >= 5)
            {
                m_yesyesScript.SaveScore(deaths);
            }
        }
    }
    
}
