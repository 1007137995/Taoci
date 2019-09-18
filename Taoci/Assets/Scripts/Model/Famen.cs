using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TaoCi
{
    public class Famen : DeviceBase
    {
        private Transform lumen;
        private Transform aimPos;
        private Vector3 oldPos;
        bool b = true;

        private void Start()
        {
            aimPos = transform.parent.Find("Pos");
            oldPos = transform.localPosition;
            lumen = transform.parent.parent.Find("Lumen");
            lumen.GetComponent<Lumen>().FamenClose += RotateUp;
        }

        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                #region
                case 1002002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    RotateDown();
                    break;
                case 1005002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    RotateDown();
                    break;
                #endregion
                #region
                case 2002002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    RotateDown();
                    break;
                case 2005002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    RotateDown();
                    break;
                #endregion
                #region
                case 3002002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    RotateDown();
                    break;
                case 3005002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    RotateDown();
                    break;
                #endregion
                #region
                case 4002002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    RotateDown();
                    break;
                case 4005002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    RotateDown();
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
                case 1002002:                    
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }                    
                    break;
                case 1002004:
                    b = true;
                    break;
                case 1005002:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 1005003:
                    b = true;
                    break;
                #endregion
                #region
                case 2002002:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 2002004:
                    b = true;
                    break;
                case 2005002:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 2005003:
                    b = true;
                    break;
                #endregion
                #region
                case 3002002:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 3002004:
                    b = true;
                    break;
                case 3005002:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 3005003:
                    b = true;
                    break;
                #endregion
                #region
                case 4002002:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 4002004:
                    b = true;
                    break;
                case 4005002:
                    if (b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 4005003:
                    b = true;
                    break;
                #endregion
                default:
                    break;
            }
        }

        public void RotateDown()
        {
            transform.GetComponent<Collider>().enabled = false;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(transform.DOLocalRotate(new Vector3(0, 450, 0), 1.5f, RotateMode.LocalAxisAdd));
            sequence.Join(transform.DOLocalMoveY(-0.06f, 1.5f));
            //sequence.Append(transform.DOLocalMove(aimPos.localPosition, 2));
            //sequence.Join(transform.DOLocalRotate(aimPos.localEulerAngles, 2));
            sequence.Append(transform.parent.DOLocalRotate(new Vector3(0, 180, -180), 1));
            sequence.OnComplete(delegate {                
                transform.GetComponent<Collider>().enabled = true;
                lumen.GetComponent<Lumen>().ChangeFamen(transform.name);
            });            
        }

        public void RotateUp()
        {
            Sequence sequence = DOTween.Sequence();
            //sequence.Append(transform.DOLocalMove(oldPos, 2));
            //sequence.Join(transform.DOLocalRotate(new Vector3(0, 0, 0), 2));
            sequence.Append(transform.parent.DOLocalRotate(new Vector3(0, 180, -90), 1));
            sequence.Append(transform.DOLocalRotate(new Vector3(0, -450, 0), 1.5f, RotateMode.LocalAxisAdd));
            sequence.Join(transform.DOLocalMoveY(-0.056f, 1.5f));
            sequence.OnComplete(delegate {
                lumen.GetComponent<Lumen>().ChangeFamen(transform.name);
            });
        }
    }
}
