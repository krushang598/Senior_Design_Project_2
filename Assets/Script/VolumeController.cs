using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    //references
    [SerializeField]
    Slider VolumeSlider;        //slider which will be used to control volume
    [SerializeField]
    AudioSource MainAS;         //main audio source of scene


    void Start()
    {
        //setting starting volume and slider value
        VolumeSlider.value = SongController.Volume;
        MainAS.volume = SongController.Volume;
    }

    void Update()
    {
        //updating current audio source volume and volume in other scenes by slider value
        MainAS.volume = VolumeSlider.value;
        SongController.Volume = VolumeSlider.value;
    }
}
