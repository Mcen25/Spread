using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public GameObject player;
    [SerializeField] private GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {    
        player = GameObject.FindWithTag("Player");
    }
    public void DecreaseHealth(int amount, MinionStateManager minion) {
        Debug.Log("Player Health: " + health);
        health -= amount;
        if (health <= 0) {
            Debug.Log("Player killed");
            gameOver.SetActive(true);
            minion.animator.SetBool("Attacking", false);
        }
    }

    public void DeathByBoss(int amount, BossStateManager minion) {
        Debug.Log("Player Health: " + health);
        health -= amount;
        if (health <= 0) {
            Debug.Log("Player killed");
            gameOver.SetActive(true);
            minion.animator.SetBool("Punching", false);
        }
    }
}
