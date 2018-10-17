using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class NodeCtrBase : MonoBehaviour
{
    public Animator MainAnimCtr;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void ShowDescription()
    {

    }

    public virtual void HideDescription() {

    }


    public virtual void ShowMainPicture()
    {
    }

    public virtual void HideMainPicture()
    {
    }
}
