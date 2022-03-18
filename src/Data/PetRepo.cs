using Mascotas.Models;

namespace Mascotas.Data;

public class PetRepo : IRepository<Pet>
{
    string _file = "pets.csv";

    List<Member> _members;
    List<Specie> _species;

    public void setDeps(List<Member> members, List<Specie> species) {
        _members = members;
        _species = species;
    }

    string stringify(Pet pet) 
        => $"{pet.Name},{pet.Gender},{pet.Specie},{pet.Birthdate}, {pet.Member.ID}";

    private Pet parsePet(string line) 
    {
        var fields = line.Split(",");
        return new Pet 
        {
            Name      = fields[0],
            Gender    = fields[1][0],
            Specie    = _species.Find(s => s.ID.ToString() == fields[2]),
            Birthdate = DateTime.Parse(fields[3]),
            Member    = _members.Find(m => m.ID.ToString() == fields[4])
        };
    }

    public void Save(List<Pet> pets) 
    {
        var header = "Nombre,Sexo,Especie,Nacimiento,Dueño";
        var data   = new List<string>() { header };
        pets.ForEach(pet => data.Add(stringify(pet))); 
        File.WriteAllLines(_file, data);
    }

    public List<Pet> Read()
        => File.ReadAllLines(_file)
            .Skip(1)
            .Where(line => line.Length > 0)
            .Select(parsePet)
            .ToList();
}
