using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Verwaltet das Blitzrätsel.
/// </summary>
public class LightningPuzzleManager : MonoBehaviour
{
    /// <summary>
    /// Animator der Säule mit Schalter am Ende des Rätsels.
    /// </summary>
    public Animator pedestalAnimator;

    /// <summary>
    /// Audio für die Bewegung der Säule mit Schalter am Ende des Rätsels.
    /// </summary>
    public AudioSource pedestalAudio;

    /// <summary>
    /// Überprüft, ob Audio der Säule bereits ausgeführt wurde.
    /// </summary>
    private bool pedestalAudioPlayed = false;

    /// <summary>
    /// Liste aller Säulen des Rätsels.
    /// </summary>
    public List<GameObject> pillarList = new List<GameObject>();

    /// <summary>
    /// Liste aller LightningVFX Effekte des Rätsels.
    /// </summary>
    public List<GameObject> lightningVFXList = new List<GameObject>();

    /// <summary>
    /// Liste aller LightningSpheres.
    /// </summary>
    public List<GameObject> lightningSpheresList = new List<GameObject>();

    void Update()
    {
        bool[] wasMoved = new bool[pillarList.Count]; // Variablen zur Überprüfung, ob eine Säule bewegt wurde.
        int[] hasSphere = new int[pillarList.Count]; // Variablen zur Überprüfung, ob eine Säule eine Sphäre besitzt.

        for (int i = 0; i < pillarList.Count; i++) // Zuweisen der Array-Werte.
        {
            wasMoved[i] = pillarList[i].GetComponent<MovePillar>().isMoved;
            hasSphere[i] = pillarList[i].transform.childCount;
        }

        if (hasSphere[0] == 5 && wasMoved[0]) // Aktivieren und Deaktivieren der LightningVFX Effekte.
        {
            lightningVFXList[0].SetActive(true);

            if (hasSphere[1] == 5 && wasMoved[1])
            {
                lightningVFXList[1].SetActive(true);

                if (hasSphere[2] == 5 && !wasMoved[2])
                {
                    lightningVFXList[2].SetActive(true);

                    if (hasSphere[3] == 5 && wasMoved[3])
                    {
                        lightningVFXList[3].SetActive(true);

                        if (hasSphere[4] == 5 && wasMoved[4])
                        {
                            lightningVFXList[4].SetActive(true);
                            lightningVFXList[5].SetActive(true);

                            EndPuzzle(); // Wird nach Lösen des Rätsels aufgerufen.
                        }
                        else
                        {
                            lightningVFXList[4].SetActive(false);
                            lightningVFXList[5].SetActive(false);
                        }

                        if (hasSphere[4] == 5 && !wasMoved[4])
                        {
                            lightningVFXList[18].SetActive(true);
                        }
                        else
                            lightningVFXList[18].SetActive(false);
                    }
                    else
                    {
                        lightningVFXList[3].SetActive(false);
                        lightningVFXList[4].SetActive(false);
                        lightningVFXList[5].SetActive(false);
                        lightningVFXList[18].SetActive(false);
                    }

                    if (hasSphere[5] == 5 && !wasMoved[5])
                    {
                        lightningVFXList[14].SetActive(true);
                    }
                    else
                        lightningVFXList[14].SetActive(false);

                    if (hasSphere[5] == 5 && wasMoved[5])
                    {
                        lightningVFXList[21].SetActive(true);
                    }
                    else
                        lightningVFXList[21].SetActive(false);

                    if (hasSphere[3] == 5 && !wasMoved[3])
                    {
                        lightningVFXList[15].SetActive(true);

                        if (hasSphere[8] == 5 && !wasMoved[8])
                        {
                            lightningVFXList[12].SetActive(true);
                        }
                        else
                            lightningVFXList[12].SetActive(false);

                        if (hasSphere[8] == 5 && wasMoved[8])
                        {
                            lightningVFXList[16].SetActive(true);

                            if (hasSphere[4] == 5 && !wasMoved[4])
                            {
                                lightningVFXList[17].SetActive(true);
                            }
                            else
                                lightningVFXList[17].SetActive(false);
                        }
                        else
                            lightningVFXList[16].SetActive(false);

                        if (hasSphere[4] == 5 && !wasMoved[4])
                        {
                            lightningVFXList[13].SetActive(true);
                        }
                        else
                            lightningVFXList[13].SetActive(false);
                    }
                    else
                    {
                        lightningVFXList[12].SetActive(false);
                        lightningVFXList[13].SetActive(false);
                        lightningVFXList[15].SetActive(false);
                        lightningVFXList[16].SetActive(false);   
                    }
                }
                else
                {
                    lightningVFXList[2].SetActive(false);
                    lightningVFXList[3].SetActive(false);
                    lightningVFXList[4].SetActive(false);
                    lightningVFXList[5].SetActive(false);
                    lightningVFXList[12].SetActive(false);
                    lightningVFXList[13].SetActive(false);
                    lightningVFXList[14].SetActive(false);
                    lightningVFXList[15].SetActive(false);
                    lightningVFXList[16].SetActive(false);
                    lightningVFXList[17].SetActive(false);
                    lightningVFXList[18].SetActive(false);
                    lightningVFXList[21].SetActive(false);
                }

                if (hasSphere[5] == 5 && wasMoved[5])
                {
                    lightningVFXList[6].SetActive(true);
                }
                else
                    lightningVFXList[6].SetActive(false);

            }
            else
            {
                lightningVFXList[1].SetActive(false);
                lightningVFXList[2].SetActive(false);
                lightningVFXList[3].SetActive(false);
                lightningVFXList[4].SetActive(false);
                lightningVFXList[5].SetActive(false);
                lightningVFXList[6].SetActive(false);
                lightningVFXList[12].SetActive(false);
                lightningVFXList[13].SetActive(false);
                lightningVFXList[14].SetActive(false);
                lightningVFXList[15].SetActive(false);
                lightningVFXList[16].SetActive(false);
                lightningVFXList[17].SetActive(false);
                lightningVFXList[18].SetActive(false);
                lightningVFXList[21].SetActive(false);
            }
        }
        else
        {
            lightningVFXList[0].SetActive(false);
            lightningVFXList[1].SetActive(false);
            lightningVFXList[2].SetActive(false);
            lightningVFXList[3].SetActive(false);
            lightningVFXList[4].SetActive(false);
            lightningVFXList[5].SetActive(false);
            lightningVFXList[6].SetActive(false);
            lightningVFXList[12].SetActive(false);
            lightningVFXList[13].SetActive(false);
            lightningVFXList[14].SetActive(false);
            lightningVFXList[15].SetActive(false);
            lightningVFXList[16].SetActive(false);
            lightningVFXList[17].SetActive(false);
            lightningVFXList[18].SetActive(false);
            lightningVFXList[21].SetActive(false);
        }


        if (hasSphere[0] == 5 && !wasMoved[0])
        {
            lightningVFXList[7].SetActive(true);

            if (hasSphere[6] == 5 && wasMoved[6])
            {
                lightningVFXList[8].SetActive(true);

                if (hasSphere[1] == 5 && !wasMoved[1])
                {
                    lightningVFXList[9].SetActive(true);
                }
                else
                    lightningVFXList[9].SetActive(false);

                if (hasSphere[7] == 5 && wasMoved[7])
                {
                    lightningVFXList[10].SetActive(true);

                    if (hasSphere[8] == 5 && !wasMoved[8])
                    {
                        lightningVFXList[11].SetActive(true);

                        if (hasSphere[3] == 5 && !wasMoved[3])
                        {
                            lightningVFXList[19].SetActive(true);

                            if (hasSphere[4] == 5 && !wasMoved[4])
                            {
                                lightningVFXList[20].SetActive(true);
                            }
                            else
                                lightningVFXList[20].SetActive(false);
                        }
                        else
                        {
                            lightningVFXList[19].SetActive(false);
                            lightningVFXList[20].SetActive(false);
                        }
                    }
                    else
                    {
                        lightningVFXList[11].SetActive(false);
                        lightningVFXList[19].SetActive(false);
                        lightningVFXList[20].SetActive(false);
                    }
                }
                else
                {
                    lightningVFXList[10].SetActive(false);
                    lightningVFXList[11].SetActive(false);
                    lightningVFXList[19].SetActive(false);
                    lightningVFXList[20].SetActive(false);
                }
            }
            else
            {
                lightningVFXList[8].SetActive(false);
                lightningVFXList[9].SetActive(false);
                lightningVFXList[10].SetActive(false);
                lightningVFXList[11].SetActive(false);
                lightningVFXList[19].SetActive(false);
                lightningVFXList[20].SetActive(false);
            }
        }
        else
        {
            lightningVFXList[7].SetActive(false);
            lightningVFXList[8].SetActive(false);
            lightningVFXList[9].SetActive(false);
            lightningVFXList[10].SetActive(false);
            lightningVFXList[11].SetActive(false);
            lightningVFXList[19].SetActive(false);
            lightningVFXList[20].SetActive(false);
        }
    }

    /// <summary>
    /// Beendet das Rätsel.
    /// </summary>
    private void EndPuzzle()
    {
        for (int i = 0; i < pillarList.Count; i++) // Deaktivieren des inneren MeshCollider der Säulen, um ein weiteres Interagieren zu verhindern.
        {
            pillarList[i].GetComponent<MeshCollider>().enabled = false;
        }

        for (int i = 0; i < lightningSpheresList.Count; i++) // Zerstören der ItemBehaviour Skripte der Sphären, um ein erneutes Aufheben zu verhindern.
        {
            Destroy(lightningSpheresList[i].GetComponent<ItemBehaviour>());
        }

        pedestalAnimator.SetBool("isMovingDown", true); // Aktivieren der Säulenanimation.

        if (!pedestalAudioPlayed) // Abspielen des Audios der Säule.
        {
            pedestalAudio.Play();
            pedestalAudioPlayed = true;
        }
    }
}