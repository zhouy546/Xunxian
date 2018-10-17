//*********************❤*********************
// 
// 文件名（File Name）：	DealWithUDPMessage.cs
// 
// 作者（Author）：			LoveNeon
// 
// 创建时间（CreateTime）：	Don't Care
// 
// 说明（Description）：	接受到消息之后会传给我，然后我进行处理
// 
//*********************❤*********************

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Linq;

public class DealWithUDPMessage : MonoBehaviour {
    public static DealWithUDPMessage instance;

    // public GameObject wellMesh;
    private string dataTest;
    // public static char[] sliceStr;
    private Vector3 CamRotation;

    //public LogoWellCtr logoWellCtr;
    //private bool enterTrigger, exitTrigger;
    /// <summary>
    /// 消息处理
    /// </summary>
    /// <param name="_data"></param>
    public void MessageManage(string _data)
    {
        if (_data != "")
        {
            dataTest = _data;

            Debug.Log(dataTest);

            if (dataTest == "10000")//返回
            {
                GoingBack();
                SoundMangager.instance.currentBGM = "";
                SoundMangager.instance.StopBGM();
            }


            else if (dataTest == "10008")//形象短片
            {
                LoadMainVideo();
            }

            else if (dataTest == "10031")
            {//音乐开
                SoundMangager.instance.SetMainVideoVolume(false);
                SoundMangager.instance.PlayBGM(SoundMangager.instance.currentBGM);



            }
            else if (dataTest == "10032")
            {//音乐关
                SoundMangager.instance.SetMainVideoVolume(true);

                SoundMangager.instance.StopBGM();
            }



            if (int.Parse(dataTest) >= 10001 && int.Parse(dataTest) <= 10007) {

                //Debug.Log(dataTest+"测试");
                GoToOcean(ValueSheet.nodeCtrs, MainCtr.instance.defaultNodeParentCtr);

                if (dataTest == "10001")
                {
                    //CameraMover.instance.CurrentID = 0;
                    OverRideCameraMove.instance.Go(0, 0);
                }
                else if (dataTest == "10002")
                {
                    //CameraMover.instance.CurrentID = 1;
                    OverRideCameraMove.instance.Go(1, 1);
                }
                else if (dataTest == "10003")
                {
                    // CameraMover.instance.CurrentID = 2;
                    OverRideCameraMove.instance.Go(2, 1);
                }
                else if (dataTest == "10004")
                {
                    // CameraMover.instance.CurrentID = 3;
                    OverRideCameraMove.instance.Go(3, 1);
                }
                else if (dataTest == "10005")
                {
                    // CameraMover.instance.CurrentID = 4;
                    OverRideCameraMove.instance.Go(4, 2);
                }
                else if (dataTest == "10006")
                {
                    //  CameraMover.instance.CurrentID = 5;
                    OverRideCameraMove.instance.Go(5, 2);
                }
                else if (dataTest == "10007")
                {
                    // CameraMover.instance.CurrentID = 6;
                    OverRideCameraMove.instance.Go(6, 2);
                }
            }


        }

    }



    public void GoToOcean(List<SubNodeCTR> _nodeCtrs, CTR _ctr, List<GameObject> TitleList)
    {
        // ValueSheet.CurrentNodeCtr = _nodeCtrs;
        ToOceanGeneral(new Vector3(0, 15.3f, 300f), new Vector3(0, 33.3f, -68.1f), true, false, _ctr);

        _nodeCtrs[0].imageClusterCtr.Display(0, TitleList);
        // MainCtr.instance.TURN_ON_OFFChild_Sub(_ctr, true, _nodeCtrs);

    }


