using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem thisParticleSystem;
    public float timeToHide = 3f;
    public GameObject graphicItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        if (graphicItem != null && graphicItem.activeSelf)
        {
            graphicItem.SetActive(false);
            OnCollect();
        }
        Invoke("HideObject", timeToHide);
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (thisParticleSystem != null) thisParticleSystem.Play();
    }
}
