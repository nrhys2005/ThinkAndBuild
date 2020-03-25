using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 3.0f;
    private Rigidbody rigid;
    private Animator anim;




    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    public bool Run(Vector3 targetPos)
    {
        // 이동하고자하는 좌표 값과 현재 내 위치의 차이를 구한다.
        float dis = Vector3.Distance(transform.position, targetPos);
        if (dis >= 1.0f) // 차이가 아직 있다면
        {
            // 캐릭터를 이동시킨다.
            transform.localPosition = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
          
            anim.SetBool("isWalk",true); // 걷기 애니메이션 처리
            return true;
        }
        else
        {
            anim.SetBool("isWalk", false); // 걷기 애니메이션 처리
        }
        return false;

    }

    public void Turn(Vector3 targetPos)
    {
        // 캐릭터를 이동하고자 하는 좌표값 방향으로 회전시킨다
        Vector3 dir = targetPos - transform.position;
        Vector3 dirXZ = new Vector3(dir.x, 0, dir.y);
        Quaternion targetRot = Quaternion.LookRotation(dirXZ);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 180.0f * Time.deltaTime);

       
    }
}
