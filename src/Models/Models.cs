namespace Mascotas.Models;

public class Member
{
    public Guid   ID     { get; }
    public string Name   { get; }
    public char   Gender { get; }
}

public class Pet
{
    public string   Name      { get; set; }
    public char     Gender    { get; set; }
    public Specie   Specie    { get; set; }
    public DateTime Birthdate { get; set; }
    public Member   Member    { get; set; }

    public override string ToString()
        => $"{Name},{Gender},{Specie},{Birthdate},{Member.Name}";
}

public class Specie
{
    public Guid   ID   { get; }
    public string Name { get; }

    public override string ToString() => Name;
}
