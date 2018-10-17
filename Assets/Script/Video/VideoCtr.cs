using RenderHeads.Media.AVProVideo;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VideoCtr : MonoBehaviour {
    public bool SentOnce = false;

    public static VideoCtr instance;
    MediaPlayer mediaPlayer;
    public DisplayUGUI displayUGUI;
    public MediaPlayer FullScreenVideoPlayer;
    public IEnumerator initialization() {

        if(instance == null)
        {
            instance = this;
        }
        mediaPlayer = this.GetComponent<MediaPlayer>();
        yield return new WaitForSeconds(5);
        StartCoroutine(Check());
       
    }

    public void LoadVideoAndPlay(string path, bool isLoop = false) {

        mediaPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, path, true);
        mediaPlayer.Control.SetLooping(isLoop);

    }

    public void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)) {
            VideoFadeOut();
        }

     }


    void VideoFadeOut() {

    }

    IEnumerator Check() {

        if (FullScreenVideoPlayer.Control.IsFinished() && FullScreenVideoPlayer.m_VideoPath == ValueSheet.ProjcetHighLight)
        {
            if (!SentOnce)
            {

                SentOnce = true;
                
                Debug.Log("dooing");
                DealWithUDPMessage.instance.GoingBack();


            }

        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(Check());
    }


    public void StopFullScreenVideoPlayer() {
        displayUGUI.GetComponent<Animator>().SetBool("Show", false);
        Debug.Log("doing leantween");
        StopFullScreenVideo();

    }

    public void PlayFullScreenVideoPlayer(string path, bool isLoop = true) {

        displayUGUI.GetComponent<Animator>().SetBool("Show", true);
        PlayFullScreenVideo(path, isLoop);

         
    }

    public void StopFullScreenVideo() {
        Debug.Log("stop full screen video");
        FullScreenVideoPlayer.Stop();
    }

    public void PlayFullScreenVideo(string path,bool isLoop) {
        FullScreenVideoPlayer.m_VideoPath = path;
        FullScreenVideoPlayer.Control.SetLooping(isLoop);
        FullScreenVideoPlayer.OpenVideoFromFile(MediaPlayer.FileLocation.RelativeToStreamingAssetsFolder, path, true);
    }

    public void stopVideo() {
        mediaPlayer.Stop();
    }

}
