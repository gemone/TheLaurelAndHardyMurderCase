/* Michael Gebhart
 * Cologne Game Lab
 * BA 1 - Ludic Game 2018 / 2019 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy {

    /*this class adds abilities to every back-and-forth enemy instance of Banana, Lobsters */
    public bool movable;
    public float speed;
    public bool goingRight;

    protected void move()
    {
        if (movable)
        {
            if (goingRight) rb2d.velocity = Vector2.right * speed;
            else if (!goingRight)
            {
                rb2d.velocity = Vector2.left * speed;
                setLeft();
            }
        }
    }

    protected void changeDirection() //called by edge Triggers, located at the end of every platforms
    {
        if (goingRight)
        {
            goingRight = false;
            setLeft();
        }
        else if (!goingRight)
        {
            goingRight = true;
            setRight();
        }
    }

    //change rotation leftwards
    public void setLeft()
    {
        transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    //change rotation rightwards
    public void setRight()
    {
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}