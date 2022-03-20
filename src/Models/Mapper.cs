namespace Mascotas.Models;

public class Mapper
{
    public PetDTO mapPet(Pet pet, List<Member> members, List<Specie> species)
    {
        var owner = members.Find(m => m.ID.Equals(pet.MemberID));
        var specie = species.Find(s => s.ID.Equals(pet.SpecieID));
        return new PetDTO(pet.ID, pet.Name, specie.Name, pet.Birthdate, owner?.Name);
    }

    public List<PetDTO> mapPets(List<Pet> pets, List<Member> members, List<Specie> species)
        => pets.Select(pet => mapPet(pet, members, species)).ToList();
}
