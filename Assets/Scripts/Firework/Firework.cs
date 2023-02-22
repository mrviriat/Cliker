using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    [Header("Firework Speed")]
    public float minSpeed, maxSpeed;
    
    [Header("Firework Lifetime")]
    public float minTime, maxTime;

    public GameObject fireworkEffect;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = Random.Range(minSpeed, maxSpeed) * -1f;

        StartCoroutine(FireworkDestroy());
    }

    private IEnumerator FireworkDestroy()
    {
        yield return new WaitForSecondsRealtime(Random.Range(minTime, maxTime));
        fireworkEffect.transform.localPosition = gameObject.transform.localPosition;
        Instantiate(fireworkEffect);
        Destroy(gameObject);
    }
}
