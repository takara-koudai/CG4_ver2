using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Animator animator;

    private GameObject gameManager;//GameObject���̂��̂�����ϐ�
    private GameManagerScript gameManagerScript;//Script������ϐ�

    // Start is called before the first frame update
    void Start()
    {
        //�Q�[���}�l�[�W���[�̃I�u�W�F�N�g��T��
        gameManager = GameObject.Find("GameManager");

        //�X�N���v�g���l��
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();


        //Destroy(gameObject,5);
        transform.rotation = Quaternion.Euler(0, 180, 0);

        //�����ō��E��
        int r = Random.Range(0, 2);
        if(r == 0 )
        {
            transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.isGameOver() == true)
        {
            return;
        }

        float moveSpeed = 2.0f;
        Vector3 velocity = new Vector3(0, 0, moveSpeed * Time.deltaTime);
        transform.position += transform.rotation * velocity;

        //���E�Ŕ��]
        if (transform.position.x > 4)
        {
            transform.rotation = Quaternion.Euler(0, 180 + 30, 0);
        }
        if (transform.position.x < -4)
        {
            transform.rotation = Quaternion.Euler(0, 180 - 30, 0);
        }
    }
}
