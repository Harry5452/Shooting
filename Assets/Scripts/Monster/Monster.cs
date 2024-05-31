using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public float speed;
    public Rigidbody2D target;

    bool isLive = true;
    public int damage = 10;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        if (!isLive)
            return;

        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;
    }
    void LateUpdate()
    {
        spriter.flipX = target.position.x < rigid.position.x;
    }
    void OnEnable()
    {
        target = GameManager.instance.Player.GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Die");
            gameObject.SetActive(false);  // ��Ȱ��ȭ
            GameManager.instance.kills++; // ų ī��Ʈ ����
        }

        if (collision.collider.gameObject.CompareTag("Player")) // �÷��̾�� �浹���� ��
        {
            GameManager.instance.health -= damage; // �÷��̾� ü�� ����
        }
    }
}
