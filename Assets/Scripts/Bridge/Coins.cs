using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private int points;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Add Coint To the Player");
            GameManager.instance.AddCoins(points);
            Destroy(this.gameObject);
        }
    }
}