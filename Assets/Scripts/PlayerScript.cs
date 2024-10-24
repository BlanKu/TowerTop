using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float playerSpeed;
    public float jumpSpeed;
    public bool playerCanMove;
    public bool playerCanJump;
    public bool playerCanGoLeft;
    public bool playerCanGoRight;

    public BoxCollider2D _boxCollider2D;
    public BoxCollider2D CheckLeft;
    public Rigidbody2D _rigidbody2D;
    public SpriteRenderer _spriteRenderer;
    public Animator _animator;
    public AudioSource _audioSource;

    public AudioClip[] _audioClip;

    private SceneVariables _sceneVariables;
    private LoadingScirpt _loadingScirpt;

    private void Start()
    {
        _sceneVariables = GameObject.Find("SceneVariables").GetComponent<SceneVariables>();
        _loadingScirpt = GameObject.Find("SceneVariables").GetComponent<LoadingScirpt>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A) && playerCanMove)
        {
            PlayerGoLeft();
        }

        if (Input.GetKey(KeyCode.D) && playerCanMove)
        {
            PlayerGoRight();
        }

        if (Input.GetKeyDown(KeyCode.W) && playerCanMove)
        {
            PlayerJump();
        }

        if (Input.GetKeyUp(KeyCode.A) && playerCanMove || Input.GetKeyUp(KeyCode.D) && playerCanMove)
        {
            ResetValocityX();
        }

        if(Input.GetKeyUp(KeyCode.Escape))
        {
            QuitLevel();
        }
    }

    public void PlayerGoLeft()
    {
        if(playerCanGoLeft && playerCanMove)
        {
            _rigidbody2D.velocity = new Vector2(-playerSpeed, _rigidbody2D.velocity.y);
            _spriteRenderer.flipX = true;
            _animator.Play("PlayerWalk");
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        }
    }

    public void PlayerGoRight()
    {
        if(playerCanGoRight && playerCanMove)
        {
            _rigidbody2D.velocity = new Vector2(playerSpeed, _rigidbody2D.velocity.y);
            _spriteRenderer.flipX = false;
            _animator.Play("PlayerWalk");
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        }

    }

    public void PlayerJump()
    {
        if (playerCanJump && playerCanMove)
        {
            playerCanJump = false;
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed);
            _audioSource.resource = _audioClip[0];
            _audioSource.Play();
        }
    }

    public void ResetValocityX()
    {
        _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y);
        _animator.Play("PlayerIdle");
    }

    public void PlayGameOver()
    {
        playerCanMove = false;
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocityX, jumpSpeed);
        _boxCollider2D.enabled = false;
        _animator.Play("PlayerGameOver");
        _audioSource.resource = _audioClip[1];
        _audioSource.Play();
    }

    public void QuitLevel()
    {
        _sceneVariables.nextLevelName = "LevelMenu";
        StartCoroutine(_loadingScirpt.Loading());
    }
}
