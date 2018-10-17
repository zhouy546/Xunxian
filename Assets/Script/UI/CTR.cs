using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CTR : MonoBehaviour {

	// Use this for initialization
	public virtual void  initialization() {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public virtual void TurnOn_Off(bool b,List<NodeCtr> nodeCtrs)
    {
        foreach (var item in nodeCtrs)
        {
            if (b)
            {
                item.ShowMainPicture();
                item.HideDescription();

            }
            else {
                item.HideDescription();
                item.HideMainPicture();
            }
        }
    }

    public virtual void TurnOn_Off(bool b, List<SubNodeCTR> nodeCtrs)
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
