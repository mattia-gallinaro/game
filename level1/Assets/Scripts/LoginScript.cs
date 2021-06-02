using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;
using System;
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class LoginScript : MonoBehaviour
{
    public InputField User;
    public InputField Password;
    public string Username;
    public string password;
    public GameObject messaggio_errore;
    public bool LoginEffettuato = false;

    void Start()//appena viene avviato il gioco controlla se esistono i file e nel caso in cui non esistano, crea i file seguendo il percorso specificato dalle stringhe 
    {
        User.characterLimit = 8;
        Password.characterLimit = 8;
        string Player = Application.persistentDataPath + "/Player.txt";
        string Classifica = Application.persistentDataPath + "/Classifica.txt";
        string Login_Save = Application.persistentDataPath + "/Login.txt";
        if (!File.Exists(Login_Save))
        {
            FileStream fs = File.Create(Login_Save);
            fs.Close();
        }
        else if (!File.Exists(Classifica))
        {
            FileStream fs = File.Create(Classifica);
            fs.Close();
        }
        else if (!File.Exists(Player))
        {
            FileStream fs = File.Create(Player);
            fs.Close();
        }
    }

    static string Encrypt(string value)//serve per criptare il dato che gli viene assegnato
    {
        using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
        {
            System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding();
            byte[] data = md5.ComputeHash(utf8.GetBytes(value));
            return Convert.ToBase64String(data);
        }
    }

    public void GoToRegister()//carica la scena con quel nome
    {
        SceneManager.LoadScene("RegisterScene");
    }
    public void GoToLogin()
    {
        SceneManager.LoadScene("Login");
    }
    public void Login()
    {
        Username = User.text;
        password = Password.text;
        string Login_Save = Application.persistentDataPath + "/Login.txt";
        string Player = Application.persistentDataPath + "/Player.txt";
        string[] elenco_giocatori = new string[0];
        string Nome_Utente;
        string Chiave;
        if(User.text == "" || Password.text == "")//controllo se abbia inserito qualcosa negli input field
        {
            messaggio_errore.SetActive(true);
        }
        else
        {
            StreamReader sw = new StreamReader(Login_Save);//serve affinchè si possa leggere i dati dal file specificato nel percorso "Login_file"
            var data = File.ReadAllLines(Login_Save); //memorizzo in data tutti le righe

            Array.Resize(ref elenco_giocatori, elenco_giocatori.Length + data.ToArray().Length);
            //Array.Resize(ref Users, Users.Length + data.ToArray().Length);
            //Array.Resize(ref Passwords, Passwords.Length + data.ToArray().Length);


            for (int i = 0; i < data.ToArray().Length; i++)
            {
                elenco_giocatori[i] = data.ToArray()[i];
                string[] subs = elenco_giocatori[i].Split(',');
                Nome_Utente = subs[0];
                Chiave = subs[1];

                if (Nome_Utente == User.text && Chiave == Encrypt(Password.text))//controllo che le credenziali che inserisce si trovano nel file
                {
                    LoginEffettuato = true;
                }
            }
            sw.Close();
            if (!LoginEffettuato)
            {
                messaggio_errore.SetActive(true);
            }
            else
            {
                StreamWriter player = new StreamWriter(Player, false);
                player.Write(Username);
                player.Close();
                SceneManager.LoadScene("Main Menu");
            }
        }
        
    }
    public void Register()
    {
        string Login_Save = Application.persistentDataPath + "/Login.txt";
        string Player = Application.persistentDataPath + "/Player.txt";

        bool Registrazione_corretta = true;
        if (User.text == "" || Password.text == "")//se non inserisce in uno dei inputfield,mostra il messaggio di errore e non effettua la registrazione
        {
            messaggio_errore.SetActive(true);
        }
        else
        {
            Username = User.text;
            password = Password.text;
            StreamReader sw = new StreamReader(Login_Save);
            var data = File.ReadAllLines(Login_Save); 
            string[] elenco_giocatori = new string[0];
            string Nome_Utente;
            Array.Resize(ref elenco_giocatori, elenco_giocatori.Length + data.ToArray().Length);
            for (int i = 0; i < data.ToArray().Length; i++)
            {
                elenco_giocatori[i] = data.ToArray()[i];
                string[] subs = elenco_giocatori[i].Split(',');
                Nome_Utente = subs[0];

                if (Nome_Utente == User.text)//controllo che le credenziali che inserisce si trovano nel file
                {
                    Registrazione_corretta = false;
                }
            }
            sw.Close();
            if (Registrazione_corretta == true)
            {
                StreamWriter save = new StreamWriter(Login_Save, true);
                save.WriteLine(User.text + "," + Encrypt(Password.text));
                save.Close();
                StreamWriter player = new StreamWriter(Player, false);
                player.Write(Username);
                player.Close();
                SceneManager.LoadScene("Main Menu");
            }
            else
            {
                messaggio_errore.SetActive(true);
            }
        }
    } 
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Pulisci()//controlla che il messaggio di errore sia attivo, nel caso in cui lo sia, quando l'utente modifica gli input field, li resetta ed elimina il messaggio di errore
    {
        if(messaggio_errore.active == true)
        {
            User.text = "";
            Password.text = "";
            messaggio_errore.SetActive(false);
        }
    }
}
