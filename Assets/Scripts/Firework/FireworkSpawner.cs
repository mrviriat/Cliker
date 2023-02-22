using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkSpawner : MonoBehaviour
{
    public GameObject firework;
    void Start()
    {
        Game.singleton.ClickAction += Present;
    }
    public void Present(float ClickCount)
    {
        if (ClickCount == 100)
        {
            Debug.Log("u have 100 money!");
            FireworkSpawn();
        }
    }
    public void FireworkSpawn()
    {
        Instantiate(firework);
    }
}
