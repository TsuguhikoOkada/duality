using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// �X�N���v�g�ǉ���Rigidbody���I�u�W�F�N�g�ɒǉ�����
/// </summary>
[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    [SerializeField, Header("�v���C���[�̈ړ����x")] float m_speed = 5f;

    [SerializeField, Header("�v���C���[��HP")] int m_playerHp = 3;

    /// <summary>
    /// �R���|�[�l���g�p�ϐ�
    /// </summary>
    Rigidbody m_playerRb;

    void Start()
    {
        m_playerRb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// �v���C���[�̈ړ�����
    /// </summary>
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float i = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, 0, i);
        m_playerRb.velocity = dir.normalized * m_speed;
    }
}
