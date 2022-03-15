namespace Models;

public class Owner
{
    public string Name   { get; }
    public string Gender { get; }
}

public class Pet
{
    public string Name      { get; }
    public string Gender    { get; }
    public string Specie    { get; }
    public Date   Birthdate { get; }
    public Owner  Owner     { get; }
}
