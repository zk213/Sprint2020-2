using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoundType", menuName = "Round Type")]
public class RoundType : ScriptableObject
{
    [Range(0, 10)]
    public int numRings = 0;

    [Range(0, 300)]
    public int playerSpeed = 0;

    public bool useFlare = false;

    [Range(0, 15)]
    public float flareFrequency = 0;

    [Range(0, 5)]
    public float StarDiameter = 0;

    public bool infiniteRounds = false;

    [Range(0, 20)]
    public int totalRounds = 0;
}
