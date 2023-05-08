using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDeny : MonoBehaviour
{
    public AudioClip interactionSound;
    public float textureChangeTime = 1.0f; // Amount of time to show the alternate texture
    public Light lightObject; // Reference to the Light object to turn off

    public Texture alternateTexture; // Alternate texture to show when button is pressed
    private Texture initialTexture; // Initial texture to revert to after textureChangeTime has passed
    private Renderer objectRenderer; // Reference to the object's renderer component

    private bool isTextureChanging = false; // Flag to check if texture is currently changing
    private float textureChangeStartTime; // Time when the texture change started

    private void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        initialTexture = objectRenderer.material.mainTexture;
    }

    private void Update()
    {
        if (isTextureChanging)
        {
            if (Time.time - textureChangeStartTime >= textureChangeTime)
            {
                isTextureChanging = false;
                objectRenderer.material.mainTexture = initialTexture;
            }
        }
    }

    private void PlayInteractionSound()
    {
        if (interactionSound != null)
        {
            AudioSource.PlayClipAtPoint(interactionSound, transform.position);
        }
    }

    private void ChangeTexture()
    {
        isTextureChanging = true;
        textureChangeStartTime = Time.time;
        objectRenderer.material.mainTexture = alternateTexture;
    }

    private void TurnOffLight()
    {
        if (lightObject != null)
        {
            lightObject.enabled = false;
            Invoke("TurnOnLight", textureChangeTime);
        }
    }

    private void TurnOnLight()
    {
        if (lightObject != null)
        {
            lightObject.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayInteractionSound();
            ChangeTexture();
            TurnOffLight();
        }
    }
}
