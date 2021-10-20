using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerColl : MonoBehaviour
{
    [SerializeField] AudioClip succes;
    [SerializeField] AudioClip crash;

    AudioSource aus;

    [SerializeField] ParticleSystem explose;
    [SerializeField] ParticleSystem winSucces;

    private void Awake()
    {
        aus = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Fuel":
                Debug.Log("топливо");
                break;

            case "Finish":
                winSucces.Play();
                aus.PlayOneShot(succes);
                LoadNextLevel();
              
                break;

            case "Friendly":
                Debug.Log("дружеств платворма");
                break;

            default:
                explose.Play();
                aus.PlayOneShot(crash);
                Invoke(nameof(RelodLevel), 1f);
              
                break;

        }
    }

    private void RelodLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void LoadNextLevel()
    {
        int indexToload = SceneManager.GetActiveScene().buildIndex;
        indexToload++;
        if (indexToload == SceneManager.sceneCountInBuildSettings)
        {
            indexToload = 0;
        }
        SceneManager.LoadScene(indexToload);
    }
}
