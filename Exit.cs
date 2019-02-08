/* Yannick Renz
 * Cologne Game Lab 
 * BA 1 - Ludic Game 2018/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    private Animator animator;

    public string levelName; //Used to store highscores

    public int nextLevelInt;
    public bool tutorial; //if current Level is a tutorial
    private bool nextLvlLoaded = false;
    private Laurel laurel;
    private Hardy hardy;

    public bool open = false;
    public float openingTime;
    private bool canLeave;

    private float LaurelTimer;
    private float HardyTimer;

    private GameObject buttonPrompt;

    void Start()
    {
        if ((nextLevelInt == 5 || nextLevelInt == 6 || nextLevelInt == 0))
        {
            open = true; // if tutorial level is complete
            switch (nextLevelInt)
            {
                case 5: SceneManager.LoadSceneAsync("PilotBackground", LoadSceneMode.Additive); break;//Loading background music
                case 6: SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(5)); break;
                case 0: SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(6)); break;
            }
        }
      /*  laurel = GameObject.Find("/Playermanager/PlayerLaurel").GetComponent<Laurel>();
        hardy = GameObject.Find("/Playermanager/PlayerHardy").GetComponent<Hardy>(); */
        animator = this.gameObject.GetComponent<Animator>();
        buttonPrompt = GameObject.Find("ElevatorButtonPrompt");
        buttonPrompt.SetActive(false);
        canLeave = false;
    }

    void Update()
    {
        if (Playermanager.isLaurel)
            LaurelTimer += Time.deltaTime;
        else
            HardyTimer += Time.deltaTime;

        if (canLeave && InputManager.LeaveLevelInput()) ExitLevel(Playermanager.isLaurel);
        if (open && !animator.GetBool("isOpening")) animator.SetBool("isOpening", true);
    }

    private void ExitLevel(bool asLaurel)
    {

        UIManager ui = GameObject.Find("UIManager").GetComponent<UIManager>();

        PlayerPrefs.SetFloat("LastScore", ui.score);

        //saveLastChar
        if (asLaurel)
            PlayerPrefs.SetString("LastCharacter", "L");
        else
            PlayerPrefs.SetString("LastCharacter", "H");

        //save Level Time
        PlayerPrefs.SetFloat("LevelTime", Time.timeSinceLevelLoad);

        //save FavChar
        if (HardyTimer > LaurelTimer)
            PlayerPrefs.SetString("FavouriteCharacter", "Hardy");
        else if (LaurelTimer > HardyTimer)
            PlayerPrefs.SetString("FavouriteCharacter", "Laurel");
        else
            PlayerPrefs.SetString("FavouriteCharacter", "Neither!"); //unlikely, though

        //save Level Name
        PlayerPrefs.SetString("LastLevel", levelName);
        PlayerPrefs.SetInt("LastLevelIndex", SceneManager.GetActiveScene().buildIndex);

        if (!tutorial) showKills();

        if(levelName.StartsWith("Episode1")) PlayerPrefs.SetFloat(levelName, 1); //Simply for unlocking the second level.

        PlayerPrefs.Save();


        loadNextScene();
    }

    void loadNextScene() {

        if (nextLevelInt == 5 || nextLevelInt == 6) //if Tutorial
        {
            SceneManager.UnloadSceneAsync(nextLevelInt - 1);
            SceneManager.LoadSceneAsync(nextLevelInt, LoadSceneMode.Additive);
            GameObject.Find("/Main Camera").SendMessage("updatePlayer");
            nextLvlLoaded = true;
        }
        else SceneManager.LoadScene(nextLevelInt);
    }

    void showKills()
    {
        AllEnemyManagers allManagers = new AllEnemyManagers();
        allManagers.saveKills();

        //for Console 
        /* string list = allManagers.createListOfEnemiesKilled(); */
    }
        

    void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.gameObject.name.StartsWith("PlayerHardy") || col.gameObject.name.StartsWith("PlayerLaurel")) && open)
        {
            buttonPrompt.SetActive(true);
            canLeave = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if ((col.gameObject.name.StartsWith("PlayerHardy") || col.gameObject.name.StartsWith("PlayerLaurel")) && open)
        {
            buttonPrompt.SetActive(false);
            canLeave = false;
        }

        //if (col.gameObject.name.StartsWith("PlayerHardy") && open){
        //    buttonPrompt.SetActive(false);
        //} else if (col.gameObject.name.StartsWith("PlayerLaurel") && open) {
        //    buttonPrompt.SetActive(false);
        //}
    }

    //void OnTriggerStay2D(Collider2D col)
    //{

    //    if (col.gameObject.name.StartsWith("PlayerHardy"))
    //    {
    //        Debug.Log("hardy" + Time.timeSinceLevelLoad);
    //        if (Input.GetKey(KeyCode.S) && open) //!hardy.isJumping && 
    //        {
    //            ExitLevel(false);
    //        }
    //    }

    //    if (col.gameObject.name.StartsWith("PlayerLaurel"))
    //    {
    //        Debug.Log("laurel" + Time.timeSinceLevelLoad);
    //        if (Input.GetKey(KeyCode.S) && open) //!laurel.isJumping && 
    //        {
    //            ExitLevel(true);
    //        }
    //    }
    //}
    
}