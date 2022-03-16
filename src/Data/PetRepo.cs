using Mascotas.Models;

namespace Mascotas.Data;

public class PetRepo : IRepository<Pet>
{
    string _file = "pets.csv";

    public List<Member> Members { get; set; }
    public List<Specie> Species { get; set; }

    string stringify(Pet pet) 
        => $"{pet.Name},{pet.Gender},{pet.Specie},{pet.Birthdate}, {pet.Member.Name}";

    public void Save(List<Pet> pets) 
    {
        var header = "Nombre,Sexo,Especie,Nacimiento,Dueño";
        var data   = new List<string>() { header };
        pets.ForEach(pet => data.Add(stringify(pet))); 
        File.WriteAllLines(_file, data);
    }

    private Pet parsePet(string line) 
    {
        var fields = line.Split(",");
        return new Pet 
        {
            Name      = fields[0],
            Gender    = fields[1][0],
            Specie    = Species.Find(s => s.ID.ToString() == fields[2]),
            Birthdate = DateTime.Parse(fields[3]),
            Member    = Members.Find(m => m.ID.ToString() == fields[4])
        };
    }

    public List<Pet> Read()
        => File.ReadAllLines(_file)
            .Skip(1)
            .Where(line => line.Length > 0)
            .Select(parsePet)
            .ToList();
}
