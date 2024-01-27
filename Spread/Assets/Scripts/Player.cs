using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public GameObject player;
    public GameObject mainMenu;
    [SerializeField] private GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {    
        player = GameObject.FindWithTag("Player");
    }

    void Update() {
        if (mainMenu.activeSelf == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
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
