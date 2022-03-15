namespace Data;

public class PetRepo : IRepository
{
    string _file = "pets.csv";

    string stringify(Pet pet) 
        => $"{pet.Name},{pet.Gender},{pet.Specie},{pet.Birthdate}, {pet.Owner.Name}";

    public void Save(List<Pet> pets) 
    {
        var header = "Nombre,Sexo,Especie,Nacimiento,Dueño";
        var data   = new List<string>() { header };
        items.ForEach(pet => data.Add(stringify(pet))); 
        File.WriteAllLines(_file, data);
    }

}
