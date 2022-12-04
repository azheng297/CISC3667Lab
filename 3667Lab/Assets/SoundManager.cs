using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] Slider volSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void changeVolume()
    {
        AudioListener.volume = volSlider.value;
    }
}
