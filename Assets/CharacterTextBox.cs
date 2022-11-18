using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterTextBox : MonoBehaviour
{
    public string Name;
    [SerializeField] TMP_Text mTextOverHead;
    Transform mTransform;
    Transform mTextOverTransform;
    void Awake()
    {
        mTransform = transform;
        mTextOverTransform = mTextOverHead.transform;
    }

    public void MoveText()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(mTransform.position);
        // add a tiny bit of height?
        screenPos.y += 2; // adjust as you see fit.
        mTextOverTransform.position = screenPos;
    }

    void LateUpdate()
    {
        //Vector3 screenPos = Camera.main.WorldToScreenPoint(mTransform.position);
        //// add a tiny bit of height?
        //screenPos.y += 2; // adjust as you see fit.
        //mTextOverTransform.position = screenPos;
    }
}
