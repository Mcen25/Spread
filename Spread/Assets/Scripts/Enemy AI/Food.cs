using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    private GameObject foodObject;
    public int foodvalue = 100;

    public GameObject[] doors; // Array of doors that has access to the food

    void Awake() {
        foodObject = GetComponent<GameObject>();
    }
    // Update is called once per frame
    void Update()
    {
        if (foodvalue <= 0) {
            Debug.Log("Food Destroyed");
            Destroy(foodObject);
        }
    }

    public void DecreaseHealth(int amount) {
        foodvalue -= amount;
        if (foodvalue <= 0) {
            Destroy(foodObject);
        }
    }

    public void KillFood() {
        Destroy(foodObject);
    }

    public bool RoomAccess() {
        foreach (GameObject door in doors)
        {
            if (door.activeSelf == true) {
                return true;
            }
        }

        return false;
    }
}
