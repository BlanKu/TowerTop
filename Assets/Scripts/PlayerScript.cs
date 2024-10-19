using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float playerSpeed;
    public float jumpSpeed;

    public BoxCollider2D _boxCollider2D;
    public Rigidbody2D _rigidbody2D;
    public SpriteRenderer _spriteRenderer;
    public Animator _animator;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            PlayerGoLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            PlayerGoRight();
        }

        if (Input.GetKey(KeyCode.W))
        {
            PlayerJump();
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            ResetValocityX();
        }
    }

    public void PlayerGoLeft()
    {
        _rigidbody2D.velocity = new Vector2(-playerSpeed, _rigidbody2D.velocity.y);
        _spriteRenderer.flipX = true;
        _animator.Play("PlayerWalk");
    }

    public void PlayerGoRight()
    {
        _rigidbody2D.velocity = new Vector2(playerSpeed, _rigidbody2D.velocity.y);
        _spriteRenderer.flipX = false;
        _animator.Play("PlayerWalk");
    }

    public void PlayerJump()
    {
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed);
    }

    public void ResetValocityX()
    {
        _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        _animator.Play("PlayerIdle");
    }
}
