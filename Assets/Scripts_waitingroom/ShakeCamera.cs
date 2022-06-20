using System;
using System.Collections;
using System.Linq;
using UnityEngine;


public class ShakeCamera : MonoBehaviour
{
    public AudioSource HitAudio;
    private static bool shaken;
    private static float[][] offsets;

    private void Start()
    {
        offsets = new[]
        {
            new[] { -0.2f, -0.1f },
            new[] { 0.2f, -0.1f },
            new[] { -0.1f, 0.1f },
        };
    }

    private void Update()
    {
        if (!StartDialogue.DialogueFinished || shaken) return;

        shaken = true;
        StartCoroutine(Shake());
    }


    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator Shake()
    {
        var original = Camera.main.transform.position;
        foreach (var offset in offsets)
        {
            Camera.main.transform.position = original + new Vector3(offset[0], offset[1], original.z);
            yield return new WaitForSeconds(0.14f);
            HitAudio.Play();
            HitAudio.volume /= 2;
        }

        Camera.main.transform.position = original;
    }
}