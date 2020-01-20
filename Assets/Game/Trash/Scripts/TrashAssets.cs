using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Trash", menuName = "Trash")]
public class TrashAssets : ScriptableObject
{
    public string _name;
    public Sprite sprite;
    public AudioClip sound;
    public TrashType trash;
}
