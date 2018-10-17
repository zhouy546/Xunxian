using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubNodeGroupCtr : MonoBehaviour {
   public Animator animator;
    public DisplayUGUI displayUGUI;
    public string VideoName;
    // Use this for initialization

    private void Awake()
    {
        if (displayUGUI != null) {
            displayUGUI._mediaPlayer = FindObjectOfType<MediaPlayer>();

        }

    }

    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Show() {
        animator.SetBool("Show", true);
        LoadVideo();
    }

    public void Hide() {
        animator.SetBool("Show", false);
    }

    public void LoadVideo() {
        if(displayUGUI!= null){
            VideoCtr.instance.LoadVideoAndPlay(VideoName, true);

        }
    }

    public void StopVideo() {
        if (displayUGUI != null)
        {
            VideoCtr.instance.stopVideo();
        }
    }
}
