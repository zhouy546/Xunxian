using RenderHeads.Media.AVProVideo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video_DescriptionCtr : MonoBehaviour {
    public List<NImage> nImagesDescription = new List<NImage>();

    public Animator animator;
    public DisplayUGUI displayUGUI;

    public virtual void initialization() {
        animator = this.GetComponent<Animator>();
        displayUGUI = GetComponentInChildren<DisplayUGUI>();
        displayUGUI._mediaPlayer = FindObjectOfType<MediaPlayer>();
    }

    // Update is called once per frame
    void Update () {

	}

    public virtual void TriggerAnimation(bool onoff) {
     //   Debug.Log("triggle animation");

        animator.SetBool("Defalut",onoff);

    }

    public virtual void setupImage(List<Sprite> sprites)
    {

    }

    public virtual void setupImage(Sprite L_sprite, Sprite R_sprite)
    {

    }
}
