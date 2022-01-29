using UnityEngine;

/// <summary>
/// �G�l�~�[����
/// </summary>
public class EnemyScript : MonoBehaviour
{
    /// <summary>���S�������ǂ���</summary>
    bool _isDeath;
    /// <summary>�T�[�N�����ɂ��邩�ǂ���</summary>
    bool _isPoint;
    /// <summary>
    /// ���ԑ�
    /// true ��
    /// false �����o�Ă���
    /// </summary>
    bool _isTimeZone;
    [Header("�ݒ荀��")]
    [Tooltip("���Z����|�C���g"), SerializeField] int _point;
    [Tooltip("�T�[�N���̖��O"), SerializeField] string _pointName;

    //�J�v�Z����

    /// <summary>���S�������ǂ��� �J�v�Z����</summary>
    public bool IsDeath
    {
        set
        {
            _isDeath = value;
        }
    }

    /// <summary>
    /// ���ԑс@�J�v�Z����
    /// true ��
    /// false �����o�Ă���
    /// </summary>
    public bool IsPoint
    {
        set
        {
            _isTimeZone = value;
        }
    }


    void Update()
    {
        Death();
    }

    /// <summary>
    /// ���S����
    /// </summary>
    void Death()
    {
        if(_isDeath)
        {
            if(_isPoint && !_isTimeZone)
            {
                PointUp();
            }
            else if(!_isPoint && _isTimeZone)
            {
                PointUp();
            }
            else
            {
                GameOver();
            }
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// ����
    /// �|�C���g���Z
    /// </summary>
    void PointUp()
    {

    }

    /// <summary>
    /// ���s
    /// �Q�[���I�[�o�[
    /// </summary>
    void GameOver()
    {

    }

    /// <summary>
    /// �T�[�N�����ɂ���Ƃ��̏���
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == _pointName)
        {
            _isPoint = true;
        }
        else
        {
            _isPoint = false;
        }
    }

    /// <summary>
    /// �T�[�N������o�����̏���
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerExit(Collider other)
    {
        _isPoint = false;
    }
}
