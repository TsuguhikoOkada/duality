using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�R�A�Ǘ����s��
/// </summary>
public class ScoreManager
{
    /// <summary>
    /// ���݂̃X�R�A
    /// </summary>
    public static int CurrentScore { get; private set; }
    /// <summary>
    /// ���_���Z���ɌĂ΂��C�x���g
    /// </summary>
    public static event Action OnAddScore;
    /// <summary>
    /// ���_�����Z����
    /// </summary>
    /// <param name="score"></param>
    public static void AddScore(int score)
    {
        CurrentScore += score;
        OnAddScore?.Invoke();
    } 
    /// <summary>
    /// ���_�����Z�b�g����
    /// </summary>
    public static void ResetScore()
    {
        CurrentScore = 0;
    }
}
