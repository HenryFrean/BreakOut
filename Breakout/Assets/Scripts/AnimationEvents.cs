using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    [SerializeField] AudioClip explosionSfx;

    public void SendExplosionSound()
    {
        FindObjectOfType<AudioController>().PlaySfx(explosionSfx);
    }

    public void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}
