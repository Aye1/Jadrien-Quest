﻿using System;
using UnityEngine;

public abstract class ShootingEnemy : Enemy {

    public Bullet bullet;
    protected float _shootInterval;
    public int initShootInterval = 1;
    public Transform shootPoint;
    public bool debugCanShoot = true;

    /// <summary>
    /// Accessor for the time between two shoots
    /// </summary>
    public float ShootInterval
    {
        get
        {
            return _shootInterval;
        }
        set
        {
            if (value >= 0)
            {
                _shootInterval = value;
            }
        }
    }

    public override void Attack()
    {
        if (!debugCanShoot)
            return;
        _internalTimer += Time.deltaTime;
        if (_internalTimer >= ShootInterval)
        {
            Vector2 direction = Target.transform.position - transform.position;
            direction.Normalize();
            Bullet bulletClone;
            bulletClone = Instantiate(bullet, shootPoint.transform.position, shootPoint.transform.rotation) as Bullet;
            bulletClone.GetComponent<Rigidbody2D>().velocity = direction * bullet.bulletSpeed;
            _internalTimer = 0;

        }
    }

    protected override void Init()
    {
        ShootInterval = initShootInterval;
    }
    public override void Move() {}
    public override void OnHit()
    {
        gameObject.GetComponent<Animation>().Play("RedFlash");
    } 
    protected override void SpecialUpdate() {}
}
