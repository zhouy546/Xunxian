using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Ini : MonoBehaviour {
    private CreateUI createUI;
    private ReadJson readJson;
    //private CameraMover cameraMover;
    private OverRideCameraMove OveridecameraMover;
    private VideoCtr videoCtr;
    private BottomBarCtr bottomBarCtr;
    private CanvasMangager canvasMangager;
    private SoundMangager soundMangager;
    private MainCtr mainCtr;
    private DealWithUDPMessage dealWithUDPMessage;

    private List<Sprite> MainUIsprites = new List<Sprite>();
   private List<Sprite> ScreenProtect = new List<Sprite>();
    //private List<Sprite> DescriptionBG = new List<Sprite>();

    // Use this for initialization
    void Start () {

        StartCoroutine(initialization());
    }

    IEnumerator initialization() {
        //-----------find object-------//
        Screen.SetResolution(7424, 1376, false);

        dealWithUDPMessage = FindObjectOfType<DealWithUDPMessage>();

        readJson = FindObjectOfType<ReadJson>();

        createUI = FindObjectOfType<CreateUI>();

        //cameraMover = FindObjectOfType<CameraMover>();

        OveridecameraMover = FindObjectOfType<OverRideCameraMove>();

        videoCtr = FindObjectOfType<VideoCtr>();

        bottomBarCtr = FindObjectOfType<BottomBarCtr>();

        canvasMangager = FindObjectOfType<CanvasMangager>();

        soundMangager = FindObjectOfType<SoundMangager>();

        mainCtr = FindObjectOfType<MainCtr>();
        //------ini--------------//
        yield return StartCoroutine(readJson.initialization());

        yield return StartCoroutine(ReadAssetImage());

       yield return StartCoroutine( dealWithUDPMessage.Initialization());

        soundMangager.initialization();
        
       StartCoroutine( videoCtr.initialization());  

        createUI.initialization();

      //  StartCoroutine( cameraMover.initialization(new Vector3(0, 15.3f, 300f), new Vector3(0, 15.3f, -30f)));

        OveridecameraMover.initializtion(new Vector3(0, 15.3f, 300f), new Vector3(0, 15.3f, -30f));

        bottomBarCtr.initialization();

        canvasMangager.initialization();



        initializationMainUI();





        mainCtr.initialization();

     //VideoCtr.instance.PlayFullScreenVideoPlayer(ValueSheet.screenProtect);


        canvasMangager.ShowScreenProtect();
    }

    void initializationMainUI() {
        
        for (int i = 0; i < CreateUI.NodeObject.Count; i++)
        {
            NodeCtr nodeCtr = CreateUI.NodeObject[i].GetComponent<NodeCtr>();
            //Debug.Log(MainUIsprites.Count.ToString()+"____"+DescriptionBG.Count.ToString());
            nodeCtr.initialization(MainUIsprites[i]/*, DescriptionBG[i]*/);
        }

        canvasMangager.ScreenProtectNimage.image.sprite = ScreenProtect[0];

        //OverRideCameraMove.instance.ShowMainPicture();
    }

    IEnumerator ReadAssetImage() {
        yield return StartCoroutine(ReadMainUIsprites());

      yield return StartCoroutine(ReadScreenProtect());

        yield return StartCoroutine(ReadDescription());
    }


    IEnumerator ReadDescription() {
        for (int i = 0; i < ReadJson.NodeList.Count; i++)
        {
            List<Sprite> sp = new List<Sprite>();
            string path = "/UI/Description/"+i.ToString()+"/";
           // Debug.Log(path);
            yield return GetSpriteListFromStreamAsset(path, "jpg", sp);

            ValueSheet.DescriptionkeyValuePairs.Add(i, sp);
        }

      //  Debug.Log(ValueSheet.DescriptionkeyValuePairs.Count);
    }



    IEnumerator ReadScreenProtect()
    {
        string path = "/UI/ScreenProtect/";
        yield return GetSpriteListFromStreamAsset(path, "jpg", ScreenProtect);
    }

    IEnumerator ReadMainUIsprites()
    {
        string path = "/UI/MainPage/";
        yield return GetSpriteListFromStreamAsset(path, "jpg", MainUIsprites);
    }

        IEnumerator GetSpriteListFromStreamAsset(string path, string suffix, List<Sprite> sprites)
    {
        List<Texture> texturesList = new List<Texture>();
        string streamingPath = Application.streamingAssetsPath + path;
        DirectoryInfo dir = new DirectoryInfo(streamingPath);

        GetAllFiles(dir, path, suffix);

        foreach (string de in jpgName)
        {
            WWW www = new WWW(Application.streamingAssetsPath + path + de);
            yield return www;
            if (www != null)
            {
                Texture texture = www.texture;
                texture.name = de;
                texturesList.Add(texture);
            }
            if (www.isDone)
            {
                www.Dispose();
            }
        }

        foreach (var texture in texturesList)
        {
            Sprite sprite = Sprite.Create(texture as Texture2D, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
            sprite.name = texture.name;
            sprites.Add(sprite);
        }

        jpgName.Clear();
    }

    List<string> jpgName = new List<string>();

    public void GetAllFiles(DirectoryInfo dir, string Filepath, string suffix)
    {
        FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();   //初始化一个FileSystemInfo类型的实例
        foreach (FileSystemInfo i in fileinfo)              //循环遍历fileinfo下的所有内容
        {
            if (i is DirectoryInfo)             //当在DirectoryInfo中存在i时
            {
                GetAllFiles((DirectoryInfo)i, Filepath, suffix);  //获取i下的所有文件
            }
            else
            {
                string str = i.FullName;        //记录i的绝对路径
                string path = Application.streamingAssetsPath + Filepath;
                string strType = str.Substring(path.Length);

                if (strType.Substring(strType.Length - 3).ToLower() == suffix)
                {
                    if (jpgName.Contains(strType))
                    {
                    }
                    else
                    {
                        jpgName.Add(strType);
                    }
                }
            }
        }
    }
}
