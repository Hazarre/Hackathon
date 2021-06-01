using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tower : MonoBehaviour
{
    public int maxHealth = 100;
    public int maxBuild = 100;
    public int health;
    public int build = 0;
    // Start is called before the first frame update
    public HealthBar healthBar;
    public HealthBar buildBar;
    void Start()
    {
        health = maxHealth;
        build = 0;
        healthBar.SetMaxHealth(maxHealth);
        buildBar.SetMaxHealth(maxBuild);
        buildBar.SetHealth(build);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) Build(30);
        //Game Over 
        if (health <= 0) SceneManager.LoadScene("GameOver");
        // Win 
        if (build >= maxBuild) SceneManager.LoadScene("Win");
    }

    public void Repair(int scrap){
        health += scrap;
        // health = Mathf.Min(maxHealth, health);
        healthBar.SetHealth(health);
    }

    public void Build(int scrap){
        build += scrap;
        // build = Mathf.Min(maxBuild, build);
        buildBar.SetHealth(build);
    }

    public void TakeDamage(int damage){
        health -= damage;
        // health = Mathf.Max(0, health);
        healthBar.SetHealth(health);
    }
}
