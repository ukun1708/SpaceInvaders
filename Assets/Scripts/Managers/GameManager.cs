using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BoolReactiveProperty startGame = new();
    public BoolReactiveProperty lose = new();
    public BoolReactiveProperty win = new();
    public BoolReactiveProperty pause = new();

    public IntReactiveProperty score = new();
    public IntReactiveProperty waveCount = new();
}
