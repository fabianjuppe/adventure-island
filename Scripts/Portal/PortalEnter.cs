using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Betreten des Portals.
/// </summary>
public class PortalEnter : MonoBehaviour
{
    /// <summary>
    /// Name der Szene, die als nächstes geladen werden soll.
    /// </summary>
    public string sceneName;

    /// <summary>
    /// Spielfigur.
    /// </summary>
    private GameObject player;

    /// <summary>
    /// Animator für den Szenenwechsel.
    /// </summary>
    public Animator transition;

    /// <summary>
    /// Wartezeit bis die neue Szene geladen wird.
    /// </summary>
    public float transitionTime = 1f;

    /// <summary>
    /// Animator für die Musik.
    /// </summary>
    public Animator musicAnimator;

    private void Start()
    {
        player = GameObject.Find("First Person Player");
    }

    private void OnTriggerEnter()
    {
        if (musicAnimator)
            musicAnimator.SetTrigger("musicEnd"); // Musik beenden vor dem Laden der neuen Szene.
        StartCoroutine(LoadLevel(sceneName));
    }

    /// <summary>
    /// Lädt die nächste Szene mit einem flüssigen Bildwechsel.
    /// </summary>
    /// <param name="levelName">Name der nächsten Szene.</param>
    /// <returns></returns>
    IEnumerator LoadLevel(string levelName)
    {
        transition.SetTrigger("Start"); // Startet die Animation des Szenenwechsels.

        yield return new WaitForSeconds(transitionTime); // Wartet die angegebene Zeit bevor die folgenden Anweisungen ausgeführt werden.

        Destroy(player); // Zerstört den Spieler der aktuellen Szene.

        SceneManager.LoadScene(levelName); // Lädt die nächste Szene.
    }
}