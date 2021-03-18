using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script Shake Tree: kann mit interagiert werden -> Particle Systems werden aktiviert/deaktiviert
//über particleList können mehrere Particle Systeme im Inspector angehängt werden
public class ShakeTree : Interactable
{
    public List<ParticleSystem> particleList = new List<ParticleSystem>();
    public AudioSource treeAudio;
    public Material treeTrunkShader;

    void Start()
    {
        treeTrunkShader.SetFloat("Vector1_Step", 10.0f);
    }
    public override void Interact(bool pressed)
    {

        foreach(ParticleSystem p in particleList)
        {
            var emission = p.emission;
            emission.enabled = pressed;
        }
        
        if(pressed)
            treeTrunkShader.SetFloat("Vector1_Step", 0.0f);
        else
            treeTrunkShader.SetFloat("Vector1_Step", 10.0f);


        if (!treeAudio.isPlaying && pressed)
            treeAudio.Play();
        else
            treeAudio.Stop();
    }
}
