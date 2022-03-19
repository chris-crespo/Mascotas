﻿namespace Mascotas.Models;

public class Member
{
    public Guid   ID     { get; }
    public string Name   { get; }
    public char   Gender { get; }

    public Member(Guid id, string name, char gender) 
    {
        ID     = id;
        Name   = name;
        Gender = gender;
    }

    public static Member Parse(string str) 
    {
        var fields = str.Split(",");
        return new Member(
            id:     Guid.Parse(fields[0]),
            name:   fields[1],
            gender: fields[2][0]
        );
    }

    public override string ToString() 
        => $"{ID},{Name},{Gender}";
}

public class Pet
{
    public string   Name      { get; }
    public char     Gender    { get; }
    public Guid     SpecieID  { get; }
    public DateTime Birthdate { get; }
    public Guid     MemberID  { get; }

    public Pet(string name, char gender, Guid specieID, DateTime birthdate, Guid memberID)
    {
        Name      = name;
        Gender    = gender;
        SpecieID  = specieID;
        Birthdate = birthdate;
        MemberID  = memberID;
    }

    public static Pet Parse(string str)
    {
        var fields = str.Split(",");
        return new Pet(
            name:      fields[0],
            gender:    fields[1][0],
            specieID:  Guid.Parse(fields[2]),
            birthdate: DateTime.Parse(fields[3]),
            memberID:  Guid.Parse(fields[4])
        );
    }

    public override string ToString() 
        => $"{Name},{Gender},{SpecieID},{Birthdate},{MemberID}";
}

public class Specie
{
    public Guid   ID   { get; }
    public string Name { get; }

    public Specie(Guid id, string name) 
    {
        ID   = id;
        Name = name;
    }

    public static Specie Parse(string str)
    {
        var fields = str.Split(",");
        return new Specie(
            id:   Guid.Parse(fields[0]),
            name: fields[1]
        );
    }

    public override string ToString() 
        => $"{ID},{Name}";
}
