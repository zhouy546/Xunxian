using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueSheet : MonoBehaviour {
    public static string screenProtect = "屏幕保护.mp4";

    public static string CultureAndECON = "商业·文化.mp4";

    public static string ProjcetHighLight = "浚县沙盘.mp4";

    public static string Gongyi = "社会公益.mp4";

    public static string Co = "合作伙伴.mp4";

    public static float BGMVolume = 0;



    public static float NodeDistance = 30f;

    public static Dictionary<int, GameObject> ID_Node_keyValuePairs = new Dictionary<int, GameObject>();
    public static Dictionary<int, GameObject> ID_ECO_Node_keyValuePairs = new Dictionary<int, GameObject>();
    public static Dictionary<int, GameObject> ID_Gongyi_Node_keyValuePairs = new Dictionary<int, GameObject>();

    public static Dictionary<int, List<Sprite>> DescriptionkeyValuePairs = new Dictionary<int, List<Sprite>>();
    public static Dictionary<string, AudioClip> NameAudio_keyValuePairs = new Dictionary<string, AudioClip>();



    public static List<NodeCtr> nodeCtrs = new List<NodeCtr>();
    public static List<SubNodeCTR> ECO_nodeCtrs = new List<SubNodeCTR>();
    public static List<SubNodeCTR> Gongyi_nodeCtrs = new List<SubNodeCTR>();

    public static List<NodeCtr> CurrentNodeCtr = new List<NodeCtr>();
    public static bool IsInMainMenu = true;


}
