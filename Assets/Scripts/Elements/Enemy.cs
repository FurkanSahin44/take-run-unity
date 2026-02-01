using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.AI;
using Random = System.Random;

public class Enemy : MonoBehaviour
{
    private Player _player;
    public float speed;
    private Rigidbody _rb;
    public NavMeshAgent navMeshAgent;
    private Animator _animator;
    public Transform zPrefab;
    
    private bool _isWalking; // bool lar ilk başladığında false olarak başlıyor

    private Transform _z1;
    private Transform _z2;
    
    
    public void StartEnemy(Player player)
    {
        _player = player;
        _rb =  GetComponent<Rigidbody>();
        _animator = GetComponentInChildren<Animator>();
        transform.Rotate(0,UnityEngine.Random.Range(-180f,180f), 0);
        CreateAndAnimateZ();
    }

    private void CreateAndAnimateZ()
    {
         _z1 = Instantiate(zPrefab);
        _z1.position = transform.position + Vector3.up * 1f;
        _z1.localScale = Vector3.zero;
        _z1.DOMoveY(_z1.transform.position.y + 1, 1.5f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        _z1.DOScale(1, 1f).SetLoops(-1, LoopType.Restart);
        
        _z2 = Instantiate(zPrefab);
        _z2.position = transform.position + Vector3.up * 1f;
        _z2.localScale = Vector3.zero;
        _z2.DOMoveY(_z2.transform.position.y + 1, 1f).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart).SetDelay(.5f);
        _z2.DOScale(1, 1f).SetLoops(-1, LoopType.Restart).SetDelay(.5f);
    }


    private void Update()
    {
        if (_player.isAppleCollected)
        {
            /*var direction = (_player.transform.position - transform.position).normalized;
            direction.y = 0;
            _rb.position += direction * Time.deltaTime * speed; */
            navMeshAgent.destination = _player.transform.position;
            if (!_isWalking)
            {
                _isWalking = true;
                _animator.SetTrigger("WALK");
                _z1.DOKill(); //üzerindeki dotweenleri yok et önce
                _z2.DOKill();
                Destroy(_z1.gameObject);
                Destroy(_z2.gameObject);

            }
        }
    }
 
    public void stop()
    {
        navMeshAgent.speed = 0;
        _animator.SetTrigger("idle");
    }
}
