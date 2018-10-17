using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour {
    public int ID;
    public string MainTitle;
    //public string ConstructionArea;
    //public string LandArea;
    public string VideoName;

    public Image MainImage;
    public Image DescriptionImage;


    public Node() {

    }

    public Node(int _ID,string _MainTitle, string _VideoName) {
        ID = _ID;
        MainTitle = _MainTitle;
        VideoName = _VideoName;
    }

    public void setup(Image _MainImage, Image _DescriptionImage) {
        MainImage = _MainImage;
        DescriptionImage = _DescriptionImage;
    }
}
