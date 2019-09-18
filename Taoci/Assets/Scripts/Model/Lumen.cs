using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace TaoCi
{
    public class Lumen : DeviceBase
    {
        public static Lumen Instance;
        private bool upFamen = true;
        private bool bottomFamen = true;
        private Transform yaoche;

        public delegate void FamenHandler();
        public event FamenHandler FamenClose;
        bool b = true;

        private void Awake()
        {
            Instance = this;
            yaoche = transform.parent.Find("YaoChe");
        }

        public override void OnMouseLeftClick()
        {
            switch (UIManager.Instance.step)
            {
                #region
                case 1002002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    OpenDoor();                    
                    break;
                case 1005002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    OpenDoor();                    
                    break;
                #endregion
                #region
                case 2002002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    OpenDoor();
                    break;
                case 2005002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    OpenDoor();
                    break;
                #endregion
                #region
                case 3002002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    OpenDoor();
                    break;
                case 3005002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    OpenDoor();
                    break;
                #endregion
                #region
                case 4002002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    OpenDoor();
                    break;
                case 4005002:
                    transform.GetComponent<HighlightingSystem.Highlighter>().tween = false;
                    OpenDoor();
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
                    if (upFamen == false && bottomFamen == false && b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 1002004:
                    b = true;
                    break;
                case 1005002:
                    if (upFamen == false && bottomFamen == false && b)
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
                    if (upFamen == false && bottomFamen == false && b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 2002004:
                    b = true;
                    break;
                case 2005002:
                    if (upFamen == false && bottomFamen == false && b)
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
                    if (upFamen == false && bottomFamen == false && b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 3002004:
                    b = true;
                    break;
                case 3005002:
                    if (upFamen == false && bottomFamen == false && b)
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
                    if (upFamen == false && bottomFamen == false && b)
                    {
                        transform.GetComponent<HighlightingSystem.Highlighter>().tween = true;
                        b = false;
                    }
                    break;
                case 4002004:
                    b = true;
                    break;
                case 4005002:
                    if (upFamen == false && bottomFamen == false && b)
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

        public void ChangeFamen(string name)
        {
            if (name.Equals("UpFamen"))
            {
                upFamen = !upFamen;
            }
            else if (name.Equals("DownFamen"))
            {
                bottomFamen = !bottomFamen;
            }
        }

        private void OpenDoor()
        {
            if (upFamen == false && bottomFamen == false)
            {
                transform.GetComponent<Collider>().enabled = false;
                Sequence sequence = DOTween.Sequence();
                sequence.Append(transform.DOLocalRotate(new Vector3(0, 0, -135), 1.5f));
                sequence.Append(yaoche.DOLocalMoveX(-2.9f, 1.5f));
                sequence.OnComplete(delegate
                {
                    UIManager.Instance.AddStep();
                    transform.GetComponent<Collider>().enabled = true;
                });
            }
        }

        public void CloseDoor()
        {
            transform.GetComponent<Collider>().enabled = false;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(yaoche.DOLocalMoveX(-1.039f, 1.5f));
            sequence.Append(transform.DOLocalRotate(new Vector3(0, 0, 0), 1.5f).OnComplete(delegate { FamenClose(); }));
            sequence.OnComplete(delegate
            {
                UIManager.Instance.AddStep();
                transform.GetComponent<Collider>().enabled = true;
            });
        }
    }
}