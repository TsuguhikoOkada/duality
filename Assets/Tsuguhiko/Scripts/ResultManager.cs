using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Result�V�[���Ɉڍs������Text�ɕ\������X�N���v�g
/// </summary>

public class ResultManager : MonoBehaviour
{
    /// <summary>
    /// �����������Ԃ�\������Text�ϐ�
    /// </summary>
    [SerializeField, Header("�\������o�ߎ��Ԃ�Text")] Text _elapsed_time_text;

    /// <summary>
    ///  �����������Ԃ̕ϐ�
    /// </summary>
    float _elapsed_time;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // GameManager��_time�̂���o�ߎ��Ԃ̌��ʂ�����
        GameManager._time = _elapsed_time;

        // �����������Ԃ�Text�ɕ\��
        _elapsed_time_text.text = _elapsed_time.ToString();
    }
}
