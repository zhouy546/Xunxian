using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubNodeCTR : NodeCtrBase
{
    public ImageClusterCtr imageClusterCtr;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void ShowMainPicture()
    {
        base.ShowMainPicture();
        //foreach (var item in imageClusterCtr.Nimages)
        //{
        //    item.ShowAll();
        //}

        //imageClusterCtr.Display(0);


    }

    public override void HideMainPicture()
    {
        imageClusterCtr.hideAll();

        base.HideMainPicture();
    }
}
