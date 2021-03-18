using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class StatueForSpheres : MonoBehaviour
{
    /// <summary>
    /// Spielfigur.
    /// </summary>
    public GameObject player;

    /// <summary>
    /// Schale für die Feuersphäre.
    /// </summary>
    public GameObject fireBowl;

    /// <summary>
    /// Schale für die Blitzsphäre.
    /// </summary>
    public GameObject lightningBowl;

    /// <summary>
    /// Schale für die Wassersphäre.
    /// </summary>
    public GameObject waterBowl;

    /// <summary>
    /// Schale für die Windsphäre.
    /// </summary>
    public GameObject windBowl;

    /// <summary>
    /// VFX des Kristalls.
    /// </summary>
    public GameObject crystalVFX;

    /// <summary>
    /// VFX des Strahls der Statue.
    /// </summary>
    public GameObject statueVFX;

    /// <summary>
    /// VFX des Feuerstrahls.
    /// </summary>
    public GameObject fireVFX;

    /// <summary>
    /// VFX des Blitzstrahls.
    /// </summary>
    public GameObject lightningVFX;

    /// <summary>
    /// VFX des Wasserstrahls.
    /// </summary>
    public GameObject waterVFX;

    /// <summary>
    /// VFX des Windstrahls.
    /// </summary>
    public GameObject windVFX;

    /// <summary>
    /// Feuersphäre.
    /// </summary>
    public GameObject fireSphere;

    /// <summary>
    /// Blitzsphäre.
    /// </summary>
    public GameObject lightningSphere;

    /// <summary>
    /// Wassersphäre.
    /// </summary>
    public GameObject waterSphere;

    /// <summary>
    /// Windsphäre.
    /// </summary>
    public GameObject windSphere;

    /// <summary>
    /// Animator des Hauptmusikstücks.
    /// </summary>
    public Animator musicDarkAnimator;

    /// <summary>
    /// Animator des Musikstücks nach Beenden der Rätsel.
    /// </summary>
    public Animator musicAtmoAnimator;

    /// <summary>
    /// Audio der Musik nach Beenden der Rätsel.
    /// </summary>
    public AudioSource musicAtmo;

    /// <summary>
    /// Überprüfen, ob Musik bereits gespielt wurde.
    /// </summary>
    private bool musicAtmoPlayed = false;

    /// <summary>
    /// Audio des Triumph Sounds.
    /// </summary>
    public AudioSource triumphSound;

    /// <summary>
    /// Überprüfen, ob Triumph Sound bereits gespielt wurde.
    /// </summary>
    private bool triumphSoundPlayed = false;

    public float timePassed = 0f;
    private bool direction = true, end = false;
    public GameObject forceField, forceFieldTrigger;
    public Material forceFieldShader;
    public VisualEffect explosion, sparks;

    void Start()
    {
        forceFieldShader.SetFloat("Vector1_35BA36D", 0.2f);
        musicDarkAnimator.SetBool("musicPlayed", true);
    }

    private void Update()
    {
        // Aktivieren und Deaktivieren der BeamVFX Effekte.
        if (fireBowl.transform.childCount == 1)
            fireVFX.SetActive(true);
        else
            fireVFX.SetActive(false);

        if (lightningBowl.transform.childCount == 1)
            lightningVFX.SetActive(true);
        else
            lightningVFX.SetActive(false);

        if (waterBowl.transform.childCount == 1)
            waterVFX.SetActive(true);
        else
            waterVFX.SetActive(false);

        if (windBowl.transform.childCount == 1)
            windVFX.SetActive(true);
        else
            windVFX.SetActive(false);

        if (fireVFX.activeSelf && lightningVFX.activeSelf && waterVFX.activeSelf && windVFX.activeSelf) // Ausführen, wenn alle Sphären platziert wurden.
        {
            // Aktivieren der Effekte der Statue.
            crystalVFX.SetActive(true);
            statueVFX.SetActive(true);

            // Zerstören der PlaceSphere Skripte der Schalen, um ein weiteres Interagieren zu verhindern.
            Destroy(fireBowl.GetComponent<PlaceSphere>());
            Destroy(lightningBowl.GetComponent<PlaceSphere>());
            Destroy(waterBowl.GetComponent<PlaceSphere>());
            Destroy(windBowl.GetComponent<PlaceSphere>());

            // Zerstören der ItemBehaviour Skripte der Sphären, um ein erneutes Aufheben zu verhindern.
            Destroy(fireSphere.GetComponent<ItemBehaviour>());
            Destroy(lightningSphere.GetComponent<ItemBehaviour>());
            Destroy(waterSphere.GetComponent<ItemBehaviour>());
            Destroy(windSphere.GetComponent<ItemBehaviour>());


            // Wechsel der Musik.
            if (!musicAtmoPlayed)
            {
                musicAtmo.Play();
                musicAtmoPlayed = true;
            }

            musicDarkAnimator.SetBool("musicPlayed", false);
            musicAtmoAnimator.SetBool("musicPlayed", true);

            if (!triumphSoundPlayed)
            {
                triumphSound.Play();
                triumphSoundPlayed = true;
            }


            //Effect
            Debug.Log(timePassed);

            if(!end && direction)
            {
                forceFieldShader.SetFloat("Vector1_35BA36D", 4);
            }
            else if(!end && !direction)
            {

            }

            if(timePassed > 5 && !end)
            {
                explosion.Play();
                Destroy(forceField);
                Destroy(forceFieldTrigger);
                player.transform.GetComponent<PlayerMovement>().walkspeed = 10f;
                player.transform.GetComponent<PlayerMovement>().runspeed = 16f;
                end = true;
            }

            timePassed += Time.deltaTime;
        }
    }
}
