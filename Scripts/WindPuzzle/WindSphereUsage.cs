using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindSphereUsage : ItemUsage
{
    public GameObject forceField;
    public AudioSource windSphereAudio;

    public override void UseItem(bool clicked)
    {
        base.UseItem(clicked);
        Debug.Log("Blasebalg genutzt");
        forceField.SetActive(clicked);
        var emission = transform.GetComponent<ParticleSystem>().emission;
        emission.enabled = clicked;

        if (!windSphereAudio.isPlaying && clicked)
            windSphereAudio.Play();
        else
            windSphereAudio.Stop();

    }

    void Start()
    {
        if(forceField == null) Debug.LogError("Kein Forcefield beim Blasebalg zugewiesen!");
    }  
}
