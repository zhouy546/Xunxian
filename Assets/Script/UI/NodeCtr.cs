using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCtr : NodeCtrBase {

    public NImage nImageMainImage;

    public NImage nImageDescriptionBGImage;

    public List<Sprite> nImagesDescription = new List<Sprite>();

    public Video_DescriptionCtr DescriptionUI;

    public Transform cameraSetTrans;

    //public Animator MainAnimCtr;

    // Use this for initialization
    void Start() {

    }

    public void FloatingAniamtion() {

    }

    public void initialization(Sprite Mainsprite/*,Sprite BGDescriptionImage*/) {
        nImageMainImage.initialization();
        nImageDescriptionBGImage.initialization();
        SetupMainImage(Mainsprite);
       // SetupUpBgImage(BGDescriptionImage);
        

       DescriptionUI.initialization();
 

        SetupDescriptionImage();

    }

    private void SetupDescriptionImage()
    {
        nImagesDescription= ValueSheet.DescriptionkeyValuePairs[int.Parse(this.name)];

        // Debug.Log(nImagesDescription.Count);
        DescriptionUI.setupImage(nImagesDescription);
    }


    void SetupMainImage(Sprite sprite) {
        nImageMainImage.image.sprite = sprite;
    }

    void SetupUpBgImage(Sprite sprite) {
        nImageDescriptionBGImage.image.sprite = sprite;
    }

    public void SetupDescruptionUI() {
        //switch (switch_on)
        //{
        //    default:
        //}
    }


    public void PlayVideo() {

     // string path =   ReadJson.NodeList[CameraMover.instance.CurrentID].VideoName;
        string path = ReadJson.NodeList[OverRideCameraMove.instance.TargetID].VideoName;
        VideoCtr.instance.LoadVideoAndPlay(path,true);
    }

    public void StopVideo() {
        VideoCtr.instance.stopVideo();
    }

    public override void ShowDescription() {

        DescriptionUI.TriggerAnimation(true);
        showDescriptionBGImage();
        PlayVideo();
    }


    public override void HideDescription() {
        DescriptionUI.TriggerAnimation(false);
        hideDescriptionBGImage();

        StopVideo();
    }


    public override void HideMainPicture() {
        MainAnimCtr.SetBool("Show", false);

    }

    public override void ShowMainPicture()
    {
        MainAnimCtr.SetBool("Show", true);

    }


    public void showDescriptionBGImage() {
        nImageDescriptionBGImage.ShowAll();
    }

    public void hideDescriptionBGImage()
    {
        nImageDescriptionBGImage.HideAll();
    }
}
