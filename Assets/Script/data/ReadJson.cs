using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using System.IO;

using LitJson;

using UnityEngine.UI;

public class ReadJson : MonoBehaviour {

    public static List<Node> NodeList = new List<Node>();

    //public static List<Node> ECO_NodeList = new List<Node>();

//    public static List<Node> Gongyi_NodeList = new List<Node>();

    public static ReadJson instance;

  //  public  Ntext ntext;

    private JsonData itemDate;

    private string jsonString;

 


    public IEnumerator initialization() {
        if (instance == null)
        {

            instance = this;

        }

     yield return   StartCoroutine(readJson());
    }

    IEnumerator readJson() {
        string spath = Application.streamingAssetsPath + "/information.json";

        Debug.Log(spath);

        WWW www = new WWW(spath);

        yield return www;

        jsonString = System.Text.Encoding.UTF8.GetString(www.bytes);

        JsonMapper.ToObject(www.text);

       itemDate = JsonMapper.ToObject(jsonString.ToString());


        for (int i = 0; i < itemDate["information"].Count; i++)

        {
            SetupNodeList(i, ref NodeList);

        }

        //for (int i = 0; i < itemDate["ECO"].Count; i++)

        //{
        //    SetupNodeList(i, ref ECO_NodeList);
        //}

        //for (int i = 0; i < itemDate["Gongyi"].Count; i++)
        //{
        //    SetupNodeList(i, ref Gongyi_NodeList);

        //}


        for (int i = 0; i < itemDate["Setup"].Count; i++)
        {
            ValueSheet.BGMVolume = float.Parse(itemDate["Setup"][i]["BGMVolume"].ToString());//get id;        
        }


        //setupUI(bigTitle);

    }

    void SetupNodeList(int i, ref List<Node> nodes)
    {
        int id;
        string bigTitle;
        string VideoPath;

        id = int.Parse(itemDate["information"][i]["id"].ToString());//get id;

        bigTitle = itemDate["information"][i]["BigTitle"].ToString();//get bigtitle;

        VideoPath = itemDate["information"][i]["VideoPath"].ToString();//get video path;

        nodes.Add(new Node(id, bigTitle, VideoPath));
    }
}
