using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaoCi
{
    public class PlayerController : MonoBehaviour
    {
        private Animation animator;

        private void Awake()
        {
            animator = transform.GetComponent<Animation>();
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                animator.Play();
            }
            else
            {
                animator.Stop();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "yao")
            {
                MainScene.Instance.GoScene();
            }
        }
    }
}