using UnityEngine;

public class FeuerzeugUsage : ItemUsage
{
    public ParticleSystem parSys;

    public override void UseItem(bool clicked)
    {
        base.UseItem(clicked);
        Debug.Log("Feuerzeug genutzt");
        var emission = parSys.emission;
        emission.enabled = clicked;     
    }

    void Start()
    {
        if(parSys == null) Debug.LogError("Kein Partikelsystem beim Feuerzeug zugewiesen!");
    }  
    
}
