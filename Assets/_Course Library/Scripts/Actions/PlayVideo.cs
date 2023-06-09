﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

/// <summary>
/// Play a single video or play from a list of videos 
/// </summary>
[RequireComponent(typeof(VideoPlayer))]
public class PlayVideo : MonoBehaviour
{
    [Tooltip("Whether video should play on load")]
    public bool playAtStart = false;

    [Tooltip("Material used for playing the video (Uses URP/Unlit by default)")]
    public Material videoMaterial = null;

    [Tooltip("List of video clips to pull from")]
    public List<VideoClip> videoClips = new List<VideoClip>();

    private VideoPlayer videoPlayer = null;
    private MeshRenderer meshRenderer = null;

    private int index = 0;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        videoPlayer = GetComponent<VideoPlayer>();

        index = Random.Range(0, videoClips.Count); //yoinked
        if (videoClips.Count > 0)
            //videoPlayer.clip = videoClips[0];
            videoPlayer.clip = videoClips[index];
    }

    private void OnEnable()
    {
        videoPlayer.prepareCompleted += ApplyVideoMaterial;
    }

    private void OnDisable()
    {
        videoPlayer.prepareCompleted -= ApplyVideoMaterial;
    }

    private void Start()
    {
        Play();
        InvokeRepeating("OWO", 2.0f, 0.3f); 
        // if (playAtStart)
        // {
        //     //copied fr random clip thing
        //     //Play();
        //     //RandomClip();
        //     InvokeRepeating("OWO", 2.0f, 0.3f); 
        // }
        // else
        // {
        //     Stop();
        // }
        
    }
    public void OWO(){
        if(!videoPlayer.isPlaying){ 
            if (videoClips.Count > 0){
                index = Random.Range(0, videoClips.Count); //yoinked
                videoPlayer.clip = videoClips[index];
            } 
            Play();
        }
    }
    // void OnCollisionEnter(Collision collision)
    // {
    //     foreach (ContactPoint contact in collision.contacts)
    //     {
    //         Debug.DrawRay(contact.point, contact.normal, Color.white);
    //     }
    //     if (collision.relativeVelocity.magnitude > 2)
    //         Play();
    // }
    private void OnTriggerEnter(Collider other)
    {
        //speed = speed * -1;
        Play();
    }
    void OnTriggerExit(Collider other)
    {
        // Destroy everything that leaves the trigger
        //Destroy(other.gameObject);
        Stop();
    }

    // private void Update(){
    //     if(!videoPlayer.isPlaying){ 
    //         if (videoClips.Count > 0){
    //             //videoPlayer.clip = videoClips[0];
    //             index = Random.Range(0, videoClips.Count); //yoinked
    //             videoPlayer.clip = videoClips[index];
    //         } 
    //         Play();
    //     }
    // }
    public void NextClip()
    {
        index = ++index % videoClips.Count;
        Play();
    }

    public void PreviousClip()
    {
        index = --index % videoClips.Count;
        Play();
    }

    public void RandomClip()
    {
        if (videoClips.Count > 0)
        {
            index = Random.Range(0, videoClips.Count);
            Play();
        }
    }

    public void PlayAtIndex(int value)
    {
        if (videoClips.Count > 0)
        {
            index = Mathf.Clamp(value, 0, videoClips.Count);
            Play();
        }
    }

    public void Play()
    {
        videoMaterial.color = Color.white;
        videoPlayer.Play();
    }

    public void Stop()
    {
        videoMaterial.color = Color.black;
        videoPlayer.Stop();
    }

    public void TogglePlayStop()
    {
        bool isPlaying = !videoPlayer.isPlaying;
        SetPlay(isPlaying);
    }

    public void TogglePlayPause()
    {
        if (videoPlayer.isPlaying)
            videoPlayer.Pause();
        else
            Play();
    }

    public void SetPlay(bool value)
    {
        if (value)
        {
            Play();
        }
        else
        {
            Stop();
        }
    }

    private void ApplyVideoMaterial(VideoPlayer source)
    {
        meshRenderer.material = videoMaterial;
    }

    private void OnValidate()
    {
        var mat = new Material(Shader.Find("Universal Render Pipeline/Lit"));
        videoMaterial = mat;
    }
}