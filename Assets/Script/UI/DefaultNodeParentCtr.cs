using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultNodeParentCtr : CTR
{
    public static DefaultNodeParentCtr instance;

    public override void initialization() {
        base.initialization();
        if (instance == null) {
            instance = this;
        }
    }


	
	// Update is called once per frame
	void Update () {
		
	}

    public override void  TurnOn_Off(bool b, List<NodeCtr> nodeCtrs)
    {
        foreach (var item in nodeCtrs)
        {
            if (b)
            {
                item.ShowMainPicture();
                item.HideDescription();

            }
            else
            {
                item.HideDescription();
                item.HideMainPicture();
            }
        }
    }
}
