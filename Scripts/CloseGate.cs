using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Schließen der Tore beim Betreten.
/// </summary>
public class CloseGate : MonoBehaviour
{
    /// <summary>
    /// Animator des Tors.
    /// </summary>
    public Animator gateAnimator;

    /// <summary>
    /// Audio des Tors.
    /// </summary>
    public AudioSource gateAudio;

    private void OnTriggerEnter(Collider other)
    {
        gateAnimator.SetBool("hasEntered", true); // Absenken des Tores.
        gateAudio.Play(); // Abspielen des Audios.
        Destroy(gameObject); // Entfernen des Skripts.
    }
}