    public void GoToOcean(List<NodeCtr> _nodeCtrs, DefaultNodeParentCtr _ctr) {
        // ValueSheet.CurrentNodeCtr = _nodeCtrs;
        ToOceanGeneral(new Vector3(0, 15.3f, 300f), new Vector3(0, 15.3f, -30f), true, true, _ctr);
        // MainCtr.instance.TURN_ON_OFFChild_Default(_ctr, true, _nodeCtrs);
        //BottomBarCtr.instance.UpdateBottomBar(CameraMover.instance.CurrentID + 1, ReadJson.NodeList.Count);

        BottomBarCtr.instance.UpdateBottomBar(OverRideCameraMove.instance.TargetID + 1, ReadJson.NodeList.Count);
    }

    void ToOceanGeneral(Vector3 pos, Vector3 _targetPos, bool isTurnOnSideImage, bool building, CTR ctr)
    {

        //logoWellCtr.TurnOffLogoWell();
        MainCtr.instance.TurnOnOne(ctr);
        SoundMangager.instance.Select();
        //Debug.Log(VideoCtr.instance.FullScreenVideoPlayer.Control.IsPlaying());
        if (VideoCtr.instance.FullScreenVideoPlayer.Control.IsPlaying())
        {
            CanvasMangager.instance.HideAlltitleText();
            VideoCtr.instance.StopFullScreenVideoPlayer();
            VideoCtr.instance.FullScreenVideoPlayer.m_VideoPath = "";

            Debug.Log("video to ocean");
            OverRideCameraMove.instance.initializtion(pos);

            SoundMangager.instance.StopBGM();
            SoundMangager.instance.PlayBGM("BGM");
            CanvasMangager.instance.TurnOffAllTitle();
            CanvasMangager.instance.ONOFF(isTurnOnSideImage, building);
           // StartCoroutine(CanvasMangager.instance.Fade());


        }

        Debug.Log(CanvasMangager.instance.isInScreenProtect);
        if (CanvasMangager.instance.isInScreenProtect) {
            CanvasMangager.instance.HideAlltitleText();
         
            VideoCtr.instance.FullScreenVideoPlayer.m_VideoPath = "";
            CanvasMangager.instance.HideScreenProtect();
            OverRideCameraMove.instance.initializtion(pos);

            SoundMangager.instance.StopBGM();
            SoundMangager.instance.PlayBGM("BGM");
            CanvasMangager.instance.TurnOffAllTitle();

            CanvasMangager.instance.ONOFF(isTurnOnSideImage, building);
            //StartCoroutine(CanvasMangager.instance.Fade());
        }
    }



    public void GoingBack() {

        // StartCoroutine(ReplaceFullScreenVideo(ValueSheet.screenProtect));
        //MainCtr.instance.TurnOffAll();

        CanvasMangager.instance.ShowScreenProtect();
         VideoCtr.instance.StopFullScreenVideoPlayer();


        OverRideCameraMove.instance.HideAllDescription();
        CanvasMangager.instance.TurnOffAllTitle();
    }

    public void LoadMainVideo() {

     StartCoroutine(ReplaceFullScreenVideo(ValueSheet.ProjcetHighLight,false));
        SoundMangager.instance.StopBGM();

        CanvasMangager.instance.HideScreenProtect();
    }


    public IEnumerator ReplaceFullScreenVideo(string videoName,bool isLoop = true) {
 
       CanvasMangager.instance.HideCurretTitle();



        MainCtr.instance.TurnOffAll();

        OverRideCameraMove.instance.HideAllDescription();

        //CameraMover.instance.HideMainPicture();

        CanvasMangager.instance.TurnOffAllTitle();
        // CanvasMangager.instance.ONOFF(false,-1,false);


        VideoCtr.instance.StopFullScreenVideo();
        yield return new WaitForSeconds(.5f);
        VideoCtr.instance.PlayFullScreenVideoPlayer(videoName,isLoop);
        VideoCtr.instance.SentOnce = false;
        StartCoroutine(CanvasMangager.instance.Fade());

    }


    private void Awake()
    {

    }

    public IEnumerator Initialization() {
        if (instance == null)
        {
            instance = this;
        }
        yield return new  WaitForSeconds(0.01f);
    }

    public void Start()
    {

    }


    private void Update()
    {


        //Debug.Log("数据：" + dataTest);  
    }

}
