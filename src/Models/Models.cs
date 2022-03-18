namespace Mascotas.Models;

public class Member
{
    public Guid   ID     { get; }
    public string Name   { get; }
    public char   Gender { get; }

    public Member Parse(string str) 
    {
        var fields = line.Split(",");
        return new Member {}; // TODO
    }

    public string ToCsv() => ""; //TODO
    public override ToString() => ""; //TODO
}

public class Pet
{
    public string   Name      { get; set; }
    public char     Gender    { get; set; }
    public Specie   Specie    { get; set; }
    public DateTime Birthdate { get; set; }
    public Member   Member    { get; set; }

    public Pet Parse(string str)
    {
        return new Pet {}; // TODO;
    }

    public strin ToCsv() => ""; // TODO

    public override string ToString()
        => $"{Name},{Gender},{Specie},{Birthdate},{Member.Name}";
}

public class Specie
{
    public Guid   ID   { get; }
    public string Name { get; }

    public override string ToString() => Name;
}
