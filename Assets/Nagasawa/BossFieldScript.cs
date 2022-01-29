using UnityEngine;
using System;

/// <summary>
/// �{�X�����̏���
/// </summary>
public class BossFieldScript : MonoBehaviour
{

    [Tooltip("�K�v�ȃX�R�A"), SerializeField] int _bossScore;
    /// <summary>
    /// �{�X�t�B�[���h������ɌĂ΂��C�x���g
    /// </summary>
    public static event Action OnBossField;

    void Update()
    {
        BossOpen();
    }

    /// <summary>
    /// �{�X�����J�������̏���
    /// </summary>
    void BossOpen()
    {
        if (ScoreManager.CurrentScore >= _bossScore)
        {
            OnBossField?.Invoke();
        }
    }
}
