using System.Collections.Generic;
using UnityEngine;

public class ChefRun : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private List<Transform> pathChef = new List<Transform>();
    private int currPoint = 0;
    [SerializeField] private float speed = 4;
    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Run", true);
    }


    private void Update()
    {
        if (pathChef == null || pathChef.Count == 0)
            return;

        Transform target = pathChef[currPoint];

        // 1. Hitung arah menuju target
        Vector2 direction = (target.position - transform.position).normalized;

        // 2. Jika koki sedang bergerak, putar objek ke arah tujuan
        if (direction != Vector2.zero)
        {
            // Menghitung sudut dalam derajat
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Mengatur rotasi Z (dikurangi 90 jika sprite asli menghadap ke atas/North)
            transform.rotation = Quaternion.Euler(0, 0, angle + 90f);
        }

        // Move towards target
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 0.05f)
        {
            currPoint = (currPoint + 1) % pathChef.Count;

            if (currPoint == 0)
            {
                Debug.Log("Koki kembali ke titik awal!");
            }
        }
    }
}
