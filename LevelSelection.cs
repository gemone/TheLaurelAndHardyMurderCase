/* Yannick Renz, Michael Gebhart
 * Cologne Game Lab
 * BA 1 - Ludic Game 2018 / 2019 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelection : MonoBehaviour {

    /*
     * Here is a list of all the level names, which are used to store high scores and determine whether they are unlocked:
     * 
     * Level 1: Episode1_v2
     * Level 2: Episode2_v2
     * Level 3: Episode3_v2
     * Level 4: Episode4_v2
     * Level 5: Episode5_v2
     * Level 6: Episode6_v2
     * Level 7: Episode7_v2
     * 
     * The version can be changed to reset the highscores without having to change the level name.
     * For each "loadEpisode" function, enter the previous level's name in the if condition.
     * (- Yannick)
     */


void Start()
{
        SceneManager.UnloadSceneAsync(14);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));

        if (!(PlayerPrefs.GetFloat("Episode1_v2", 0) > 0)) GameObject.Find("Ep. 2").SetActive(false);
        if (!(PlayerPrefs.GetFloat("Episode2_v2", 0) > 0)) GameObject.Find("Ep. 3").SetActive(false);
        if (!(PlayerPrefs.GetFloat("Episode3_v2", 0) > 0)) GameObject.Find("Ep. 4").SetActive(false);
        if (!(PlayerPrefs.GetFloat("Episode4_v2", 0) > 0)) GameObject.Find("Ep. 5").SetActive(false);
        if (!(PlayerPrefs.GetFloat("Episode5_v2", 0) > 0)) GameObject.Find("Ep. 6").SetActive(false);
        if (!(PlayerPrefs.GetFloat("Episode6_v2", 0) > 0)) GameObject.Find("Ep. 7").SetActive(false);
}
   

    void goingBack()
    {
        SceneManager.LoadScene(14, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(1);
    }

    void loadEpisode1() //Pilot
    {
        SceneManager.LoadScene(4);
    }

    void loadEpisode2()
    {
            SceneManager.LoadScene(7);
    }

    void loadEpisode3()
    {
            SceneManager.LoadScene(8);
    }

    void loadEpisode4()
    {
            SceneManager.LoadScene(9);
    }

    void loadEpisode5()
    {
            SceneManager.LoadScene(10);
    }

    void loadEpisode6()
    {
            SceneManager.LoadScene(11);
    }

    void loadEpisode7()
    {
            SceneManager.LoadScene(12);
    }
}
