/* Michael Gebhart
 * Cologne Game Lab
 * BA 1 - Ludic Game 2018 / 2019 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour {

    /*The scene's background music is continous for all the scenes appearing after this (title screen), this is the reasons while all the other scenes are loaded in Additive Mode*/

    private bool titleScreen = true;
    private bool mainMenu = false;
    private bool credits = false;
    private bool levelSelection = false;

	void Update () {
        if (Input.anyKey && titleScreen)
        {
            Destroy(GameObject.Find("/Canvas"));
            Destroy(GameObject.Find("Directional Light Title"));
            GameObject.Find("Main Camera Title").SetActive(false);
            titleScreen = false;
            SceneManager.LoadScene(14, LoadSceneMode.Additive);
            mainMenu = true;
        }
	}
}
