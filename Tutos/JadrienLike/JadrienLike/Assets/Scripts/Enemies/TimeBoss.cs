﻿using UnityEngine;
using System.Collections;

public class TimeBoss : Enemy
{

    private int _hour;
    private int _minute;
    private Vector3 _targetPosition;
    private Vector3 _clockPosition;
    private bool _targetReached;
    public bool patternInProgress;

    private int _step;

    #region Pattern 1
    private int _stepNumberPattern1 = 4;
    private Vector3 _pattern1Pos1 = new Vector3(25.0f, 42.0f, 0.0f);
    private Vector3 _pattern1Pos2 = new Vector3(18.0f, 36.0f, 0.0f);
    private Vector3 _pattern1Pos3 = new Vector3(12.0f, 42.0f, 0.0f);

    #endregion

    #region Pattern 2
    private int _stepNumberPattern2 = 3;
    private Vector3 _pattern2Pos1 = new Vector3(25.0f, 42.0f, 0.0f);
    private Vector3 _pattern2Pos2 = new Vector3(12.0f, 42.0f, 0.0f);
    #endregion


    #region Accessors
    public int Hour
    {
        get
        {
            return _hour;
        }
        set
        {
            if (value >= 1 && value <= 12)
            {
                _hour = value;
            }
        }
    }

    public int Minute
    {
        get
        {
            return _minute;
        }
        set
        {
            if (value >= 1 && value <= 12)
            {
                _minute = value;
            }
        }
    }
    #endregion

    protected override void Init()
    {
        _targetPosition = new Vector3(0.0f, 0.0f, 0.0f);
        _clockPosition = GetComponentInParent<TimeBossClock>().transform.position;
        _targetPosition = _clockPosition;
        _moveSpeed = 0.1f;
        patternInProgress = false;
    }

    public void LaunchPattern(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
        _step = 0;
        _targetReached = true;
        patternInProgress = true;
    }

    public override void Move()
    {
        float dist = Vector3.Distance(_targetPosition, transform.position);
        if (dist <= 0.5f)
        {
            _targetReached = true;
        }
        else
        {
            Vector3 move = _targetPosition - transform.position;
            move.Normalize();
            transform.Translate(move * MoveSpeed);
        }
    }


    protected override void SpecialUpdate()
    {
        if (_targetReached && patternInProgress)
        {
            switch (Hour)
            {
                case 1:
                    UpdatePattern1();
                    break;
                case 2:
                    UpdatePattern2();
                    break;

            }
        }
    }

    private void UpdatePattern1()
    {
        if (_step != _stepNumberPattern1)
        {
            _step++;
            _targetReached = false;
            switch (_step)
            {
                case 1:
                    _targetPosition = _pattern1Pos1;
                    break;
                case 2:
                    _targetPosition = _pattern1Pos2;
                    break;
                case 3:
                    _targetPosition = _pattern1Pos3;
                    break;
                case 4:
                    _targetPosition = _clockPosition;
                    break;
            }
        }
        else
        {
            patternInProgress = false;
        }
    }

    private void UpdatePattern2()
    {
        if (_step != _stepNumberPattern2)
        {
            _step++;
            _targetReached = false;
            switch (_step)
            {
                case 1:
                    _targetPosition = _pattern2Pos1;
                    break;
                case 2:
                    _targetPosition = _pattern2Pos2;
                    break;
                case 3:
                    _targetPosition = _clockPosition;
                    break;
            }
        }
        else
        {
            patternInProgress = false;
        }
    }
    public override void Attack()
    {
    }

    public override void OnHit()
    {
    }
}
