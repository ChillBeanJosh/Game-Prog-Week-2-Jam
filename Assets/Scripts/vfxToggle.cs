using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class vfxToggle : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    private bool vfxActive = false;

    public enemySpawner spawnerScript;


    public void PostProcessingToggle()
    {
        if (postProcessVolume != null)
        {
            vfxActive = !vfxActive;
            postProcessVolume.enabled = vfxActive;


            if (vfxActive)
            {
                spawnerScript.SetSpawnTime(1.5f);
            }
            else
            {
                spawnerScript.SetSpawnTime(3f);
            }
        }
    }
}
    