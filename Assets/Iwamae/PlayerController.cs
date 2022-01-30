using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// �X�N���v�g�ǉ���Rigidbody���I�u�W�F�N�g�ɒǉ�����
/// BoxCollider�̓v���C���[�̐��ʂɔz�u����
/// </summary>
[RequireComponent(typeof(Rigidbody), (typeof(BoxCollider)))]

public class PlayerController : MonoBehaviour
{
    [SerializeField, Tooltip("�v���C���[�̈ړ����x")] float m_speed = 5f;

    [SerializeField, Tooltip("�v���C���[��HP")] int m_playerHp = 3;

    [SerializeField, Tooltip("EnemyTag")] string m_enemyTag;

    [SerializeField, Tooltip("�v���C���[�̉�]���x")] float m_rtSpeed = 0.1f;

    [SerializeField, Tooltip("�v���C���[�̍U���͈͂̃I�u�W�F�N�g")] GameObject m_attackColliderObject;

    bool m_isPoint;

    [SerializeField] string m_pointTagName;

    /// <summary>
    /// �R���|�[�l���g�p�ϐ�
    /// </summary>
    Rigidbody m_playerRb;

    /// <summary>
    /// �R���|�[�l���g�p�ϐ���Rigidbody������
    /// </summary>
    void Start()
    {
        ScoreManager.OnAddScore += Check;
        m_playerRb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// �v���C���[�̈ړ�����
    /// </summary>
    void Update()
    {
        if(GameObject.FindObjectOfType<GameStartManager>())
        {
            return;
        }
        float h = Input.GetAxisRaw("Horizontal");
        float i = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, 0, i);
        m_playerRb.velocity = dir.normalized * m_speed;

        //�v���C���[���ړ����Ă�����
        if (m_playerRb.velocity.magnitude > 0)
        {
            //���ʂ��v���C���[�̈ړ����Ă�������Ɍ�����
            transform.rotation = Quaternion.Slerp(transform.rotation,
                                                  Quaternion.LookRotation(m_playerRb.velocity),
                                                  m_rtSpeed);
        }

        Attack();
    }

    /// <summary>
    /// Fire1�Ɏw�肵�Ă���{�^���������ꂽ��
    /// �v���C���[�ɂ��Ă���BoxCollider����u�A�N�e�B�u�ɂ���
    /// </summary>
    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!_attack)
            {
                _attack = true;
                StartCoroutine(Attack(0.1f));
            }
            Debug.Log("Attck");
        }
    }
    bool _attack = false;
    IEnumerator Attack(float time)
    {
        m_attackColliderObject.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(time);
        m_attackColliderObject.GetComponent<BoxCollider>().enabled = false;
        _attack = false;
    }

    /// <summary>
    /// Enemytag�����Ă�I�u�W�F�N�g�ɓ�����Ǝ���
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == m_pointTagName)
        {
            m_isPoint = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == m_pointTagName)
        {
            m_isPoint = false;
        }
    }

    void Check()
    {
        if(!m_isPoint)
        {
            GameManager.GameOver();
            ScoreManager.OnAddScore -= Check;
        }
    }
}
