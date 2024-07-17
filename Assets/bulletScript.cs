using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{

    public Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyTag")
        {
            //�Q�[���}�l�[�W���[�̃X�N���v�g���l��
            GameObject gameManager;//GameObject���̂��̂�����ϐ�
            GameManagerScript gameManagerScript;//Script������ϐ�
            gameManager = GameObject.Find("GameManager");
            gameManagerScript = gameManager.GetComponent<GameManagerScript>();

            //�Q�[���}�l�[�W���[�X�N���v�g�̏Փ˔�����Ăяo��
            gameManagerScript.Hit(transform.position);

            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        float moveSpeed = 5.0f;

        rb.velocity = new Vector3(0, 0, moveSpeed);

        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
