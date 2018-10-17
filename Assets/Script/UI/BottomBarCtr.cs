using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomBarCtr : MonoBehaviour {
    public static BottomBarCtr instance;

    public RectTransform ValueBarRectTransform;

    public RectTransform ArrowRectTransform;

    public float MaxMoveDis = 7424
        ;
    float value = 0;

    Rect theRect;
    // public Color HighlightColor;
    //public GameObject dot;
    //public List<NImage> dots = new List<NImage>();

    //public NImage perviousDot;
    //public NImage CurrentDot;

    public void UpdateBottomBar(int currentNUM,int MaxNum) {
      
        float rate = (float) currentNUM / (float)MaxNum;
        //Debug.Log("currentNUM: " + currentNUM.ToString() + "   " + "MaxNum: " + MaxNum);

       // Debug.Log(rate);
        float targetVal = MaxMoveDis * rate;

        LeanTween.value(value, targetVal, 1f).setOnUpdate(delegate (float val) {
           // Debug.Log("UPDATE Bottom val = " + val.ToString());
          //  SetTheBar(val);
            SetArrow(val);
        }).setOnComplete(delegate() {
            value = targetVal;  
        });
        SetTheBar(rate);
    }

    private void SetTheBar(float rate) {
        LeanTween.scaleX(ValueBarRectTransform.gameObject, rate, 1f);

    }

    private void SetArrow(float X) {
        ArrowRectTransform.position = new Vector3(X, ArrowRectTransform.position.y, ArrowRectTransform.position.z);
    }


    public void initialization() {
        //for (int i = 0; i < ReadJson.NodeList.Count; i++)
        //{
        //    GameObject g = Instantiate(dot);
        //    g.transform.SetParent(this.transform);
        //    dots.Add(g.GetComponent<NImage>());

        //}
        //foreach (var item in dots)
        //{
        //    item.initialization();
        //}

        //CurrentDot = dots[CameraMover.instance.CurrentID];
        //CurrentDot.ChangeColor(HighlightColor, .5f);

        if (instance == null)
        {
            instance = this;
        }
        theRect = ValueBarRectTransform.rect;
    }

    public void ChangeDot(int num) {
        //perviousDot = CurrentDot;
        //if (perviousDot != null) {
        //    perviousDot.ChangeColor(Color.white, .5f);
        //}
   

        //CurrentDot = dots[num];
        //CurrentDot.ChangeColor(HighlightColor, .5f);
    }

}
