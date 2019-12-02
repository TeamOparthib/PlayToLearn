using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoTimer : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;

    void Start()
    {
        StartCoroutine(PlayVideo());

    }

    IEnumerator PlayVideo()
    {
        videoPlayer.Prepare();

        WaitForSeconds wait_for_secons = new WaitForSeconds(1);

        while(!videoPlayer.isPrepared)
        {
            yield return wait_for_secons;
            break;
        }

        rawImage.texture = videoPlayer.texture;

        videoPlayer.Play();

        WaitForSeconds wait_for_the_video = new WaitForSeconds((float)videoPlayer.length);

        yield return wait_for_the_video;

        Application.LoadLevel("Menu");

    }
}
