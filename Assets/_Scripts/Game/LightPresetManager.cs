using System;
using UnityEngine;

namespace Tutor
{
    [Serializable]
    public class LightPresetManager : MonoBehaviour
    {
        [SerializeField] LightPreset[] m_lightPresets;
        [SerializeField] Material[] m_materials;

        public event Action<LightPreset> EOn_SetLightPreset;

        void SetMaterialsColor(Color color)
        {
            foreach(Material material in m_materials)
            {
                material.color = color;
            }
        }

        void ClearAll()
        {
            foreach (var preset in m_lightPresets)
            {
                preset.Clear();
            }
        }

        public void SetLightPreset(int index)
        {
            if (m_lightPresets.Length >= index)
                return;

            ClearAll();
            m_lightPresets[index].Activate();
            SetMaterialsColor(m_lightPresets[index].LightColor);
            RenderSettings.fogColor = m_lightPresets[index].FogColor;

            EOn_SetLightPreset?.Invoke(m_lightPresets[index]);
        }


        [Serializable]
        public class LightPreset
        {
            [SerializeField] GameObject m_lightObject;
            [SerializeField] Color m_lightColor;
            [SerializeField] Color m_fogColor;

            public Color LightColor => m_lightColor;
            public Color FogColor => m_fogColor;

            public void Clear()
            {
                m_lightObject.SetActive(false);
            }

            public void Activate()
            {
                m_lightObject.SetActive(true);
            }
        }
    }
}