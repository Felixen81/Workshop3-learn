using UnityEngine;
using UnityEngine.Audio;

namespace Unity.FPS.Gameplay
{
    public class AudioContainerPlayByMaterial : MonoBehaviour
    {
        public enum CurrentMaterial
        {
            Grass,
            Gravel,
            Metal
        }
    
        [System.Serializable]
        public struct AudioType
        {
            public AudioResource container;   // Unity 6 container asset
        }
    
        public CurrentMaterial currentMaterial;
    
        public AudioSource audioSource;
        public AudioType[] audioSoundType;
    
        public void SetMaterial(int materialNumber)
        {
            currentMaterial = (CurrentMaterial)materialNumber;
        }
    
        public void PlaySoundFromGroup()
        {
            PlayContainer((int)currentMaterial);
        }
    
        private void PlayContainer(int index)
        {
            var cont = audioSoundType[index].container;
    
            if (cont == null)
            {
                Debug.LogWarning("Missing AudioContainer for material " + index);
                return;
            }
            // Unity 6 API:
            audioSource.resource = cont;
            audioSource.Play();
        }
    }
}
