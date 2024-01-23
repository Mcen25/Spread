using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 100;
    public GameObject player;
    [SerializeField] private Canvas canvas;
    // Start is called before the first frame update
    void Start()
    {    
        player = GameObject.FindWithTag("Player");
    }
    public void DecreaseHealth(int amount) {
        Debug.Log("Player Health: " + health);
        health -= amount;
        if (health <= 0) {
            Debug.Log("Player killed");
            canvas.enabled = true;
        }
    }
}
