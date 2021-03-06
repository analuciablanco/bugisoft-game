﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public float speed = 10f;
    public bool completedFirstPuzzle = false;
    public bool completedSecondPuzzle = false;
    public bool completedThirdPuzzle = false;
    public string scenename;
    private Animator salida;

    void Start()
    {
        salida = GetComponent<Animator>();
    }
    public void NewGame()
    {
        StartCoroutine(Trans());
    }

    IEnumerator Trans()
    {
        salida.SetTrigger("entrada");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Menuglitch");
    }
    
    public void LoadGame(){
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            GameStateData data = SaveSystem.LoadGameState();

            SceneManager.LoadScene(data.scenename);
            completedFirstPuzzle = data.completedFirstPuzzle;
            completedSecondPuzzle = data.completedSecondPuzzle;
            completedThirdPuzzle = data.completedThirdPuzzle;
        } else {
            Debug.Log("Save file not found in" + path);
        }
    }
    public void Exit(){
        Debug.Log("Cierra pantalla");
        Application.Quit();
    }
}
