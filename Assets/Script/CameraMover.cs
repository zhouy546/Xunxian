using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {
    public static CameraMover instance;

    LTDescr cameraLfoatTween;
    private int perviouseID = 0;
    private int currentID = 0;
    public int CurrentID {
        get { return currentID; }
        set {

            
            currentID = value;

  
                tragetPos = new Vector3(0, 15.3f, -30 + currentID * ValueSheet.NodeDistance);

                if (ValueSheet.IsInMainMenu)//第一次进来
                {
                    StartCoroutine(MenuToDes());
                }
                else//之后切换
                {

                    StartCoroutine(DesToDes());
                }

               // BottomBarCtr.instance.ChangeDot(CurrentID);
            BottomBarCtr.instance.UpdateBottomBar(CurrentID + 1, ReadJson.NodeList.Count);
               // CanvasMangager.instance.Building.SetActive(false);


        }
    }


    public void stopCameraFloating() {
        if (cameraLfoatTween != null) {
            Debug.Log("stop floating");
            LeanTween.cancel(cameraLfoatTween.id);
        }
    }

    public void CameraFloation() {
       float x = UnityEngine.Random.Range(-3,3);
        float y = UnityEngine.Random.Range(-3, 3);
        float time = UnityEngine.Random.Range(10, 12);

        Vector3 Pposition = this.transform.position;
        Debug.Log(" floating");
        Vector3 pos = new Vector3(this.transform.position.x+x, this.transform.position.y+y, this.transform.position.z);
        cameraLfoatTween = LeanTween.move(this.gameObject, pos, time).setOnComplete(delegate() {
            MoveTopos(Pposition, time, CameraFloation);
        });
    }

    public void GoingInTheWell()
    {
      StartCoroutine(MoveTo(new Vector3(65f, 33.3f, 400f), 0f));

        this.transform.rotation = Quaternion.Euler(0, 90, 0);

    }

    public void LookWellLeft() {
        LeanTween.rotateY(this.gameObject, 66f, .5f);
    }

    public void LookWellRight()
    {
        LeanTween.rotateY(this.gameObject, 112f, .5f);
    }

    public void LookWellMid()
    {
        LeanTween.rotateY(this.gameObject, 90f, .5f);
    }


    IEnumerator DesToDes() {
       
        SoundMangager.instance.GoThrough();
        yield return StartCoroutine(ToMenu());

        yield return StartCoroutine(ToPosition());
        yield return StartCoroutine(GoingIn());
        perviouseID = currentID;
        SoundMangager.instance.StopSound();
       // CameraFloation();
    }




    IEnumerator ToMenu() {
        yield return StartCoroutine(MoveTo(perviousPos,.5f));
        Debug.Log(perviouseID.ToString());
        HideDescription(perviouseID);
        ShowMainPicture();
       RotateCamera(Vector3.zero);
        yield return new WaitForSeconds(1f);
        //perviouseID = currentID;
    }

    IEnumerator MenuToDes() {
  
        Debug.Log("MenuToDes");
        SoundMangager.instance.GoThrough();
        yield return StartCoroutine(ToPosition());
        yield return StartCoroutine(GoingIn());
        perviouseID = currentID;
        SoundMangager.instance.StopSound();
        //CameraFloation();
    }


    IEnumerator GoingIn() {
        ShowDescription(currentID);
      yield return  StartCoroutine( HideMainPicture());
        yield return StartCoroutine(MoveInPosition());
    }

    IEnumerator ToPosition() {
        yield return StartCoroutine(MoveTo(tragetPos, Mathf.Abs(currentID - perviouseID) * .4f));

    }




    public Vector3 tragetRotation;

    
    public Vector3 target_Pos = new Vector3(0, 15.3f, -30f);
    public Vector3 tragetPos {
        get { return target_Pos; }
        set {
            target_Pos = value;
            //isArrived = false;
        }
    }
    private Vector3 perviousPos;
    private float easeingValue = 0.05f;
    private float RoteaseingValue = 0.005f;

    public IEnumerator initialization(Vector3 defaultpos, Vector3 _targetPos) {
        if (instance == null)
        {
            instance = this;

        }
       

        perviouseID = currentID = 0;

        //    HideMainPicture(); new Vector3(0, 15.3f, 300f)
      //  stopCameraFloating();
        //Debug.Log("初始化 海洋");
        ValueSheet.IsInMainMenu = true;
        SetCameraTransDefault(defaultpos);
        tragetPos = _targetPos;// new Vector3(0, 15.3f, -30f);

        yield return new WaitForSeconds(.4f);
         //Debug.Log("初始化 海洋 目标位置" + tragetPos.ToString());
       
        StartCoroutine(MoveTo(tragetPos, 1f));
        //CanvasMangager.instance.Building.SetActive(true);
    }

    public void initialization(Vector3 defaultpos) {
        perviouseID = currentID = 0;
        ValueSheet.IsInMainMenu = true;
        SetCameraTransDefault(defaultpos);
    }

    public void SetCameraTransDefault(Vector3 pos ) {
        this.transform.position = pos;
        this.transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log(target_Pos);

        
    }


    public IEnumerator MoveTo(Vector3 pos,float time, Action action=null) {
      //  stopCameraFloating();
        //Debug.Log("Move TO POS"+pos.ToString());
        LeanTween.move(this.gameObject, pos, time).setOnUpdate(delegate(Vector3 v) {

        }).setOnComplete(delegate () {
            if (action != null) {
                action();
            }
        }).setEase(LeanTweenType.notUsed);
        yield return new WaitForSeconds(time);
    }

    public void MoveTopos(Vector3 pos, float time, Action action = null)
    {
        LeanTween.move(this.gameObject, pos, time).setOnComplete(delegate () {
            if (action != null)
            {
                action();
            }
        }).setEase(LeanTweenType.notUsed);
    }


    public IEnumerator MoveInPosition() {
        //isArrived = false;
        perviousPos = transform.position;
       // Debug.Log("set false");


        //HideMainPicture();

      //  Debug.Log("traget pos");
        tragetPos = ValueSheet.ID_Node_keyValuePairs[currentID].GetComponent<NodeCtr>().cameraSetTrans.position;

        if (currentID % 2 == 0)//偶数向左奇数向右
        {

            tragetRotation = new Vector3(0, -34.1f, 0);
            RotateCamera(tragetRotation);
        }
        else
        {
            tragetRotation = new Vector3(0, 34.1f, 0);
            RotateCamera(tragetRotation);
        }
        //ShowDescription();

        ValueSheet.IsInMainMenu = false;

        SoundMangager.instance.Recycle();
     yield return  StartCoroutine(MoveTo(tragetPos,.5f));
    }

    public IEnumerator HideMainPicture() {
        foreach (var item in ValueSheet.nodeCtrs)
        {
            item.HideMainPicture();
        }
        yield return new WaitForSeconds(0);
    }

    public void ShowMainPicture() {
        foreach (var item in ValueSheet.nodeCtrs)
        {
            item.ShowMainPicture();
        }
    }

    void RotateCamera(Vector3 angle,float time = .5f)
    {
        LeanTween.rotateY(this.gameObject, angle.y, time).setEase(LeanTweenType.notUsed);
       

    }


    void ShowDescription(int id) {


        ValueSheet.nodeCtrs[id].ShowDescription();
    }

    void HideDescription(int id)
    {

        ValueSheet.nodeCtrs[id].HideDescription();
    }

    public void HideAllDescription() {
        foreach (var item in ValueSheet.nodeCtrs)
        {
            item.HideDescription();
        }
    }
}
