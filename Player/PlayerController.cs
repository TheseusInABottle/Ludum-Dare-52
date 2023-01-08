using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    public bool isDead;
    public bool isInvuln;
    public int health = 3;

    public LayerMask hitInvulnTime;
    public float invulTimerConst;
    private float invulTime;

    public GameObject[] carrotImages;
    public int carrotCount = -1;
    public GameObject[] Hearts;

    private Transform cameraTransform;

    [SerializeField] private GameplayController gpc;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float gravityValue = -9.81f;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        controller = gameObject.GetComponent<CharacterController>();
        invulTime = invulTimerConst;
    }

    void Update()
    {
        if (isDead == false || gpc.levelData.isFinished == true)
		{
            PlayerMovement();
		}
		else
		{
            Time.timeScale = 0;
		}

        if(invulTime > 0 && isInvuln == true)
		{
            invulTime -= Time.deltaTime;
        }
		else
		{
            isInvuln = false;
		}

        if (health <= 0)
		{
            isDead = true;
            gpc.deathPanel.SetActive(true);
		}

        if(carrotCount > -1)
		{
            carrotImages[carrotCount].SetActive(true);
		}

        if (health == 2)
		{
            Hearts[2].SetActive(false);
		}

        if (health == 1)
		{
            Hearts[1].SetActive(false);
		}

        if (health <= 0)
		{
            Hearts[0].SetActive(false);
		}

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void PlayerMovement()
	{
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        Vector3 move = new Vector3(movement.x, 0f, movement.z);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        move.y = 0;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Carrot"))
		{
            gpc.levelData.currentCarrots++;
            Destroy(other.gameObject);
            gpc.sfxPlayer.clip = gpc.sfx[0];
            gpc.sfxPlayer.Play();
            carrotCount++;
        }

        if (other.gameObject.CompareTag("Finish"))
		{
            gpc.levelData.isFinished = true;
            gpc.sfxPlayer.clip = gpc.sfx[2];
            gpc.sfxPlayer.Play();
		}

        if (other.gameObject.CompareTag("Enemy") && isInvuln == false)
		{
            health--;
            isInvuln = true;
            invulTime = invulTimerConst;
            gpc.sfxPlayer.clip = gpc.sfx[1];
            gpc.sfxPlayer.Play();
        }
	}
}