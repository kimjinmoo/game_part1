using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float gameTime;
    public float maxGameTime = 2 * 10f;

    public int health;
    public int maxHealth = 100;
    public float exp = 0;
    public float nextExp = 1000;
    public float level = 1;

    public PoolManager pool;
    public PlayerController player;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        health = maxHealth;
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        print("gameTime " + gameTime);
        if(gameTime > maxGameTime) {
            gameTime = maxGameTime;
            // game over
        }
    }

}
