using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;

    public Transform positionToShoot;
    public float timeBetweenShots = .3f;
    public Transform playerSideReference;

    private Coroutine _currentCoroutine;

    public AudioRandomPlayAudioClips randomShoot;

    private void Awake()
    {
        playerSideReference = GameObject.Find("Player").gameObject.transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            if (_currentCoroutine != null) 
                StopCoroutine(_currentCoroutine);
        }
    }

    IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShots);
        }
    }

    public void Shoot()
    {
        if (randomShoot != null) randomShoot.PlayRandom();

        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;
    }
}
