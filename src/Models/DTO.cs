namespace Mascotas.Models;

public class PetDTO
{
    Guid     _id;
    string   _name;
    string   _specie;
    DateTime _birthdate;
    string?  _member;

    public PetDTO(Guid id, string name, string specie, DateTime birthdate, string? member)
    {
        _id        = id;
        _name      = name;
        _specie    = specie;
        _birthdate = birthdate;
        _member    = member;
    }

    public int calcAge() => DateTime.Today.Year - _birthdate.Year;

    public override string ToString()
        => $"{_name}, {_specie}, {calcAge()}, ({_member ?? "Sin dueño"})";
}
