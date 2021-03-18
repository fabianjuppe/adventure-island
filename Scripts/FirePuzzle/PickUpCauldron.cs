using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCauldron : MonoBehaviour
{
    public Animator fenceDoor;
    public AudioSource fenceAudio;
    private bool fenceAudioPlayed = false;

    void Update()
    {
        if (gameObject.transform.childCount < 1)
        {
            fenceDoor.SetBool("isOpen", true);

            if (!fenceAudioPlayed)
            {
                fenceAudio.Play();
                fenceAudioPlayed = true;
            }
        }
    }
}
