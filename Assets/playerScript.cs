using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;

    public GameObject bullet;

    public GameObject gameManager;

    private GameManagerScript gameManagerScript;//Script������֐�

    //�e�̃^�C�}�[
    int bulletTimer = 0;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "EnemyTag")
        {
            gameManagerScript.GameOverStart();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Script���擾����
        gameManagerScript = gameManager.GetComponent<GameManagerScript>();
    }


    void FixedUpdate()
    {
        if(gameManagerScript.isGameOver() == true)
        {
            return;
        }

        if(bulletTimer == 0)
        {

            if (Input.GetKey(KeyCode.Space))//�e����
            {
                bulletTimer = 1;

                Vector3 position = transform.position;
                position.y += 0.8f;
                position.z += 1.0f;

                Instantiate(bullet, position, Quaternion.identity);
            }
        }
        else
        {
            bulletTimer++;
            if(bulletTimer > 20)
            {
                bulletTimer = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float moveSpeed = 2.0f;
        float stageMax = 4.0f; // �E�̍ő�
        float stageMax2 = -4.0f; //���̍ő�

        //�v���C���[�̈ړ�
        if(Input.GetKey(KeyCode.RightArrow))
        {
            if(transform.position.x < stageMax)
            {
                rb.velocity = new Vector3(moveSpeed, 0, 0);
            }
            animator.SetBool("move", true);
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(transform.position.x > stageMax2)
            {
                rb.velocity = new Vector3(-moveSpeed, 0, 0);
            }
            animator.SetBool("move", true);
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, 0);
            animator.SetBool("move", false);
        }

        //�Q�[���I�[�o�[�̂Ƃ��v���C���[���Œ肷��
        if(gameManagerScript.isGameOver() == true)
        {
            rb.velocity = new Vector3(0, 0, 0);
            return;
        }

    }
}
