using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Ref
{
    public static LevelPan levelPan;
    public static ScoreKeeper scoreKeeper;
    public static int players = 1;
    public static int currentPlayer = -1;
    public static List<int> latestScore = new List<int>() { 0, 0 };
    public static List<int> highScore = new List<int>() { 0, 0 };
}
