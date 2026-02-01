using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public GameDirector gameDirector;
    public float speed;
    public bool isAppleCollected;    
    private Rigidbody _rb;
    
    private bool _isCharachterWalking; 
    public Animator animator;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Collactable1"))
        {
            other.gameObject.SetActive(false);
            gameDirector.LevelManager.appleCollected();
            isAppleCollected = true;
        }

        if (other.CompareTag("Door") && isAppleCollected)
        {
            gameDirector.LevelCompleted();
        }
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        var direction = Vector3.zero;
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10;
            SetWalkAnimationSpeed(2f);
        }
        else
        {
            speed = 5;
            SetWalkAnimationSpeed(1f);
        }

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D))
        { 
            direction += Vector3.right;
        }

        if (direction.magnitude < .1f)
        {
            TriggerIdleAnimation();
        }
        else
        {
            TriggerWalkAnimation();
        }
        
        
        transform.LookAt(transform.position + direction);
        _rb.linearVelocity = direction.normalized * speed;  // normalize çapraz gittiğinde hızı 1 yapıyor  kök 2 değil
    }

    void TriggerWalkAnimation()
    {
        if (!_isCharachterWalking)
        {
            animator.SetTrigger("Walk2");
            _isCharachterWalking = true;
        }
    }
    void TriggerIdleAnimation()
    {
        if (_isCharachterWalking)
        {
            animator.SetTrigger("idle");
            _isCharachterWalking= false;
        }
    }

    void SetWalkAnimationSpeed(float s)
    {
        animator.SetFloat("walkSpeedMultiplier", s);
    }
}