using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Ausführen der Umgebungsgeräusche.
/// </summary>
public class AmbientSound : MonoBehaviour
{
    /// <summary>
    /// Liste aller Umgebungsgeräusche.
    /// </summary>
    public List<AudioSource> ambientSoundList = new List<AudioSource>();
    
    void Update()
    {
        for (int i = 0; i < ambientSoundList.Count; i++)
            if (!ambientSoundList[i].isPlaying)
                ambientSoundList[i].PlayDelayed(Random.Range(30, 60)); // Führt das Geräusch mit einer zufälligen Verzögerung von 30 bis 60 Sekunden aus.             
    }
}
