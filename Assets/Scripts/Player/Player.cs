using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private float _currentSpeed;

    public HealthBase healthBase;
    public Rigidbody2D myRigidbody;

    //public Animator animator;
    private Animator _currentPlayer;

    [Header("Setup")]
    public SOPlayerSetup soPlayerSetup;

    private void Awake()
    {
        if (healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }

        _currentPlayer = Instantiate(soPlayerSetup.player, transform);
    }

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;
        _currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);
    }

    // Update is called once per frame
    void Update()
    {
        HandleJump();
        HandleMoviment();
    }

    void HandleMoviment()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = soPlayerSetup.speedRun;
            _currentPlayer.speed = 2;
        }
        else
        {
            _currentSpeed = soPlayerSetup.speed;
            _currentPlayer.speed = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, soPlayerSetup.playerSwipeDuration);
            }
            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        } 
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
            if (myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, soPlayerSetup.playerSwipeDuration);
            }
            _currentPlayer.SetBool(soPlayerSetup.boolRun, true);
        } 
        else
        {
            _currentPlayer.SetBool(soPlayerSetup.boolRun, false);
        }

        if (myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += soPlayerSetup.friction;
        }
        else if(myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= soPlayerSetup.friction;
        }
    }

    void HandleJump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            myRigidbody.velocity = Vector2.up * soPlayerSetup.jumpForce;
            myRigidbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigidbody.transform);

            HandleScaleJump();
        }
    }

    void HandleScaleJump()
    {
        myRigidbody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        myRigidbody.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
