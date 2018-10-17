using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCtr : CTR
{
    public static MainCtr instance;
    public DefaultNodeParentCtr defaultNodeParentCtr;
    //public GongyiNodeParentCtr gongyiNodeParentCtr;
    //public ECONodeParentCtr eCONodeParentCtr;
	// Use this for initialization
	void Start () {
		
	}

    public override void initialization() {
        if (instance == null) {
            instance = this;
        }

        base.initialization();
        defaultNodeParentCtr.initialization();
       // gongyiNodeParentCtr.initialization();
      //  eCONodeParentCtr.initialization();
        TurnOffAll();
    }


    public void TURN_ON_OFFChild_Default(DefaultNodeParentCtr ctr,bool B,List<NodeCtr> nodeCtrs) {
        ctr.TurnOn_Off(B, nodeCtrs);
    }

    public void TURN_ON_OFFChild_Sub(CTR ctr, bool B, List<SubNodeCTR> nodeCtrs)
    {
        ctr.TurnOn_Off(B, nodeCtrs);
    }

    public void TurnOffAll() {

        defaultNodeParentCtr.TurnOn_Off(false,ValueSheet.nodeCtrs);
        //gongyiNodeParentCtr.TurnOn_Off(false, ValueSheet.Gongyi_nodeCtrs);
        //eCONodeParentCtr.TurnOn_Off(false,ValueSheet.ECO_nodeCtrs);
    }

    public void TurnOnOne(CTR ctr) {
        if (ctr.GetType() == defaultNodeParentCtr.GetType())
        {
            defaultNodeParentCtr.TurnOn_Off(true, ValueSheet.nodeCtrs);
          //  gongyiNodeParentCtr.TurnOn_Off(false, ValueSheet.Gongyi_nodeCtrs);
         //   eCONodeParentCtr.TurnOn_Off(false, ValueSheet.ECO_nodeCtrs);
        }
        //else if (ctr.GetType() == gongyiNodeParentCtr.GetType())
        //{
        //    defaultNodeParentCtr.TurnOn_Off(false, ValueSheet.nodeCtrs);
        //    gongyiNodeParentCtr.TurnOn_Off(true, ValueSheet.Gongyi_nodeCtrs);
        //    eCONodeParentCtr.TurnOn_Off(false, ValueSheet.ECO_nodeCtrs);
        //}
        //else if (ctr.GetType() == eCONodeParentCtr.GetType()) {
        //    defaultNodeParentCtr.TurnOn_Off(false, ValueSheet.nodeCtrs);
        //    gongyiNodeParentCtr.TurnOn_Off(false, ValueSheet.Gongyi_nodeCtrs);
        //    eCONodeParentCtr.TurnOn_Off(true, ValueSheet.ECO_nodeCtrs);
        //}

    }

}
