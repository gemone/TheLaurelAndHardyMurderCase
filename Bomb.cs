/* Michael Gebhart
 * Cologne Game Lab
 * BA 1 - Ludic Game 2018 / 2019 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Enemy
{
    public float exploAnimTime;
    private Vector3 scale;
    private bool exploded = false;

    void Start()
    {
        setBombComponents();
    }

    void Update()
    {
        if (growable && !fullyGrown) grow();
        else if (fullyGrown) fall();
        if (animator.GetBool("isExploding"))
        {
            exploAnimTime -= Time.deltaTime;
            if (exploAnimTime < 0f) Destroy(this.gameObject);
        }
        if (respawnable) respawnProcessing();
    }

    //during spawn
    void setBombComponents()
    {
        scale = this.transform.localScale;
        setComponents();
        enemyManager = GameObject.Find("/BombManager");
        this.transform.parent = enemyManager.transform;
        bc2d = gameObject.GetComponent<BoxCollider2D>();
        bc2d.enabled = false; //explosion trigger
    }

    //falling determined by physics
    void fall()
    {
        if (!animator.GetBool("isFalling"))
        {
            rb2d.constraints = RigidbodyConstraints2D.None;
            animator.SetBool("isFalling", true);
        }
        rb2d.AddForce(Physics.gravity);
    }

    //when exploding, the explosion activates the trigger as its shock wave
    void explode()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
        audioSource.PlayOneShot(death, deathVolume);
        
        transform.position += new Vector3(0f, 0.4f, 0f);
        rb2d.bodyType = RigidbodyType2D.Static;
        this.transform.localScale = scale;
        animator.SetBool("isExploding", true);
        enemySpawner.SendMessage("instanceDied");
        bc2d.enabled = true; //trigger for explosion damage
        exploded = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (!exploded && col.gameObject.layer == 17) //gets attacked by player before explosion
        {
            enemyManager.SendMessage("Killcount", this.name);
            Destroy(this.gameObject);
        }
        else if (!exploded) explode(); //player touches any thing -> explosion
        if (exploded && col.gameObject.layer == 10) //player touches explosion
            col.gameObject.SendMessage("die", this.name);
    }
}
