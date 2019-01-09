using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StripMap : MonoBehaviour
{
    public GridLayoutGroup m_GridLayoutGroup;
    RectTransform GlgRectTransform;
    Transform GlgTransfrom; // Grid Layout Group Transfrom
    public Scrollbar m_HorizontalScollBar;
    float StripMapWidth; //整个条的宽度

    float Segment;//每一段长度 = 格子宽度+格子间隔 
    // Use this for initialization
    void Start()
    {
        GlgRectTransform = m_GridLayoutGroup.gameObject.GetComponent<RectTransform>();
        GlgTransfrom = m_GridLayoutGroup.transform;
        Segment = m_GridLayoutGroup.cellSize.x + m_GridLayoutGroup.spacing.x;
    }

    // Update is called once per frame
    void Update()
    {
        StripMapWidth = GlgRectTransform.sizeDelta.x;
        float locPos = m_HorizontalScollBar.value * StripMapWidth;

        m_HorizontalScollBar.value += Input.GetAxis("Mouse X") / 20;

        Transform Celltransform;
        if (locPos >= (StripMapWidth + Segment) / 2)
        {
            Celltransform = GlgTransfrom.GetChild(0); // 将第一个放到末尾
            Celltransform.SetSiblingIndex(3);
            m_HorizontalScollBar.value -= Segment / StripMapWidth;
        }
        else if (locPos <= (StripMapWidth - Segment) / 2)
        {
            Celltransform = GlgTransfrom.GetChild(3);  // 将最后一个放到开头 
            Celltransform.SetSiblingIndex(0);
            m_HorizontalScollBar.value += Segment / StripMapWidth;
        }
    }
}
