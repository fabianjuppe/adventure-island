using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ausführen der Schrittgeräusche des Spielers.
/// </summary>
public class PlayerSound : MonoBehaviour
{
    #region Singleton

    public static PlayerSound instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of PlayerSound found!");
            return;
        }
        instance = this;
    }

    #endregion

    /// <summary>
    /// Audioquelle für die Schrittgeräusche.
    /// </summary>
    public AudioSource footstepAudioSource;

    /// <summary>
    /// Liste der verschiedenen Schrittgeräusche.
    /// </summary>
    public List<AudioClip> footstepsList = new List<AudioClip>();

    /// <summary>
    /// Auswahl des Standard-Schrittgeräuschs.
    /// </summary>
    public int defaultFootstepAudio = 6;

    void Update()
    {
        // Anpassen der Geschwindigkeit des Audios an die Geschwindigkeit der Spielerbewegung.
        float walkspeed = PlayerMovement.FindObjectOfType<PlayerMovement>().walkspeed;
        float runspeed = PlayerMovement.FindObjectOfType<PlayerMovement>().runspeed;

        if (Input.GetKey(KeyCode.LeftShift))
            footstepAudioSource.pitch = runspeed / 10;
        else
            footstepAudioSource.pitch = walkspeed / 10;


        // Abspielen der Schrittgeräusche, falls sich der Spieler bewegt.
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (!footstepAudioSource.isPlaying)
                footstepAudioSource.Play();
        }
        else
            footstepAudioSource.Stop();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Schrittgeräusch für den entsprechenden Untergrund wechseln.
        for (int i = 0; i < footstepsList.Count; i++)
        {
            if (hit.transform.CompareTag(footstepsList[i].name))
            {
                footstepAudioSource.clip = footstepsList[i];
                return;
            }
        }
        footstepAudioSource.clip = footstepsList[defaultFootstepAudio];
    }
}