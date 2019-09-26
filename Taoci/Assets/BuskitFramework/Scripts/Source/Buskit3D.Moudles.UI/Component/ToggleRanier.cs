using Com.Rainier.Buskit3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Com.Rainier.Buskit3D.UI
{
    [RequireComponent(typeof(ToggleMode))]
    [RequireComponent(typeof(ToggleLogic))]
    public class ToggleRanier : Toggle
    {
        private bool _isOn = false;
        UGUIDataEntity toggleEntity;

        protected override void Start()
        {
            base.Start();
            try
            {
                toggleEntity = (UGUIDataEntity)GetComponent<ToggleMode>().DataEntity;
            }
            catch (System.Exception) { }
        }
        private void Update()
        {
            if (_isOn != isOn)
            {
                _isOn = !_isOn;
                if (toggleEntity != null)
                    toggleEntity.ToggleIsOn = isOn;
            }
        }
    }
}
