using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CapsuleCollider))]
public class PlayerController : MonoBehaviour {

    public LayerMask CollisionMask;

    public bool isRed;

	const float skinWidth = .04f;
	public int HorizontalRays = 4;
	public int VerticalRays = 4;

    float maxClimbAngle = 40;
    float maxDescendAngle = 40;

    float HorizontalRayWidth;
	float VerticalRayWidth;

    /////////////
    private GameObject m_otherPlayer = null;

    private GameObject m_mainCamera = null;
    //////////////

	CapsuleCollider m_Collider;
	Raycast m_Raycast;
    public CollisionInfo m_CollisionInfo;



    void Start ()
    {
        m_Collider = GetComponent<CapsuleCollider>();
        RayWidth();

        ///////////////////
        m_mainCamera = GameObject.FindGameObjectsWithTag("MainCamera")[0];

        //Set other player
        GameObject[] players;
        players = GameObject.FindGameObjectsWithTag("Player");

        if (players.Length > 1)
        {
            //Assign player 1
            if (this.GetComponent<P1ColourController>() != null)
            {
                if (players[0].GetComponent<P2ColourController>() != null)
                    m_otherPlayer = players[0];
                if (players[1].GetComponent<P2ColourController>() != null)
                    m_otherPlayer = players[1];
            }

            //Assign player 2
            if (this.GetComponent<P2ColourController>() != null)
            {
                if (players[0].GetComponent<P1ColourController>() != null)
                    m_otherPlayer = players[0];
                if (players[1].GetComponent<P1ColourController>() != null)
                    m_otherPlayer = players[1];
            }
        }
        ////////////////////
    }

 

	void UpdateRaycast()
    {
		Bounds boundingBox = m_Collider.bounds;
		boundingBox.Expand (skinWidth * -2);
        
		m_Raycast.bottomLeft = new Vector3 (boundingBox.min.x, boundingBox.min.y, boundingBox.center.z);
        m_Raycast.bottomRight = new Vector3 (boundingBox.max.x, boundingBox.min.y, boundingBox.center.z);
        m_Raycast.topLeft = new Vector3 (boundingBox.min.x, boundingBox.max.y, boundingBox.center.z);
        m_Raycast.topRight = new Vector3 (boundingBox.max.x, boundingBox.max.y, boundingBox.center.z);
	}

