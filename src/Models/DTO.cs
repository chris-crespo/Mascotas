namespace Mascotas.Models;

public class MemberDTO
{
    public Guid ID { get; }
    string Name;
    char   Gender;

    public MemberDTO(Guid id, string name, char gender) 
    {
        ID     = id;
        Name   = name;
        Gender = gender;
    }

    public override string ToString() => $"{Name}, {Gender}";
}

public class PetDTO
{
    public   Guid ID { get; }
    string   Name;
    string   Specie;
    DateTime Birthdate;
    string?  Member;

    public PetDTO(Guid id, string name, string specie, DateTime birthdate, string? member)
    {
        ID        = id;
        Name      = name;
        Specie    = specie;
        Birthdate = birthdate;
        Member    = member;
    }

    public int calcAge() => DateTime.Today.Year - Birthdate.Year;

    public override string ToString()
        => $"{Name}, {Specie}, {calcAge()} años, ({Member ?? "Sin dueño"})";
}

public class SpecieDTO
{
    public Guid ID { get; }
    string Name;

    public SpecieDTO(Guid id, string name)
    {
        ID   = id;
        Name = name;
    }

    public override string ToString() => Name;
}
