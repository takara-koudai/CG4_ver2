using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScript : MonoBehaviour
{

    public GameObject enemy;
    public GameObject gameOverText;
    public AudioSource hitAudioSource;
    public TextMeshProUGUI scoreText;
    public GameObject bombParticle;

    private bool gameOverFlag = false;
    private int score = 0;
    private int gameTimer = 0;

    public bool isGameOver()//�Q�[���I�[�o�[
    {
        return gameOverFlag;
    }

    //�Q�[���I�[�o�[�J�n
    public void GameOverStart()
    {
        gameOverText.SetActive(true);
        gameOverFlag = true;
    }

    //�e�ƓG���Փ�
    public void Hit(Vector3 position)
    {
        hitAudioSource.Play();
        score += 1;

        //�����p�[�e�B�N������
        Instantiate(bombParticle, position, Quaternion.identity);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(gameOverFlag == true)
        {
            return;
        }

        //�G�̔���
        gameTimer++;
        int max = 50 - gameTimer / 100;
        int r = Random.Range(0,max);
        if(r == 0)
        {
            float x = Random.Range(-3.0f, 3.0f);
            Instantiate(enemy, new Vector3(x, 0, 10), Quaternion.identity);
        }
    }

    private void FixedUpdate()
    {
        int r = Random.Range(0, 50);
        if(r == 0)
        {
            float x = Random.Range(-3.0f, 3.0f);
            Instantiate(enemy, new Vector3(x, 0, 10), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�Q�[���I�[�o�[�Ȃ�
        if(gameOverFlag == true)
        {
            if(Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("TitleScene");
                gameOverFlag = false;
            }
        }

        //�X�R�A�\��
        scoreText.text = "SCORE" + score;
    }
}
