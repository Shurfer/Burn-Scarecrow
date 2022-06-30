public class Scarecrow : Enemy, IDamageable
{
    public void GetDamage(int damage)
    {
        DecreaseHealth(damage);
    }
}