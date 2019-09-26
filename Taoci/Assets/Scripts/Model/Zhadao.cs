using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TaoCi
{
    public class Zhadao : DeviceBase
    {
        bool b = true;

        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                #region
                case 1003001:
                    if (b == true)
                    {
                        OpenEle();
                        transform.Find("Arrow").gameObject.SetActive(false);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }                    
                    break;
                case 1004006:
                    if (true)
                    {
                        CloseEle();
                        transform.Find("Arrow").gameObject.SetActive(false);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                #endregion
                #region
                case 2003001:
                    if (b == true)
                    {
                        OpenEle();
                        transform.Find("Arrow").gameObject.SetActive(false);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 2004006:
                    if (true)
                    {
                        CloseEle();
                        transform.Find("Arrow").gameObject.SetActive(false);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                #endregion
                #region
                case 3003001:
                    if (b == true)
                    {
                        OpenEle();
                        transform.Find("Arrow").gameObject.SetActive(false);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 3004006:
                    if (true)
                    {
                        CloseEle();
                        transform.Find("Arrow").gameObject.SetActive(false);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                #endregion
                #region
                case 4003001:
                    if (b == true)
                    {
                        OpenEle();
                        transform.Find("Arrow").gameObject.SetActive(false);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                case 4004005:
                    if (true)
                    {
                        CloseEle();
                        transform.Find("Arrow").gameObject.SetActive(false);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    }
                    break;
                #endregion
                default:
                    break;
            }
        }

        private void FixedUpdate()
        {
            switch (UIManager.Instance.step)
            {
                #region
                case 1003001:
                    if (b)
                    {
                        transform.Find("Arrow").gameObject.SetActive(true);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 1003002:
                    b = true;
                    break;
                case 1004006:
                    if (b)
                    {
                        transform.Find("Arrow").gameObject.SetActive(true);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 1004007:
                    b = true;
                    break;
                #endregion
                #region
                case 2003001:
                    if (b)
                    {
                        transform.Find("Arrow").gameObject.SetActive(true);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 2003002:
                    b = true;
                    break;
                case 2004006:
                    if (b)
                    {
                        transform.Find("Arrow").gameObject.SetActive(true);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 2004007:
                    b = true;
                    break;
                #endregion
                #region
                case 3003001:
                    if (b)
                    {
                        transform.Find("Arrow").gameObject.SetActive(true);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 3003002:
                    b = true;
                    break;
                case 3004006:
                    if (b)
                    {
                        transform.Find("Arrow").gameObject.SetActive(true);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 3004007:
                    b = true;
                    break;
                #endregion
                #region
                case 4003001:
                    if (b)
                    {
                        transform.Find("Arrow").gameObject.SetActive(true);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                    }
                    break;
                case 4003002:
                    b = true;
                    break;
                case 4004005:
                    if (b)
                    {
                        transform.Find("Arrow").gameObject.SetActive(true);
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 4004006:
                    b = true;
                    break;
                #endregion
                default:
                    break;
            }
        }

        private void OpenEle()
        {
            b = false;
            transform.Find("ZhaDao02").DOLocalRotate(new Vector3(0, -90, -90), 1f).OnComplete(()=> UIManager.Instance.AddStep());
        }

        private void CloseEle()
        {
            b = false;
            transform.Find("ZhaDao02").DOLocalRotate(new Vector3(0, -90, -235), 1f).OnComplete(()=> UIManager.Instance.AddStep());
        }
    }
}
