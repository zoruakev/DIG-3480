using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coinblock : MonoBehaviour {

    public float bounceHeight = 0.5f;
    public float bounceSpeed = 4f;
    public float coinMoveSpeed = 8f;
    public float coinMoveHeight = 3f;
    public float coinFallDistance = 2f;

    private Vector2 originalPosition;
    private bool canBounce = true;

    Animator anim;
    private Rigidbody2D rb2d;
    public int blockHealth;
    private int currentHealth;
    public Sprite deadBlock;

    // Update is called once per frame

    void Start()
    {
        originalPosition = transform.position;
        currentHealth = blockHealth;
    }

    public void QuestionBlockBounce()
    {
        if (canBounce)
        {
            canBounce = false;
            StartCoroutine(Bounce());
        }
    }

    void Update()
    {
        
    }

    void ChangeSprite()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = deadBlock;
    }

    void PresentCoin()
    {
        GameObject Coin = (GameObject)Instantiate(Resources.Load("Prefabs/Coin", typeof(GameObject)));

        Coin.transform.SetParent(this.transform.parent);

        Coin.transform.localPosition = new Vector2(originalPosition.x, originalPosition.y + 1);
        StartCoroutine(MoveCoin(Coin));
    }

    IEnumerator Bounce()
    {
        ChangeSprite();

        PresentCoin();

        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y + bounceSpeed * Time.deltaTime);
            if (transform.localPosition.y >= originalPosition.y + bounceHeight) break;
            yield return null;
        }

        while (true)
        {
            transform.localPosition = new Vector2(transform.localPosition.x, transform.localPosition.y - bounceSpeed * Time.deltaTime);
            if (transform.localPosition.y <= originalPosition.y - bounceHeight)
            {
                transform.localPosition = originalPosition;
                break;
            } 
            yield return null;
        }
    }

    IEnumerator MoveCoin(GameObject coin)
    {
        while (true)
        {
            coin.transform.localPosition = new Vector2(coin.transform.localPosition.x, coin.transform.localPosition.y + coinMoveSpeed * Time.deltaTime);
            if (coin.transform.localPosition.y >= originalPosition.y + coinMoveHeight + 1) break;
            yield return null;

        }

        while (true)
        {
            coin.transform.localPosition = new Vector2(coin.transform.localPosition.x, coin.transform.localPosition.y - coinMoveSpeed * Time.deltaTime);
            if (coin.transform.localPosition.y <= originalPosition.y + coinFallDistance + 1)
            {
                Destroy(coin.gameObject);
                break;
            }
            yield return null;
        }
    }

}
