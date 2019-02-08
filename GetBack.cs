using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetBack : MonoBehaviour
{
    /*This class is used for user navigation in the main menu*/

    public Button backButton;
    public int thisScene;
    private GameObject mainLight;

    void Start()
    {
        Time.timeScale = 1;
        backButton.onClick.AddListener(GettingBack);
        SceneManager.UnloadSceneAsync(14);
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(15));
    }

    void GettingBack()
    {
        SceneManager.LoadScene(14, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(15);
    }
}
