using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basisklasse für Interaktion mit Objekten
/// </summary>
public class Interactable : MonoBehaviour
{
    /// <summary>
    /// Angezeigetext für interagierbare Objekte.
    /// </summary>
    public string displayText;

    /// <summary>
    /// Abfrage, ob eine individuelle Fadenkreuzfarbe verwendet werden soll.
    /// </summary>
    public bool useCrosshairColor;

    /// <summary>
    /// Farbwert für das individuelle Fadenkreuz.
    /// </summary>
    public Color crosshairColor;

    /// <summary>
    /// Interaktion mit Objekten.
    /// </summary>
    /// <param name="pressed">"True" beim Drücken der Aktionstaste. "False" beim Loslassen der Aktionstaste.</param>
    public virtual void Interact(bool pressed)
    {
    }
}
