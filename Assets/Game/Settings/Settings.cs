using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Settings", menuName = "Settings")]
public class Settings : ScriptableObject
{
    public Boolean playMusic;
    public Integer musicVolume;
    public Boolean playSounds;
    public Integer soundsVolume;
}
