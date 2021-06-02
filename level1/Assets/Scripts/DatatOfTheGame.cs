using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;
using System.Linq;

public struct Players
{
    public string PlayerName;
    public string scoreLevel1;
}
public class DatatOfTheGame
{
    void Classifica()
    {
        string Classifica_file = Application.persistentDataPath + "/Classifica.txt";
        List<Players> giocatori = new List<Players>();
        StreamReader sw = File.OpenText(Classifica_file);
        var giocatorifile = File.ReadAllLines(Classifica_file);
        sw.Close();
        
        for(int i = 0; i < giocatorifile.ToArray().Length; i++)
        {
            Players plr;
            string[] giocatore = giocatorifile.ToArray()[i].Split(',');
            plr.PlayerName = giocatore[0];
            plr.scoreLevel1 = giocatore[1];
            giocatori.Add(plr);
        }
        for(int c = 0; c < giocatori.ToArray().Length; c++)
        {
            Debug.Log(giocatori[c].PlayerName);
            Debug.Log(giocatori[c].scoreLevel1);
        }
    }
}
