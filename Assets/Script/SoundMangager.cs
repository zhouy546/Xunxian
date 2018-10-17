using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMangager : MonoBehaviour {
    public AudioSource audioSource;
    public AudioSource BGM;
    public List<AudioClip> audioClips = new List<AudioClip>();

    public MediaPlayer mediaPlayer;
    public static SoundMangager instance;

    public string currentBGM = "";

    bool isMute;
	// Use this for initialization
	public void initialization() {
        if (instance == null) {
            instance = this;
        }

        ValueSheet.NameAudio_keyValuePairs.Add("Through", audioClips[0]);
        ValueSheet.NameAudio_keyValuePairs.Add("Select", audioClips[1]);
        ValueSheet.NameAudio_keyValuePairs.Add("BGM", audioClips[2]);
        ValueSheet.NameAudio_keyValuePairs.Add("Recycle", audioClips[3]);
        SetUpbgmVolume(ValueSheet.BGMVolume);

    }

    public void Update()
    {

    }

    public void SetUpbgmVolume(float Volume) {
        BGM.volume = Volume;
    }

    public void SetMainVideoVolume(bool ismute) {
        mediaPlayer.Control.MuteAudio(ismute);
        isMute = ismute;
    }

  

    public void GoThrough() {
        //audioSource.loop = true;
        audioSource.clip = ValueSheet.NameAudio_keyValuePairs["Through"];
        audioSource.Play();
    }

    public void Recycle()
    {
        //audioSource.loop = true;
        audioSource.clip = ValueSheet.NameAudio_keyValuePairs["Recycle"];
        audioSource.Play();
    }


    public void StopSound() {
        audioSource.loop = false;
        audioSource.Stop();
    }

    public void Select()
    {
        audioSource.clip = ValueSheet.NameAudio_keyValuePairs["Select"];
        audioSource.PlayOneShot(ValueSheet.NameAudio_keyValuePairs["Select"]);
    }

    public void PlayBGM(string bgmStr) {

        if (bgmStr != ""&& isMute == false) {
            currentBGM = bgmStr;
            BGM.clip = ValueSheet.NameAudio_keyValuePairs[bgmStr];
            //BGM.PlayOneShot(ValueSheet.NameAudio_keyValuePairs[bgmStr]);

            BGM.Play();
            BGM.loop = true;
        }

    }

    public void StopBGM()
    {
        BGM.Stop();
    }
}
