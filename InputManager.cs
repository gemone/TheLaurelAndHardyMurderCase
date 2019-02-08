/* Michael Gebhart
 * Cologne Game Lab 
 * BA 1 - Ludic Game 2018/2019
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    /* This classed will always be called, if input for other classes's functions are needed */

    public static bool playerAlive;

    public static bool JumpInput()
    {
        if (playerAlive && 
            (Input.GetKeyDown(KeyCode.Space) 
            || Input.GetKeyDown(KeyCode.W) 
            || Input.GetKeyDown(KeyCode.UpArrow) 
            || Input.GetButtonDown("XBoxA")))
            return true;
        else 
            return false;
    }

    static bool rightTriggerDown;

    public static bool AttackInput()
    {
        if (playerAlive &&
            (Input.GetKeyDown(KeyCode.E)
            || Input.GetKeyDown(KeyCode.F)
            || Input.GetMouseButtonDown(0)
            || Input.GetKeyDown(KeyCode.KeypadEnter)
            || Input.GetButtonDown("XBoxX")))
            return true;
        else if (!rightTriggerDown && Input.GetAxis("XBoxRightTrigger") > 0)
        {
            rightTriggerDown = true;
            return true;
        }
        else if (Input.GetAxis("XBoxRightTrigger") == 0)
        {
            rightTriggerDown = false;
            return false;
        }
        else
            return false;
    }

    static bool leftTriggerDown;

    public static bool ShapeshiftInput()
    {
        if (playerAlive &&
            (Input.GetKeyDown(KeyCode.Q)
            || Input.GetButtonDown("XBoxB")))
            return true;
        //creating a DownFunction for Xbox Triggers
        else if (!leftTriggerDown && Input.GetAxis("XBoxLeftTrigger") > 0)
        {
            leftTriggerDown = true;
            return true;
        }
        else if (Input.GetAxis("XBoxLeftTrigger") == 0)
        {
            leftTriggerDown = false;
            return false;
        }
        else
            return false;
    }

    public static bool MoveRightInput()
    {
        if (playerAlive && 
            (Input.GetKey(KeyCode.D) 
            || Input.GetKey(KeyCode.RightArrow) 
            || Input.GetAxis("XBoxHorizontal") > 0))
            return true;
        else
            return false;
    }

    public static bool MoveLeftInput()
    {
        if (playerAlive && 
            (Input.GetKey(KeyCode.A) 
            || Input.GetKey(KeyCode.LeftArrow) 
            || Input.GetAxis("XBoxHorizontal") < 0))
            return true;
        else
            return false;
    }

    //Game Over Screen
    public static bool RespawnInput()
    {
        if (!playerAlive && 
            (Input.GetKeyDown(KeyCode.R) 
            || Input.GetButtonDown("XBoxX")))
        {
            return true;
        }
        else
            return false;
    }

    public static bool EscapeInput()
    {
        if (Input.GetKey(KeyCode.Escape) 
            || Input.GetButtonDown("XBoxB"))
            return true;
        else
            return false;
    }

    //Eevator
    public static bool LeaveLevelInput()
    {
        if (Input.GetKeyDown(KeyCode.S) 
            || Input.GetKeyDown(KeyCode.DownArrow) 
            || Input.GetButtonDown("XBoxY"))
            return true;
        else
            return false;
    } 
}
