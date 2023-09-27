
public interface IPlayer
{
    public float DefaultSpeed {  get; }
    public float Speed { get; set; }
    public bool God { get; set; }
    public void AccelerationEffect();
    public void DecelerationEffect();
    public void InvincibleEffectOn();
    public void InvincibleEffectOff();
}
