using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GongyiNodeParentCtr : CTR
{
    public static GongyiNodeParentCtr instance;



    public override void initialization() {
        base.initialization();
        if (instance == null)
        {
            instance = this;
        }
    }
    // Update is called once per frame
    void Update () {
		
	}

    public override void TurnOn_Off(bool b, List<SubNodeCTR> nodeCtrs)
    {
       // Debug.Log(nodeCtrs.Count);
        foreach (var item in nodeCtrs)
        {
            if (b)
            {
                item.ShowMainPicture();
              //item.HideDescription();

            }
            else
            {
                //item.HideDescription();
                item.HideMainPicture();
            }
        }
    }
}
