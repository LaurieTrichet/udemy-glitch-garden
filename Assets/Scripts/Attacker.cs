using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0.1f, 3.0f)]
    float speed = 0.0f;

    [SerializeField] AudioClip deathSFX = null;

    private HealthSystem healthSystem = null;
    // Start is called before the first frame update
    void Start()
    {
        healthSystem = GetComponent<HealthSystem>();
        healthSystem.hasDied = this.OnHasDied;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    void SetMovementSpeed(float value)
    {
        speed = value;
    }

    void OnHasDied()
    {
        AudioSource.PlayClipAtPoint(deathSFX, gameObject.transform.position);
    }
}
