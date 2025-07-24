using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour
{
    public static VideoController instance;

    public VideoClip[] videoClips;

    [SerializeField]
    private VideoPlayer videoPlayer;

    private void Awake()
    {
        instance = this;
        videoPlayer.clip = videoClips[0];
    }

    public void PlayVideo(int index)
    {
        videoPlayer.clip = videoClips[index];
    }
}
