/* Michael Gebhart
 * Cologne Game Lab
 * BA 1 - Ludic Game 2018 / 2019 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private Button startGame;
    private Button exitGame;
    private Button credits;

    private bool levelScreen;
    private bool creditsScreen;

    private GameObject mainLight;

    void Start()
    {
        setComponents();
    }
    

    void setComponents()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(14));

        mainLight = GameObject.Find("Directional Light Main");

        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(14));

        startGame = GameObject.Find("/Canvas/Start").GetComponent<Button>();
        startGame.onClick.AddListener(startingGame);

        exitGame = GameObject.Find("/Canvas/Exit").GetComponent<Button>();
        exitGame.onClick.AddListener(exitingGame);

        credits = GameObject.Find("/Canvas/Credits").GetComponent<Button>();
        credits.onClick.AddListener(showCredits);

    }

    void startingGame()
    {
        levelScreen = true;
        SceneManager.LoadScene("Levels", LoadSceneMode.Additive);
    }

    void exitingGame()
    {
        Application.Quit();
    }

    void showCredits()
    {
        creditsScreen = true;
        SceneManager.LoadScene(15, LoadSceneMode.Additive);
    }
}