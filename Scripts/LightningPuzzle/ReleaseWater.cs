using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Aktiviert den Fluss und den See der Insel.
/// </summary>
public class ReleaseWater : Interactable
{
    /// <summary>
    /// Animator des Flusses.
    /// </summary>
    public Animator waterAnimator;

    /// <summary>
    /// Animator des Flusstors.
    /// </summary>
    public Animator watergateAnimator;

    /// <summary>
    /// Animator des Tors am Eingang des Rätsels.
    /// </summary>
    public Animator lightningGateAnimator;

    /// <summary>
    /// Animator des Hebels.
    /// </summary>
    public Animator leverAnimator;

    /// <summary>
    /// Empty, an dem alle Wasser-Elemente anhängen.
    /// </summary>
    public GameObject water;

    /// <summary>
    /// Baumstamm 0 am Grund des Sees.
    /// </summary>
    public GameObject log0Ground;

    /// <summary>
    /// Baumstamm 1 am Grund des Sees.
    /// </summary>
    public GameObject log1Ground;

    /// <summary>
    /// Baumstamm 0 im Wasser treibend.
    /// </summary>
    public GameObject log0Water;

    /// <summary>
    /// Baumstamm 1 im Wasser treibend.
    /// </summary>
    public GameObject log1Water;

    /// <summary>
    /// Audio des Hebels.
    /// </summary>
    public AudioSource leverAudio;

    /// <summary>
    /// Audio des Tors am Eingang des Rätsels.
    /// </summary>
    public AudioSource lightningGateAudio;

    /// <summary>
    /// Audio des Triumph Sounds.
    /// </summary>
    public AudioSource triumphSound;

    public override void Interact(bool pressed)
    {
        if (pressed) 
        {
            // Spielt die Sounds ab.
            leverAudio.Play();
            lightningGateAudio.Play();
            triumphSound.Play();

            // Aktiviert das Wasser-Empty.
            water.SetActive(true);

            // Führt alle Animationen aus.
            leverAnimator.SetBool("wasPulled", true);
            waterAnimator.SetBool("isRising", true);
            watergateAnimator.SetBool("isMoved", true);
            lightningGateAnimator.SetBool("hasEntered", false);

            // Deaktviert die Baumstämme am Grund des Sees.
            log0Ground.SetActive(false);
            log1Ground.SetActive(false);

            // Aktiviert die Baumstämme an der Wasseroberfläche des Sees.
            log0Water.SetActive(true);
            log1Water.SetActive(true);
        }
    }
}