    void HorizontalCollisions(ref Vector3 Velocity)
    {

        float dirX = m_CollisionInfo.faceDir;
        float rayLength = Mathf.Abs(Velocity.x) + skinWidth;

        if (Mathf.Abs(Velocity.x) < skinWidth)
        {
            rayLength = 2 * skinWidth;
        }

        for (int i = 0; i < HorizontalRays; i++)
        {
            Vector3 rayOrigin = (dirX == -1) ? m_Raycast.bottomLeft : m_Raycast.bottomRight;
            rayOrigin += Vector3.up * (HorizontalRayWidth * i);
            RaycastHit hit;
            Ray r1 = new Ray(rayOrigin, Vector3.right * dirX);

            Debug.DrawRay(rayOrigin, Vector2.right * dirX, Color.red);

            if (Physics.Raycast(r1, out hit, rayLength, CollisionMask))
            {

                if (hit.distance == 0)
                {
                    continue;
                }

                float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);

                if (i == 0 && slopeAngle <= maxClimbAngle)
                {
                    if (m_CollisionInfo.descendingSlope)
                    {
                        m_CollisionInfo.descendingSlope = false;
                        Velocity = m_CollisionInfo.velocityOld;
                    }
                    float distanceToSlopeStart = 0;
                    if (slopeAngle != m_CollisionInfo.slopeAngleOld)
                    {
                        distanceToSlopeStart = hit.distance - skinWidth;
                        Velocity.x -= distanceToSlopeStart * dirX;
                    }
                    ClimbSlope(ref Velocity, slopeAngle, hit.normal);
                    Velocity.x += distanceToSlopeStart * dirX;
                }

                if (!m_CollisionInfo.climbingSlope || slopeAngle > maxClimbAngle)
                {
                    Velocity.x = (hit.distance - skinWidth) * dirX;
                    rayLength = hit.distance;

                    if (m_CollisionInfo.climbingSlope)
                    {
                        Velocity.y = Mathf.Tan(m_CollisionInfo.slopeAngle * Mathf.Deg2Rad) * Mathf.Abs(Velocity.x);
                    }

                    m_CollisionInfo.left = dirX == -1;
                    m_CollisionInfo.right = dirX == 1;
                }
            }
        }
    }

    void VerticalCollisions(ref Vector3 Velocity)
    {
        float dirY = Mathf.Sign(Velocity.y);
        float rayLength = Mathf.Abs(Velocity.y) + skinWidth * 12;



        for (int i = 0; i < VerticalRays; i++)
        {
            Vector3 rayOrigin = (dirY == -1) ? m_Raycast.bottomLeft : m_Raycast.topLeft;
            rayOrigin += Vector3.right * (VerticalRayWidth * i + Velocity.x);
            RaycastHit Hit;
            Ray r1 = new Ray(rayOrigin, Vector3.up * dirY);


            Debug.DrawRay(rayOrigin, Vector2.up * dirY * rayLength, Color.red);

            if (Physics.Raycast(r1, out Hit, rayLength, CollisionMask))
            {
                Velocity.y = (Hit.distance - skinWidth) * dirY;
                rayLength = Hit.distance;

                if (m_CollisionInfo.climbingSlope)
                {
                    Velocity.x = Velocity.y / Mathf.Tan(m_CollisionInfo.slopeAngle * Mathf.Deg2Rad) * Mathf.Sign(Velocity.x);
                }


                m_CollisionInfo.bottom = dirY == -1;
                m_CollisionInfo.top = dirY == 1;

            }
        }
    }
    

    void ClimbSlope(ref Vector3 velocity, float slopeAngle, Vector2 slopeNormal)
    {
 
            float moveDistance = Mathf.Abs(velocity.x);
            float climbmoveAmountY = Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * moveDistance;

            if (velocity.y <= climbmoveAmountY)
            {
                velocity.y = climbmoveAmountY;
                velocity.x = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * moveDistance * Mathf.Sign(velocity.x);
                m_CollisionInfo.bottom = true;
                m_CollisionInfo.climbingSlope = true;
                m_CollisionInfo.slopeAngle = slopeAngle;
                m_CollisionInfo.slopeNormal = slopeNormal;
            }
    }

    void DescendSlope(ref Vector3 velocity)
    {
        float dirX = Mathf.Sign(velocity.x);
        Vector2 rayOrigin = (dirX == -1) ? m_Raycast.bottomRight : m_Raycast.bottomLeft;
        RaycastHit Hit;
        Ray r1 = new Ray(rayOrigin, -Vector3.up);

        if (Physics.Raycast(r1, out Hit, Mathf.Infinity, CollisionMask))
        {
            float slopeAngle = Vector2.Angle(Hit.normal, Vector2.up);
            if (slopeAngle != 0 && slopeAngle <= maxDescendAngle)
            {
                if (Mathf.Sign(Hit.normal.x) == dirX)
                {
                    if (Hit.distance - skinWidth <= Mathf.Tan(slopeAngle * Mathf.Deg2Rad) * Mathf.Abs(velocity.x))
                    {
                        float moveDistance = Mathf.Abs(velocity.x);
                        float descendVelocityY = Mathf.Sin(slopeAngle * Mathf.Deg2Rad) * moveDistance;
                        velocity.x = Mathf.Cos(slopeAngle * Mathf.Deg2Rad) * moveDistance * Mathf.Sign(velocity.x);
                        velocity.y -= descendVelocityY;

                        m_CollisionInfo.slopeAngle = slopeAngle;
                        m_CollisionInfo.descendingSlope = true;
                        m_CollisionInfo.bottom = true;
                        m_CollisionInfo.slopeNormal = Hit.normal;
                    }
                }
            }
        }
    }

    void RayWidth()
    {
		Bounds boundingBox = m_Collider.bounds;
		boundingBox.Expand (skinWidth * -2);

        float boundsWidth = boundingBox.size.x;
        float boundsHeight = boundingBox.size.y;


        HorizontalRays = Mathf.Clamp (HorizontalRays, 2, int.MaxValue);
		VerticalRays = Mathf.Clamp (VerticalRays, 2, int.MaxValue);

		HorizontalRayWidth = boundingBox.size.y / (HorizontalRays - 1);
		VerticalRayWidth = boundingBox.size.x / (VerticalRays - 1);
	}

    public void Move(Vector3 Velocity)
    {
        UpdateRaycast();

        m_CollisionInfo.reset();
        m_CollisionInfo.velocityOld = Velocity;


        if (Velocity.y < 0)
        {
            DescendSlope(ref Velocity);
        }

        if (Velocity.x != 0)
        {
            m_CollisionInfo.faceDir = (int)Mathf.Sign(Velocity.x);
        }

        HorizontalCollisions(ref Velocity);
        if (Velocity.y != 0)
        {
           VerticalCollisions(ref Velocity);
        }





        ///////////////////
        if (!m_mainCamera.GetComponent<CameraMove>().m_singlePlayer)
        {
            //Group players together X-Axis
            if (transform.position.x + Velocity.x - m_otherPlayer.transform.position.x > m_mainCamera.GetComponent<CameraMove>().m_maxHorizontalDistance)
                Velocity.x -= transform.position.x + Velocity.x - m_otherPlayer.transform.position.x - m_mainCamera.GetComponent<CameraMove>().m_maxHorizontalDistance;

            if (transform.position.x + Velocity.x - m_otherPlayer.transform.position.x < -m_mainCamera.GetComponent<CameraMove>().m_maxHorizontalDistance)
                Velocity.x -= transform.position.x + Velocity.x - m_otherPlayer.transform.position.x + m_mainCamera.GetComponent<CameraMove>().m_maxHorizontalDistance;

            //Group players together Y-Axis
            if (transform.position.y + Velocity.y - m_otherPlayer.transform.position.y > m_mainCamera.GetComponent<CameraMove>().m_maxVerticalDistance)
                Velocity.y -= transform.position.y + Velocity.y - m_otherPlayer.transform.position.y - m_mainCamera.GetComponent<CameraMove>().m_maxVerticalDistance;

            if (transform.position.y + Velocity.y - m_otherPlayer.transform.position.y < -m_mainCamera.GetComponent<CameraMove>().m_maxVerticalDistance)
                Velocity.y -= transform.position.y + Velocity.y - m_otherPlayer.transform.position.y + m_mainCamera.GetComponent<CameraMove>().m_maxVerticalDistance;
        }
        //////////////////
       
        transform.Translate(Velocity);
    }

    public struct CollisionInfo
    {
        public bool top, bottom;
        public bool left, right;
        public bool climbingSlope;
        public bool descendingSlope;
        public float slopeAngle, slopeAngleOld;
        public Vector3 velocityOld;

        public Vector2 slopeNormal;

        public int faceDir;


        public void reset()
        {
            top = bottom = false;
            left = right = false;
            climbingSlope = false;
            descendingSlope = false;

            slopeAngleOld = slopeAngle;
            slopeAngle = 0;
        }


    }

    

	struct Raycast
    {
		public Vector3 topLeft, topRight;
		public Vector3 bottomLeft, bottomRight;
	}

}
