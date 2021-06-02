using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private GameObject enemy;
    private GameObject enemy1;
    private GameObject enemy2;
    private GameObject enemy3;
    private GameObject enemy4;
    private GameObject player;
    private GameObject enemyultra;
    private GameObject coin;
    public TextMeshProUGUI text;
    public TextMeshProUGUI CounterDeaths;
    public float pos_xe1;
    public float pos_ye1;
    public float pos_xe2;
    public float pos_ye2;
    public float pos_xe3;
    public float pos_ye3;
    public float pos_xe4;
    public float pos_ye4;
    public float pos_xeu;
    public float pos_yeu;
    public float pos_xp;
    public float pos_yp;
    public string utente;


    void Start()/* appena viene avviato il livello, cerca i vari gameobject in base al loro tag, 
                 *salva le loro posizioni iniziali ed ,in seguito*
                 *impone ,il secondo nemico e quelli successivi, come se non esistessero(non fanno nulla e non si possono vedere)*
                 */

    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemy1 = GameObject.FindGameObjectWithTag("Enemy1");
        enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
        enemy3 = GameObject.FindGameObjectWithTag("Enemy3");
        enemy4 = GameObject.FindGameObjectWithTag("Enemy4");
        enemyultra = GameObject.FindWithTag("EnemyObliquo");
        player = GameObject.FindWithTag("Player");
        coin = GameObject.FindWithTag("Collect");
        pos_xe1 = enemy1.transform.position.x;
        pos_ye1 = enemy1.transform.position.y;
        pos_xe2 = enemy2.transform.position.x;
        pos_ye2 = enemy2.transform.position.y;
        pos_xe3 = enemy3.transform.position.x;
        pos_ye3 = enemy3.transform.position.y;
        pos_xe4 = enemy4.transform.position.x;
        pos_ye4 = enemy4.transform.position.y;
        pos_xeu = enemyultra.transform.position.x;
        pos_yeu = enemyultra.transform.position.y;
        pos_xp = player.transform.position.x;
        pos_yp = player.transform.position.y;
        enemy1.SetActive(false);
        enemy2.SetActive(false);
        enemy3.SetActive(false);
        enemy4.SetActive(false);
        enemyultra.SetActive(false);
    }

    void Update()//nel caso in cui l'oggetto obliquo attivo esca dalla mappa o si trovi nelle zone safe, lo riporta alla posizione iniziale grazie alle posizioni salvate in precedenza
    {
        if (enemyultra.transform.position.x > 4f || enemyultra.transform.position.x < -5.21f)
        {
            enemyultra.transform.position = new Vector2(pos_xeu, pos_yeu);
        }
    }
    public void SpawnaOggetto(int n1)//ogni volta che il giocatore raccoglie la coin, stanzia un nuovo nemico rendendolo visibile nella mappa e attivo
    {
        text.text = n1 + "/5";
        if (n1 == 1)
        {
            enemy1.SetActive(true);

        }
        if (n1 == 2)
        {
            enemy2.SetActive(true);

        }
        if (n1 == 3)
        {
            enemy3.SetActive(true);

        }
        if (n1 == 4)
        {
            enemy4.SetActive(true);

        }
        if (n1 == 5)
        {
            enemyultra.SetActive(true);
        }
    }


    public void Reset(int score, int deaths)//serve per resettare il livello, si attiva quando il player incontra anche solo un enemy che sia attivo
                                            //riportando gli oggetti alle posizioni iniziali e rendondili di nuovo invisibili e che non possano fare nulla
    {
        text.text = score.ToString() + "/5";
        CounterDeaths.text = "Deaths :" + deaths.ToString();
        player.transform.position = new Vector2(pos_xp, pos_yp);
        enemy1.transform.position = new Vector2(pos_xe1, pos_ye1);
        enemy1.SetActive(false);
        enemy2.transform.position = new Vector2(pos_xe2, pos_ye2);
        enemy2.SetActive(false);
        enemy3.transform.position = new Vector2(pos_xe3, pos_ye3);
        enemy3.SetActive(false);
        enemy4.transform.position = new Vector2(pos_xe4, pos_ye4);
        enemy4.SetActive(false);
        enemyultra.transform.position = new Vector2(pos_xeu, pos_yeu);
        enemyultra.SetActive(false);
    }
    public void SaveScore(int attempts)
    {
        string File_Player = Application.persistentDataPath + "/Player.txt";
        using (StreamReader sr = File.OpenText(File_Player))
        {
            utente = File.ReadAllText(File_Player);
        }
        Debug.Log(utente);
        string Classifica_file = Application.persistentDataPath + "/Classifica.txt";
        StreamWriter sw = new StreamWriter(Classifica_file, true);
        sw.Write(utente + "," + attempts.ToString());
        sw.Close();
        SceneManager.LoadScene("SelectLevelMenu");
    }
}
    
