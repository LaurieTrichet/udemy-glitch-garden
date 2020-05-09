using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0.1f, 3.0f)]
    [SerializeField] float speed = 1.0f;  
    [Range(0.5f, 1.5f)]
    [SerializeField] float defaultAnimationSpeed = 1.13f;

    

    private Animator animator = null;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        animator.speed = defaultAnimationSpeed * speed;
    }
}
