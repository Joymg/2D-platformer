using System;
using UnityEngine;

namespace Joymg.Platformer2D.WeaponSystem
{
    public class ThrowableWeapon : MonoBehaviour
    {
        private Vector2 _startPosition = Vector2.zero;
        private RangedWeaponData _data;
        private Vector2 _movementDirection;
        private bool _isInitialized = false;
        private Rigidbody _body;
        private LayerMask _layerMask;

        public Transform spriteTransform;
        [SerializeField] private Vector2 center;
        [SerializeField, Range(0.1f, 2f)]
        private float radius = 1;
        [SerializeField] private Color gizmosColor = Color.red;


        private void Awake()
        {
            spriteTransform ??= transform.GetChild(0);
            _body ??= GetComponent<Rigidbody>();
        }


        private void Start()
        {
            _startPosition = transform.position;
        }

        public void Initialize(RangedWeaponData data, Vector2 direction, LayerMask mask)
        {
            _movementDirection = direction;
            _data = data;
            _isInitialized = true;
            _body.velocity = _movementDirection * data.initialSpeed;
            _layerMask = mask;
        }

        private void Update()
        {
            if (!_isInitialized)
                return;

            TryDetectCollision();
            if (((Vector2)transform.position - _startPosition).magnitude >= _data.attackRange)
            {
                Destroy(gameObject);
            }
        }

        private void TryDetectCollision()
        {
            Collider2D collision = Physics2D.OverlapCircle((Vector2)transform.position + center, radius, _layerMask);
            if (collision)
            {
                foreach (IHittable hittable in collision.GetComponents<IHittable>())
                {
                    hittable.GetHit(gameObject,_data.damage);
                }
                Destroy(gameObject);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = gizmosColor;
            Gizmos.DrawSphere(transform.position + (Vector3)center, radius);
        }
    }
}