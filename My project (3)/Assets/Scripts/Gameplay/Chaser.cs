using UnityEngine;

public class Chaser : ITargetBehavior
{
    float _speed = 1;
    Transform _self;
    Transform _target;
    public Chaser(float speed,Transform target,Transform self)
    {
        _speed = speed;
        _target = target;
        _self = self;
    }
    public void move()
    {
        Vector3 direction = _target.transform.position - _self.position;

        _self.Translate(direction * _speed * Time.deltaTime);
    }
}
