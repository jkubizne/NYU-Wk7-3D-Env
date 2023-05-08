using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkMaterial : MonoBehaviour
{
    public float blinkRate = 1.0f;
    public Material blinkMaterial;

    private Renderer texRenderer;
    private Material originalMaterial;

    private void Start()
    {
        texRenderer = GetComponent<Renderer>();
        originalMaterial = texRenderer.material;
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            texRenderer.material = blinkMaterial;
            yield return new WaitForSeconds(1.0f / blinkRate);
            texRenderer.material = originalMaterial;
            yield return new WaitForSeconds(1.0f / blinkRate);
        }
    }
}
