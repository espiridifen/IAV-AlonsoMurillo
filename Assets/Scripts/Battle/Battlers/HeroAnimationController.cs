using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Hero))]
public class HeroAnimationController : MonoBehaviour
{
    private Animator _animator;
    public Animator Animator { get { return _animator; } private set { _animator = value; } }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayIdle()
    {
        if (_animator != null)
            _animator.SetBool("isReady", false);
    }

    public void PlayUseItem()
    {
        if (_animator != null)

            _animator.SetTrigger("ItemTrigger");
    }

    public void PlayAttack()
    {

        if (_animator != null)
            _animator.SetTrigger("AttackTrigger");
    }

    public void PlaySpecialAttack()
    {
        if (_animator != null)
            _animator.SetTrigger("SpecialTrigger");
    }

    public void PlayGetDamaged()
    {
        if (_animator != null)
            _animator.SetTrigger("HurtTrigger");
    }

    public void PlayBuff()
    {
        if (_animator != null)
            _animator.SetTrigger("BuffTrigger");
    }

    public void PlayDefend()
    {
        if (_animator != null)
            _animator.SetBool("isDefending", true);
    }

    public void StopDefend()
    {
        if (_animator != null)
            _animator.SetBool("isDefending", false);
    }

    public void PlayReady()
    {
        if (_animator != null)
            _animator.SetBool("isReady", true);
    }

    public void PlayMoveForward()
    {
        if (_animator != null)
            _animator.SetTrigger("MoveForward");
    }

    public void PlayMoveBackward()
    {
        if (_animator != null)
            _animator.SetTrigger("MoveBackward");
    }

    public void PlayEvade()
    {
        if (_animator != null)
            _animator.SetTrigger("EvadeTrigger");
    }

    public void PlayWin()
    {

    }


}

