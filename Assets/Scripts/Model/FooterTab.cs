using System;
using UnityEngine;
using UnityEngine.Events;

namespace Model
{
    public class FooterTab : MonoBehaviour
    {
        [SerializeField] private GameObject active;
        [SerializeField] private GameObject unActive;
        public UnityAction<FooterTab> onClick;

        public void OnClickButton()
        {
            onClick?.Invoke(this);
        }

        public void SetActive(bool isActive)
        {
            if (isActive)
            {
                active.SetActive(true);
                unActive.SetActive(false);
            }
            else
            {
                active.SetActive(false);
                unActive.SetActive(true);
            }
        }
    }
}